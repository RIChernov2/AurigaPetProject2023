using AurigaPetProject2023.DataAccess.Helpers;
using FluentMigrator;
using System;

namespace AurigaPetProject2023.DataAccess.Migrations
{
    [Migration(99999999999999)]
    public class InitialDataMigration : Migration
    {
        public override void Up()
        {
            AddProductTypes();
            AddProducts();
            AddUnderRepairProducts();
            AddDisabledProducts();
            AddUsers();

        }

        public override void Down()
        {
        }

        private void AddProductTypes()
        {
            Insert.IntoTable("ProductTypes")
                .Row(new { Name = "Нож", Unique = "0" })
                .Row(new { Name = "Фонарь", Unique = "false" })
                .Row(new { Name = "Топор", Unique = "false" })
                .Row(new { Name = "Гамак", Unique = "1" })
                .Row(new { Name = "Палатка", Unique = "true" })
                .Row(new { Name = "Теннисные ракетки", Unique = "false" })
                .Row(new { Name = "Спальный мешок", Unique = "false" });
        }
        private void AddProducts()
        {
            Insert.IntoTable("Products")
                .Row(new { ProductType_ID = "1", Description = "Нож перочинный" })
                .Row(new { ProductType_ID = "2", Description = "Фонарь" })
                .Row(new { ProductType_ID = "3", Description = "Двуручный" })
                .Row(new { ProductType_ID = "4", Description = "Гамак детский" })
                .Row(new { ProductType_ID = "5", Description = "Двуспальная" })
                .Row(new { ProductType_ID = "6", Description = "Профессиональные" })
                .Row(new { ProductType_ID = "7", Description = "До минус 10" })

                .Row(new { ProductType_ID = "1", Description = "Охотничий" })
                .Row(new { ProductType_ID = "2", Description = "Мощный, аккумуляторный" })
                .Row(new { ProductType_ID = "3", Description = "Топорик" })
                .Row(new { ProductType_ID = "4", Description = "Гамак" })
                .Row(new { ProductType_ID = "5", Description = "Одноместная" })
                .Row(new { ProductType_ID = "6", Description = "Ракетки, Китай" })
                .Row(new { ProductType_ID = "7", Description = "До минус 12" })

                .Row(new { ProductType_ID = "1", Description = "Универсальный" })
                .Row(new { ProductType_ID = "2", Description = "Аккумуляторный" })
                .Row(new { ProductType_ID = "3", Description = "Топорик" })
                .Row(new { ProductType_ID = "4", Description = "В комплекте с покрывалом" })
                .Row(new { ProductType_ID = "5", Description = "Походная" })
                .Row(new { ProductType_ID = "6", Description = "Ракетки" })
                .Row(new { ProductType_ID = "7", Description = "Премиум, морозостойкий" })

                .Row(new { ProductType_ID = "1", Description = "Нож перочинный" })
                .Row(new { ProductType_ID = "2", Description = "Фонарь" })
                .Row(new { ProductType_ID = "3", Description = "Топорик" })
                .Row(new { ProductType_ID = "4", Description = "Гамак" })
                .Row(new { ProductType_ID = "5", Description = "Одноместная" })
                .Row(new { ProductType_ID = "6", Description = "Ракетки, Китай" })
                .Row(new { ProductType_ID = "7", Description = "Премиум, морозостойкий" });
        }
        private void AddUnderRepairProducts()
        {
            Insert.IntoTable("UnderRepairProducts")
                .Row(new { Product_ID = "22", Start_Date = DateTime.Now.AddDays(-215), Reason = "Перегорела лампочка",
                    End_Date = DateTime.Now.AddDays(-212), ResultDescription = "Лампочка была заменена"})
                .Row(new { Product_ID = "9", Start_Date = DateTime.Now.AddDays(-150), Reason = "Батареи не даржат",
                    End_Date = DateTime.Now.AddDays(-145), ResultDescription = "Заменены батарейки"})
                .Row(new { Product_ID = "7", Start_Date = DateTime.Now.AddDays(-60), Reason = "Скомкался материал",
                    End_Date = DateTime.Now.AddDays(-55), ResultDescription = "Проблема устранена"})
                .Row(new { Product_ID = "27", Start_Date = DateTime.Now.AddDays(-55), Reason = "Сломалась ручка",
                    End_Date = DateTime.Now.AddDays(-47), ResultDescription = "Исправлено"})
                .Row(new { Product_ID = "14", Start_Date = DateTime.Now.AddDays(-35), Reason = "Спальник уронили в костер",
                    End_Date = DateTime.Now.AddDays(-27), ResultDescription = "Списано, восстановлению не подлежит"})
                .Row(new { Product_ID = "5", Start_Date = DateTime.Now.AddDays(-30), Reason = "Прожгли крышу углем",
                    End_Date = DateTime.Now.AddDays(-24), ResultDescription = "Установлена заплатка"})
                .Row(new { Product_ID = "4", Start_Date = DateTime.Now.AddDays(-25), Reason = "Сгнил материал",
                    End_Date = DateTime.Now.AddDays(-15), ResultDescription = "Списано, восстановлению не подлежит"})
                .Row(new { Product_ID = "3", Start_Date = DateTime.Now.AddDays(-7), Reason = "Слетел с древка" })
                .Row(new { Product_ID = "11", Start_Date = DateTime.Now.AddDays(-6), Reason = "Требуется замена карабина" })
                .Row(new { Product_ID = "1", Start_Date = DateTime.Now.AddDays(-2), Reason = "Требуется замена ручки" })
                .Row(new { Product_ID = "15", Start_Date = DateTime.Now.AddDays(-2), Reason = "Появилась ржавчина" })
                .Row(new { Product_ID = "19", Start_Date = DateTime.Now.AddDays(-1), Reason = "Отклеилось покрытие" });
        }
        private void AddDisabledProducts()
        {
            Insert.IntoTable("DisabledProducts")
                .Row(new { Product_ID = "2", Date = DateTime.Now.AddDays(-55), Reason = "Потерян арендатором"})
                .Row(new { Product_ID = "14", Date = DateTime.Now.AddDays(-27), Reason = "Сожгли, восстановлению не подлежит"})
                .Row(new { Product_ID = "4", Date = DateTime.Now.AddDays(-15), Reason = "Сгнил материал, восстановлению не подлежит"});
        }
        private void AddUsers()
        {
            Insert.IntoTable("Users")
                .Row(new { Login_Name = "Manager", Password = $"{HashHelper.GetHash("123")}" })
                .Row(new { Login_Name = "User", Password = $"{HashHelper.GetHash("111")}" })
                .Row(new { Login_Name = "User2", Password = $"{HashHelper.GetHash("222")}" })
                .Row(new { Login_Name = "User3", Password = $"{HashHelper.GetHash("333")}" })
                .Row(new { Login_Name = "Boss", Phone = "+79261234567", Password = $"{HashHelper.GetHash("777")}" });

            Insert.IntoTable("RoleTypes")
                .Row(new { Name = "Администратор" })
                .Row(new { Name = "Менеджер" })
                .Row(new { Name = "Пользователь" });

            Insert.IntoTable("Roles")
                .Row(new { User_ID = "1", RoleType_ID = "2" })
                .Row(new { User_ID = "2", RoleType_ID = "3" })
                .Row(new { User_ID = "3", RoleType_ID = "3" })
                .Row(new { User_ID = "4", RoleType_ID = "3" })
                .Row(new { User_ID = "5", RoleType_ID = "1" })
                .Row(new { User_ID = "5", RoleType_ID = "2" });
        }
    }
}
