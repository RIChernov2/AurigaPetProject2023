using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers.Interfaces;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Managers
{
    public class DisabledInfoStorageManager: IDisabledInfoStorageManager
    {
        private readonly IUnitOfWork _uow;
        public DisabledInfoStorageManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public int Create(DisabledInfo entity)
        {
            int result = 0;

            Task.Run(async () =>
            {
                result = await _uow.DisabledInfoRepository.CreateAsync(entity);
            }).Wait();

            _uow.Commit();
            return result;
        }
    }
}
