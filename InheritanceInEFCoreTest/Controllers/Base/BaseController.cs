using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using InheritanceInEFCoreTest.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using InheritanceInEFCoreTest.Services.Helpers.ResourceParameters.Base;
using InheritanceInEFCoreTest.Domain;
using InheritanceInEFCoreTest.Services;
using InheritanceInEFCoreTest;

namespace InheritanceInEFCoreTest.Controllers
{
    public class BaseController<Domain, DTO> : ControllerBase where Domain : BaseEntity, new() where DTO : class, new()
    {

        internal readonly IMapper mapper;
        private readonly IBaseServiceRepository<Domain> baseServiceRepository;


        public BaseController(IMapper mapper, IBaseServiceRepository<Domain> baseServiceRepository)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.baseServiceRepository = baseServiceRepository;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(object))]
        [Pagination("resourceParameters",typeof(BaseResourceParameters))]
        virtual public IActionResult Get([FromQuery] BaseResourceParameters resourceParameters)
        {
            if (Request.Query?.Count > 0)
            {
                var entities = baseServiceRepository.GetPagedList(resourceParameters);
                var previousPageLink = entities.HasPrevious ?
                    CreateBaseResourceUri(resourceParameters, ResourceUriType.PreviousPage) : null;

                var nextPageLink = entities.HasNext ?
                    CreateBaseResourceUri(resourceParameters, ResourceUriType.NextPage) : null;

                var paginationMetadata = new
                {
                    searchQuery = resourceParameters.SearchQuery,
                    filterQuery = resourceParameters.FilterQuery,
                    totalCount = entities.TotalCount,
                    pageSize = entities.PageSize,
                    currentPage = entities.CurrentPage,
                    totalPages = entities.TotalPages,
                    previousPageLink,
                    nextPageLink
                };

                Response.Headers.Add("X-Pagination",
                                JsonSerializer.Serialize(paginationMetadata));
                return Ok(entities);
            }
            else
                return Ok(baseServiceRepository.GetAll());
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(object))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(object))]
        virtual public IActionResult GetById(Guid id)
        {
            var entity = baseServiceRepository.GetById(id);
            if (entity.Id == Guid.Empty)
                return NotFound();
            return Ok(entity);
        }

        


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(object))]
        virtual public IActionResult Create([FromBody] DTO entityToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var _entity = mapper.Map<Domain>(entityToAdd);
            baseServiceRepository.Add(_entity);
            baseServiceRepository.Save();
            return CreatedAtAction(nameof(GetById), new { _entity.Id }, _entity);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(object))]
        virtual public IActionResult Update(Guid id, [FromBody] DTO entityToUpdate)
        {
            if (!ModelState.IsValid) return BadRequest();
            var _entity = baseServiceRepository.GetById(id);
            if (_entity is null || _entity.Id == Guid.Empty) return NotFound(new { Message = $"there's no {typeof(Domain).Name} with the given id" });
            mapper.Map(entityToUpdate, _entity);
            baseServiceRepository.Update(_entity);
            baseServiceRepository.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(object))]
        virtual public IActionResult Delete(Guid id)
        {
            var _entity = baseServiceRepository.GetById(id);
            if (_entity is null || _entity.Id == Guid.Empty) return NotFound(new { Message = $"there's no {typeof(Domain).Name} with the given id" });
            baseServiceRepository.Delete(_entity);
            baseServiceRepository.Save();
            return NoContent();
        }




        private string? CreateBaseResourceUri(BaseResourceParameters resourceParameters,
                                              ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:

                    
                    return Url.ActionLink("Get", values: new
                    {
                        PageNumber = resourceParameters.PageNumber - 1,
                        PageSize = resourceParameters.PageSize,
                        SeachQuery = resourceParameters.SearchQuery,
                        FilterQuery = resourceParameters.FilterQuery
                    });
                case ResourceUriType.NextPage:
                    return Url.ActionLink("Get", values: new
                    {
                        PageNumber = resourceParameters.PageNumber + 1,
                        PageSize = resourceParameters.PageSize,
                        SeachQuery = resourceParameters.SearchQuery,
                        FilterQuery = resourceParameters.FilterQuery
                    });
                default:
                    return Url.ActionLink("Get", values: new
                    {
                        PageNumber = resourceParameters.PageNumber,
                        PageSize = resourceParameters.PageSize,
                        SeachQuery = resourceParameters.SearchQuery,
                        FilterQuery = resourceParameters.FilterQuery
                    });
            }
        }



    }
}
