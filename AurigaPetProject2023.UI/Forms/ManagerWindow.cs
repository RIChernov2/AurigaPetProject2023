using AurigaPetProject2023.DataAccess.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurigaPetProject2023.UI
{
    public partial class ManagerWindowWF : Form
    {
        public ManagerWindowWF()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                //var types = await unitOfWork.ProductTypeRepository.GetAsync(new int[] { 1, 2, 3 });

                ////           // ТЕСТ
                ////public async Task<IReadOnlyList<TEntity>> GetAsync(IEnumerable<TArg> ids)
                ////{
                ////    return await _dbSet.Where(x => ids.Contains((TArg)x.GetType().GetProperty("Id").GetValue(x))).ToListAsync();
                ////}
                ///
                //var list = await unitOfWork.ProductTypeRepository.Ge

                var manager = new ItemTypesStorageManager(unitOfWork);
                //var list = await manager.GetAllAsync();
                var list2 = manager.GetAll();
            }
        }
    }
}
