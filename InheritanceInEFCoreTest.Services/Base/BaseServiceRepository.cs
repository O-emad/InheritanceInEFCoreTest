
using InheritanceInEFCoreTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InheritanceInEFCoreTest.Data;
using InheritanceInEFCoreTest.Services.Helpers.ResourceParameters.Base;
using InheritanceInEFCoreTest.Services.Helpers;

namespace InheritanceInEFCoreTest.Services
{
    public class BaseServiceRepository<T> : IBaseServiceRepository<T> where T : BaseEntity, new()
    {
        internal readonly WorkFlowContext context;

        public BaseServiceRepository(WorkFlowContext context)
        {
            this.context = context??throw new ArgumentNullException(nameof(context));
        }

        public virtual void Add(T obj)
        {
            if (obj == null) throw new ArgumentNullException("Obj: The object to be added is null");
            context.Add(obj);
        }

        public virtual void Delete(T obj)
        {
            if (obj == null) throw new ArgumentNullException("Obj: The object to be deleted is null");
            context.Remove(obj);
        }

        public virtual bool Exists(Guid id)
        {
            var _dbcontext = context.Set<T>();
            return _dbcontext.Any(i => i.Id == id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            var _dbcontext = context.Set<T>();
            return _dbcontext.ToList();
        }

        public virtual PagedList<T> GetPagedList(BaseResourceParameters resourceParameters)
        {
            if(resourceParameters == null) throw new ArgumentNullException(nameof(resourceParameters));
            var _dbcontext = context.Set<T>();
            var collection = _dbcontext as IQueryable<T>;
            if (!string.IsNullOrWhiteSpace(resourceParameters.SearchQuery))
            {
                var searchQuery = resourceParameters.SearchQuery.Trim().ToLower();
                //perform search
            }
            if (!string.IsNullOrWhiteSpace(resourceParameters.FilterQuery))
            {
                var filterQuery = resourceParameters.FilterQuery.Trim().ToLower();
                //perform filtering
            }
            collection = collection.OrderBy(c => c.CreatedAt);
            return PagedList<T>.Create(collection, resourceParameters.PageNumber, resourceParameters.PageSize);
        }

        public virtual T GetById(Guid id)
        {
            if (Exists(id)) {
                var _dbcontext = context.Set<T>();
                return _dbcontext.FirstOrDefault(i => i.Id == id)??new T { Id=Guid.Empty};
                    }
            return new T()
            {
                Id = Guid.Empty
            };
        }

        public virtual bool Save()
        {
            return (context.SaveChanges() > 0);
        }

        public virtual void Update(T obj)
        {
            //does nothing if tracking is on
        }
    }
}
