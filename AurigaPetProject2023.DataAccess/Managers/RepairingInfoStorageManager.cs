using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers.Interfaces;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Managers
{
    public class RepairingInfoStorageManager : IRepairingInfoStorageManager
    {
        private readonly IUnitOfWork _uow;

        public RepairingInfoStorageManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public int Create(RepairingInfo entity)
        {
            int result = 0;

            Task.Run(async () =>
            {
                result = await _uow.RepairingInfoRepository.CreateAsync(entity);
            }).Wait();

            _uow.Commit();
            return result;
        }
        public int Update(RepairingInfo entity)
        {
            int result = 0;

            Task.Run(async () =>
            {
                result = await _uow.RepairingInfoRepository.UpdateAsync(entity);
            }).Wait();

            _uow.Commit();
            return result;
        }
    }
}
