using AurigaPetProject2023.DataAccess.Dto;
using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Managers
{
    public class ItemStorageManager : IItemStorageManager
    {

        private readonly IUnitOfWork _uow;
        public ItemStorageManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //public List<Item> GetAll()
        //{
        //    List<Item> result = new List<Item>();

        //    //Task.Run(async () =>
        //    //{
        //    //    result = (await _uow.ProductRepository.GetAsync()).ToList();
        //    //}).Wait();


        //    // пробуем по-другому вызвать асинхронную, по идее там можно создать много дасков в разные таблицы, потом их всех подождать и выборку сделать

        //    Task resultTask = Task.Run(async () =>
        //    {
        //        result = (await _uow.ItemRepository.GetAsync()).ToList();
        //    });
        //    Task.WaitAll(resultTask);

        //    return result;
        //}

        //public List<ItemWithStatus> GetItemsWithStatus()
        //{
        //    List<ItemWithStatus> result = null;

        //    Task.Run(async () =>
        //    {
        //        result = (await _uow.ItemRepository.GetItemsWithStatusAsync()).ToList();
        //    }).Wait();

        //    return result;
        //}


        public int Create(Item entity)
        {
            int result1 = 0;
            int result2 = 0;
            bool isUnique = false;

            Task.Run(async () =>
            {
                result1 = await _uow.ItemRepository.CreateAsync(entity);
                isUnique = (await _uow.ItemTypeRepository.GetAsync(entity.ItemTypeID)).IsUnique;

                //if(isUnique)
                //{
                //    int lastId = _uow.ItemRepository.GetLastId();
                //    //lastId = 0;
                //    result2 = await _uow.ItemRepository.CreateUniqueIdAsync(lastId);
                //}
                
            }).Wait();

            if (isUnique)
            {
                int lastId = _uow.ItemRepository.GetLastId();
                //lastId = 11; // тест отката транзакции и работы constrain-ов уникальности и foreign key
                Task.Run(async () =>
                {
                    result2 = await _uow.ItemRepository.CreateUniqueIdAsync(lastId);
                }).Wait();

            }


            _uow.Commit();

            return result1 + result2;
        }
        public List<ItemWithDisableInfo> GetDisabled()
        {
            List<ItemWithDisableInfo> result = new List<ItemWithDisableInfo>();

            Task resultTask = Task.Run(async () =>
            {
                result = (await _uow.ItemRepository.GetDisabledAsync()).ToList();
            });
            Task.WaitAll(resultTask);

            return result;
        }
        public List<ItemWithRepairingInfoInfo> GetRepairing()
        {
            List<ItemWithRepairingInfoInfo> result = new List<ItemWithRepairingInfoInfo>();

            Task resultTask = Task.Run(async () =>
            {
                result = (await _uow.ItemRepository.GetRepairingAsync()).ToList();
            });
            Task.WaitAll(resultTask);

            return result;
        }
        public List<Item> GetAvailiable()
        {
            List<Item> result = new List<Item>();

            Task resultTask = Task.Run(async () =>
            {
                result = (await _uow.ItemRepository.GetAvailiableAsync()).ToList();
            });
            Task.WaitAll(resultTask);

            return result;
        }
        public List<ItemWithRentInfo> GetInRent()
        {
            List<ItemWithRentInfo> result = new List<ItemWithRentInfo>();

            Task resultTask = Task.Run(async () =>
            {
                result = (await _uow.ItemRepository.GetInRentAsync()).ToList();
            });
            Task.WaitAll(resultTask);

            return result;
        }
    }
}
