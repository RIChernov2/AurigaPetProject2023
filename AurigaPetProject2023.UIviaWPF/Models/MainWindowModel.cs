using AurigaPetProject2023.DataAccess.Entities;
using AurigaPetProject2023.DataAccess.Managers;
using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using AurigaPetProject2023.UIviaWPF.Entities;
using System.ComponentModel;
using System.Threading.Tasks;

namespace AurigaPetProject2023.UIviaWPF.Models
{
    public class MainWindowModel: BaseModel, INotifyPropertyChanged
    {
        private string _loginName;
        private string _password;
        public string LoginName
        {
            get { return _loginName; }
            set
            {
                _loginName = value;
                OnPropertyChanged(nameof(LoginName));
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public IUserLoginResponseInfo Login()
        {
            IUserLoginResponseInfo responseInfo;
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                UsersStorageManager repository = new UsersStorageManager(unitOfWork);
                UserLoginInfo loginInfo = new UserLoginInfo(_loginName, _password);
                var task = Task.Run(async () => await repository.GetUserForLoginAsync(loginInfo));
                task.Wait();
                responseInfo = task.Result;

            }
            return responseInfo;
        }
    }
}
