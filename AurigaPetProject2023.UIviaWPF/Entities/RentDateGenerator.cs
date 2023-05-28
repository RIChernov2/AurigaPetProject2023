//using AurigaPetProject2023.UIviaWPF.Entities.Interfaces;
//using System;

//namespace AurigaPetProject2023.UIviaWPF.Entities
//{
//    public class RentDateGenerator : IRentDateGenerator
//    {
//        public RentDatesInfo GetRentDatesInfo(RentWeekLength rentLength)
//        {
//            RentDatesInfo rentDatesInfo = new RentDatesInfo();
//            rentDatesInfo.StartDate = DateTime.Now;
//            //int addDaysCount = rentLength switch
//            //{
//            //    RentWeekLength.One => 7,
//            //    RentWeekLength.Two => 14,
//            //    _ => throw new Exception("Передан неучтенный вавриант срока аренды")

//            //};

//            int addDaysCount = ((byte)rentLength) * 7;

//            rentDatesInfo.EndDate = rentDatesInfo.StartDate
//                .AddDays(addDaysCount);

//            return rentDatesInfo;
//        }
//    }
//}
