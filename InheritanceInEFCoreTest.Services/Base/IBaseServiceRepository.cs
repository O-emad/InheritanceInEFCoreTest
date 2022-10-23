
using InheritanceInEFCoreTest.Services.Helpers;
using InheritanceInEFCoreTest.Services.Helpers.ResourceParameters.Base;
using InheritanceInEFCoreTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.Services
{
    public interface IBaseServiceRepository<T> where T : BaseEntity
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        PagedList<T> GetPagedList(BaseResourceParameters resourceParameters);
        bool Exists(Guid id);
        bool Save();



    }
}
