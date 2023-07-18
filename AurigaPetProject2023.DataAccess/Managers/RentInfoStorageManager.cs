using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers.Interfaces;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Managers
{
    public class RentInfoStorageManager : IRentInfoStorageManager
    {
        private readonly IUnitOfWork _uow;
        public RentInfoStorageManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public int Create(RentInfo entity)
        {
            int result = 0;

            Task.Run(async () =>
            {
                result = await _uow.RentInfoRepository.CreateAsync(entity);
            }).Wait();

            _uow.Commit();
            return result;
        }
        public int Update(RentInfo entity)
        {
            int result = 0;

            Task.Run(async () =>
            {
                result = await _uow.RentInfoRepository.UpdateAsync(entity);
            }).Wait();

            _uow.Commit();
            return result;
        }
    }
}
