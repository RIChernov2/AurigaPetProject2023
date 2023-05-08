using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Managers
{
    public class ItemTypesStorageManager : IItemTypesStorageManager
    {
        private readonly IUnitOfWork _uow;

        public ItemTypesStorageManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<ItemType>> GetAllAsync()
        {
            return (await _uow.ProductTypeRepository.GetAsync()).ToList();

        }
        public List<ItemType> GetAll()
        {
            List<ItemType> result = new List<ItemType>();

            Task.Run(async () =>
            {
                result = (await _uow.ProductTypeRepository.GetAsync()).ToList(); 
            }).Wait();

            return result;
        }

        public int Create(ItemType entity)
        {
            int result = 0;

            Task.Run(async () =>
            {
                result = await _uow.ProductTypeRepository.CreateAsync(entity);
            }).Wait();

            _uow.Commit();
            return result;

        }

        public int Update(ItemType entity)
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
