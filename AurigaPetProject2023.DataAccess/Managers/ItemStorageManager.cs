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

        public List<Item> GetAll()
        {
            List<Item> result = new List<Item>();

            //Task.Run(async () =>
            //{
            //    result = (await _uow.ProductRepository.GetAsync()).ToList();
            //}).Wait();


            // пробуем по-другому вызвать асинхронную, по идее там можно создать много дасков в разные таблицы, потом их всех подождать и выборку сделать

            Task resultTask = Task.Run(async () =>
            {
                result = (await _uow.ProductRepository.GetAsync()).ToList();
            });
            Task.WaitAll(resultTask);

            return result;
        }


    }
}
