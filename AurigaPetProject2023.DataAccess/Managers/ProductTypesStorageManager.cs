using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Managers
{
    public class ProductTypesStorageManager : IProductTypesStorageManager
    {
        private readonly IUnitOfWork _uow;

        public ProductTypesStorageManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<ProductType>> GetAllAsync()
        {
            return (await _uow.ProductTypeRepository.GetAsync()).ToList();

        }
        public List<ProductType> GetAll()
        {
            List<ProductType> result = new List<ProductType>();

            Task.Run(async () =>
            {
                result = (await _uow.ProductTypeRepository.GetAsync()).ToList(); 
            }).Wait();

            return result;




            //List<ProductType> result = new List<ProductType>();

            //Task.Run(() =>
            //{
            //    var task = _uow.ProductTypeRepository.GetAsync();
            //    var aaa = task.Result;
            //    result = aaa.ToList();
            //}).Wait();

            //return result;

            #region  ПОТОМ УДАЛИТЬ
            //List<ProductType> result = new List<ProductType>();

            //var bbb = Task.Run(() =>
            //{
            //    var task = _uow.ProductTypeRepository.GetAsync();
            //    var aaa = task.Result;
            //    result = aaa.ToList();
            //});

            //Task.WaitAll(bbb);

            //return result;

            //var task = _uow.ProductTypeRepository.GetAsync();
            ////Task.WaitAll(task);
            //var aaa = task.Result;

            //return aaa.ToList();


            //var readonlyList = await _uow.ProductTypeRepository.GetAsync();
            //readonlyList.ToList()
            #endregion
        }
    }
}
