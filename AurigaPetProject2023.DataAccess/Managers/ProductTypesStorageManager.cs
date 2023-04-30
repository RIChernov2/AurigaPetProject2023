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
        }

        public int Create(ProductType entity)
        {
            int result = 0;

            Task.Run(async () =>
            {
                result = await _uow.ProductTypeRepository.CreateAsync(entity);
            }).Wait();

            _uow.Commit();
            return result;

        }

        public int Update(ProductType entity)
        {
            int result = 0;

            Task.Run(async () =>
            {
                result = await _uow.ProductTypeRepository.UpdateAsync(entity);
            }).Wait();

            _uow.Commit();
            return result;
        }

        public int Delete(int id)
        {
            int result = 0;

            Task.Run(async () =>
            {
                result = await _uow.ProductTypeRepository.DeleteAsync(id);
            }).Wait();

            _uow.Commit();
            return result;
        }
    }
}
