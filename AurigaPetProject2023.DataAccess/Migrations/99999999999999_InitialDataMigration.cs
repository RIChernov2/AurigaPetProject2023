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
            AddItemTypes();
            AddItems();
            AddItemUniqueInfos();
            AddRepairingInfos();
            AddDisabledItems();
            AddUsers();
            AddRentInfo();
            AddDiscountInfos();
            AddBannedInfos();

        }

        public override void Down()
        {
        }

        private void AddItemTypes()
        {
            Insert.IntoTable("ItemTypes")
                .Row(new { Name = "Нож", Is_Unique = "0" })
                .Row(new { Name = "Фонарь", Is_Unique = "false" })
                .Row(new { Name = "Топор", Is_Unique = "false" })
                .Row(new { Name = "Гамак", Is_Unique = "1" })
                .Row(new { Name = "Палатка", Is_Unique = "true" })
                .Row(new { Name = "Теннисные ракетки", Is_Unique = "false" })
                .Row(new { Name = "Спальный мешок", Is_Unique = true });
        }
        private void AddItems()
        {
            Insert.IntoTable("Items")
                .Row(new { ItemType_ID = "1", Description = "Нож перочинный" })
                .Row(new { ItemType_ID = "2", Description = "Фонарь" })
                .Row(new { ItemType_ID = "3", Description = "Двуручный" })
                .Row(new { ItemType_ID = "4", Description = "Гамак детский" })
                .Row(new { ItemType_ID = "5", Description = "Двуспальная" })
                .Row(new { ItemType_ID = "6", Description = "Профессиональные" })
                .Row(new { ItemType_ID = "7", Description = "До минус 10" })

                .Row(new { ItemType_ID = "1", Description = "Охотничий" })
                .Row(new { ItemType_ID = "2", Description = "Мощный, аккумуляторный" })
                .Row(new { ItemType_ID = "3", Description = "Топорик" })
                .Row(new { ItemType_ID = "4", Description = "Гамак" })
                .Row(new { ItemType_ID = "5", Description = "Одноместная" })
                .Row(new { ItemType_ID = "6", Description = "Ракетки, Китай" })
                .Row(new { ItemType_ID = "7", Description = "До минус 12" })

                .Row(new { ItemType_ID = "1", Description = "Универсальный" })
                .Row(new { ItemType_ID = "2", Description = "Аккумуляторный" })
                .Row(new { ItemType_ID = "3", Description = "Топорик" })
                .Row(new { ItemType_ID = "4", Description = "В комплекте с покрывалом" })
                .Row(new { ItemType_ID = "5", Description = "Походная" })
                .Row(new { ItemType_ID = "6", Description = "Ракетки" })
                .Row(new { ItemType_ID = "7", Description = "Премиум, морозостойкий" })

                .Row(new { ItemType_ID = "1", Description = "Нож перочинный" })
                .Row(new { ItemType_ID = "2", Description = "Фонарь" })
                .Row(new { ItemType_ID = "3", Description = "Топорик" })
                .Row(new { ItemType_ID = "4", Description = "Гамак" })
                .Row(new { ItemType_ID = "5", Description = "Одноместная" })
                .Row(new { ItemType_ID = "6", Description = "Ракетки, Китай" })
                .Row(new { ItemType_ID = "7", Description = "Премиум, морозостойкий" })

                .Row(new { ItemType_ID = "1", Description = "Нож перочинный" })
                .Row(new { ItemType_ID = "2", Description = "Фонарик детский" })
                .Row(new { ItemType_ID = "3", Description = "Двуручный" })
                .Row(new { ItemType_ID = "4", Description = "Гамак большой" })
                .Row(new { ItemType_ID = "5", Description = "Туристическая 6 мест" })
                .Row(new { ItemType_ID = "6", Description = "Профессиональные" })
                .Row(new { ItemType_ID = "7", Description = "Хладостойкий" })

                .Row(new { ItemType_ID = "1", Description = "Нож перочинный" })
                .Row(new { ItemType_ID = "2", Description = "Фонарь" })
                .Row(new { ItemType_ID = "3", Description = "Топорик" })
                .Row(new { ItemType_ID = "4", Description = "Гамак детский" })
                .Row(new { ItemType_ID = "5", Description = "Двуспальная" })
                .Row(new { ItemType_ID = "6", Description = "С резиновым покрытием" })
                .Row(new { ItemType_ID = "7", Description = "Легкий летний" });
        }

        private void AddItemUniqueInfos()
        {
            Insert.IntoTable("ItemUniqueInfos")
                .Row(new { Item_ID = "4" })
                .Row(new { Item_ID = "5" })
                .Row(new { Item_ID = "7" })

                .Row(new { Item_ID = "11" })
                .Row(new { Item_ID = "12" })
                .Row(new { Item_ID = "14" })

                .Row(new { Item_ID = "18" })
                .Row(new { Item_ID = "19" })
                .Row(new { Item_ID = "21" })

                .Row(new { Item_ID = "25" })
                .Row(new { Item_ID = "26" })
                .Row(new { Item_ID = "28" })

                .Row(new { Item_ID = "32" })
                .Row(new { Item_ID = "33" })
                .Row(new { Item_ID = "35" })

                .Row(new { Item_ID = "39" })
                .Row(new { Item_ID = "40" })
                .Row(new { Item_ID = "42" });
        }
        private void AddRepairingInfos()
        {
            Insert.IntoTable("RepairingInfos")
                .Row(new { Item_ID = "22", Start_Date = DateTime.Now.AddDays(-215), Reason = "Перегорела лампочка",
                    End_Date = DateTime.Now.AddDays(-212), Result_Description = "Лампочка была заменена"})
                .Row(new { Item_ID = "9", Start_Date = DateTime.Now.AddDays(-150), Reason = "Батареи не даржат",
                    End_Date = DateTime.Now.AddDays(-145), Result_Description = "Заменены батарейки"})
                .Row(new { Item_ID = "7", Start_Date = DateTime.Now.AddDays(-60), Reason = "Скомкался материал",
                    End_Date = DateTime.Now.AddDays(-55), Result_Description = "Проблема устранена"})
                .Row(new { Item_ID = "27", Start_Date = DateTime.Now.AddDays(-55), Reason = "Сломалась ручка",
                    End_Date = DateTime.Now.AddDays(-47), Result_Description = "Исправлено"})
                .Row(new { Item_ID = "14", Start_Date = DateTime.Now.AddDays(-35), Reason = "Спальник уронили в костер",
                    End_Date = DateTime.Now.AddDays(-27), Result_Description = "Списано, восстановлению не подлежит"})
                .Row(new { Item_ID = "5", Start_Date = DateTime.Now.AddDays(-30), Reason = "Прожгли крышу углем",
                    End_Date = DateTime.Now.AddDays(-24), Result_Description = "Установлена заплатка"})
                .Row(new { Item_ID = "4", Start_Date = DateTime.Now.AddDays(-25), Reason = "Сгнил материал",
                    End_Date = DateTime.Now.AddDays(-15), Result_Description = "Списано, восстановлению не подлежит"})
                .Row(new { Item_ID = "3", Start_Date = DateTime.Now.AddDays(-7), Reason = "Слетел с древка" })
                .Row(new { Item_ID = "11", Start_Date = DateTime.Now.AddDays(-6), Reason = "Требуется замена карабина" })
                .Row(new { Item_ID = "1", Start_Date = DateTime.Now.AddDays(-2), Reason = "Требуется замена ручки" })
                .Row(new { Item_ID = "15", Start_Date = DateTime.Now.AddDays(-2), Reason = "Появилась ржавчина" })
                .Row(new { Item_ID = "19", Start_Date = DateTime.Now.AddDays(-1), Reason = "Отклеилось покрытие" });
        }
        private void AddDisabledItems()
        {
            Insert.IntoTable("DisabledInfos")
                .Row(new { Item_ID = "2", Date = DateTime.Now.AddDays(-75), Reason = "Потерян арендатором" })
                .Row(new { Item_ID = "14", Date = DateTime.Now.AddDays(-47), Reason = "Сожгли, восстановлению не подлежит" })
                .Row(new { Item_ID = "4", Date = DateTime.Now.AddDays(-35), Reason = "Сгнил материал, восстановлению не подлежит" })

                .Row(new { Item_ID = "31", Date = DateTime.Now.AddDays(-33), Reason = "Украли" })
                .Row(new { Item_ID = "39", Date = DateTime.Now.AddDays(-25), Reason = "Сгнил" })
                .Row(new { Item_ID = "41", Date = DateTime.Now.AddDays(-15), Reason = "Потерян" });
        }
        private void AddUsers()
        {
            Insert.IntoTable("Users")
                .Row(new { Login_Name = "User1", Password = $"{HashHelper.GetHash("111")}" })
                .Row(new { Login_Name = "User2", Password = $"{HashHelper.GetHash("222")}" })
                .Row(new { Login_Name = "User3", Password = $"{HashHelper.GetHash("333")}" })
                .Row(new { Login_Name = "User4", Password = $"{HashHelper.GetHash("444")}" })
                .Row(new { Login_Name = "User5", Password = $"{HashHelper.GetHash("555")}" })
                .Row(new { Login_Name = "User6", Password = $"{HashHelper.GetHash("666")}" })
                .Row(new { Login_Name = "User7", Password = $"{HashHelper.GetHash("777")}" })
                .Row(new { Login_Name = "User8", Password = $"{HashHelper.GetHash("888")}" })
                .Row(new { Login_Name = "User9", Password = $"{HashHelper.GetHash("999")}" })
                .Row(new { Login_Name = "User10", Password = $"{HashHelper.GetHash("000")}" })
                .Row(new { Login_Name = "User11", Password = $"{HashHelper.GetHash("111")}" })
                .Row(new { Login_Name = "User12", Password = $"{HashHelper.GetHash("222")}" })
                .Row(new { Login_Name = "User13", Password = $"{HashHelper.GetHash("333")}" })
                .Row(new { Login_Name = "User14", Password = $"{HashHelper.GetHash("444")}" })
                .Row(new { Login_Name = "User15", Password = $"{HashHelper.GetHash("555")}" })
                .Row(new { Login_Name = "User16", Password = $"{HashHelper.GetHash("666")}" })
                .Row(new { Login_Name = "User17", Password = $"{HashHelper.GetHash("777")}" })
                .Row(new { Login_Name = "User18", Password = $"{HashHelper.GetHash("888")}" })
                .Row(new { Login_Name = "User19", Password = $"{HashHelper.GetHash("999")}" })
                .Row(new { Login_Name = "User20", Password = $"{HashHelper.GetHash("000")}" })

                .Row(new { Login_Name = "Manager", Password = $"{HashHelper.GetHash("123")}" })
                .Row(new { Login_Name = "Boss", Phone = "+79261234567", Password = $"{HashHelper.GetHash("777")}" });

            Insert.IntoTable("RoleTypes")
                .Row(new { Name = "Администратор" })
                .Row(new { Name = "Менеджер" })
                .Row(new { Name = "Пользователь" });

            Insert.IntoTable("Roles")
                .Row(new { User_ID = "1", RoleType_ID = "3" })
                .Row(new { User_ID = "2", RoleType_ID = "3" })
                .Row(new { User_ID = "3", RoleType_ID = "3" })
                .Row(new { User_ID = "4", RoleType_ID = "3" })
                .Row(new { User_ID = "5", RoleType_ID = "3" })
                .Row(new { User_ID = "6", RoleType_ID = "3" })
                .Row(new { User_ID = "7", RoleType_ID = "3" })
                .Row(new { User_ID = "8", RoleType_ID = "3" })
                .Row(new { User_ID = "9", RoleType_ID = "3" })
                .Row(new { User_ID = "10", RoleType_ID = "3" })
                .Row(new { User_ID = "11", RoleType_ID = "3" })
                .Row(new { User_ID = "12", RoleType_ID = "3" })
                .Row(new { User_ID = "13", RoleType_ID = "3" })
                .Row(new { User_ID = "14", RoleType_ID = "3" })
                .Row(new { User_ID = "15", RoleType_ID = "3" })
                .Row(new { User_ID = "16", RoleType_ID = "3" })
                .Row(new { User_ID = "17", RoleType_ID = "3" })
                .Row(new { User_ID = "18", RoleType_ID = "3" })
                .Row(new { User_ID = "19", RoleType_ID = "3" })
                .Row(new { User_ID = "20", RoleType_ID = "3" })


                .Row(new { User_ID = "21", RoleType_ID = "2" })
                .Row(new { User_ID = "22", RoleType_ID = "1" })
                .Row(new { User_ID = "22", RoleType_ID = "2" });
        }
        private void AddRentInfo()
        {
            Insert.IntoTable("RentInfos")
                .Row(new { User_ID = "3", Item_ID = "2", Cost = 1200, IsPaid = true,
                    Start_Date = DateTime.Now.AddDays(-65), Expire_Date = DateTime.Now.AddDays(-58),
                    End_Date = DateTime.Now.AddDays(-58)})
                .Row(new { User_ID = "5", Item_ID = "18", Cost = 1200, IsPaid = true,
                    Start_Date = DateTime.Now.AddDays(-64), Expire_Date = DateTime.Now.AddDays(-57),
                    End_Date = DateTime.Now.AddDays(-57)})
                .Row(new { User_ID = "2", Item_ID = "27", Cost = 5000, IsPaid = true,
                    Start_Date = DateTime.Now.AddDays(-64), Expire_Date = DateTime.Now.AddDays(-57),
                    End_Date = DateTime.Now.AddDays(-57)})
                .Row(new { User_ID = "1", Item_ID = "20", Cost = 1000, IsPaid = true,
                    Start_Date = DateTime.Now.AddDays(-63), Expire_Date = DateTime.Now.AddDays(-56),
                    End_Date = DateTime.Now.AddDays(-55)})
                .Row(new { User_ID = "6", Item_ID = "13", Cost = 1000, IsPaid = true,
                    Start_Date = DateTime.Now.AddDays(-53), Expire_Date = DateTime.Now.AddDays(-46),
                    End_Date = DateTime.Now.AddDays(-46)})
                .Row(new { User_ID = "7", Item_ID = "14", Cost = 9000, IsPaid = true,
                    Start_Date = DateTime.Now.AddDays(-35), Expire_Date = DateTime.Now.AddDays(-28),
                    End_Date = DateTime.Now.AddDays(-27)})
                .Row(new { User_ID = "4", Item_ID = "24", Cost = 1000, IsPaid = true,
                    Start_Date = DateTime.Now.AddDays(-32), Expire_Date = DateTime.Now.AddDays(-25),
                    End_Date = DateTime.Now.AddDays(-26)})

                .Row(new { User_ID = "12", Item_ID = "41", Cost = 9000, IsPaid = true,
                    Start_Date = DateTime.Now.AddDays(-21), Expire_Date = DateTime.Now.AddDays(-14),
                    End_Date = DateTime.Now.AddDays(-15)})


                .Row(new { User_ID = "1", Item_ID = "6", Cost = 1000, IsPaid = true,
                    Start_Date = DateTime.Now.AddDays(-12), Expire_Date = DateTime.Now.AddDays(2)})
                .Row(new { User_ID = "1", Item_ID = "7", Cost = 2000, IsPaid = true,
                    Start_Date = DateTime.Now.AddDays(-15), Expire_Date = DateTime.Now.AddDays(-1)})
                .Row(new { User_ID = "13", Item_ID = "35", Cost = 2000, IsPaid = true,
                    Start_Date = DateTime.Now.AddDays(-16), Expire_Date = DateTime.Now.AddDays(-2)})
                .Row(new { User_ID = "13", Item_ID = "34", Cost = 1000, IsPaid = true,
                    Start_Date = DateTime.Now.AddDays(-11), Expire_Date = DateTime.Now.AddDays(3)})
                .Row(new { User_ID = "17", Item_ID = "32", Cost = 1000, IsPaid = false,
                    Start_Date = DateTime.Now.AddDays(-11), Expire_Date = DateTime.Now.AddDays(-4)})
                .Row(new { User_ID = "5", Item_ID = "25", Cost = 1000, IsPaid = false,
                    Start_Date = DateTime.Now.AddDays(-8), Expire_Date = DateTime.Now.AddDays(-1)})
                .Row(new { User_ID = "16", Item_ID = "37", Cost = 500, IsPaid = false,
                    Start_Date = DateTime.Now.AddDays(-6), Expire_Date = DateTime.Now.AddDays(1)})
                .Row(new { User_ID = "2", Item_ID = "9", Cost = 500, IsPaid = false,
                    Start_Date = DateTime.Now.AddDays(-6), Expire_Date = DateTime.Now.AddDays(1)})
                .Row(new { User_ID = "19", Item_ID = "30", Cost = 2000, IsPaid = false,
                    Start_Date = DateTime.Now.AddDays(-3), Expire_Date = DateTime.Now.AddDays(11)})
                .Row(new { User_ID = "20", Item_ID = "42", Cost = 3000, IsPaid = false,
                    Start_Date = DateTime.Now.AddDays(-2), Expire_Date = DateTime.Now.AddDays(12)})
                .Row(new { User_ID = "10", Item_ID = "16", Cost = 2000, IsPaid = false,
                    Start_Date = DateTime.Now.AddDays(-2), Expire_Date = DateTime.Now.AddDays(12)})
                .Row(new { User_ID = "9", Item_ID = "28", Cost = 3000, IsPaid = false,
                    Start_Date = DateTime.Now.AddDays(-1), Expire_Date = DateTime.Now.AddDays(13)});



        }

        private void AddDiscountInfos()
        {
            Insert.IntoTable("DiscountInfos")
                .Row(new { User_ID = "1", DiscountPercentage = "15" })
                .Row(new { User_ID = "2", DiscountPercentage = "10" })
                .Row(new { User_ID = "5", DiscountPercentage = "5" })

                .Row(new { User_ID = "13", DiscountPercentage = "10" })
                .Row(new { User_ID = "17", DiscountPercentage = "5" })
                .Row(new { User_ID = "20", DiscountPercentage = "5" });
        }

        private void AddBannedInfos()
        {
            Insert.IntoTable("BannedInfos")
                .Row(new { User_ID = "19", Date = DateTime.Now.AddDays(-28), Reason = "Украл инвентарь из магазина. Поймали по записям с камер." })
                .Row(new { User_ID = "12", Date = DateTime.Now.AddDays(-15), Reason = "Потерял инвентарь. Не хотел платить, напал на сотрудника." });
        }
    }
}
