using AurigaPetProject2023.UIviaWPF.Entities.Interfaces;
using System;

namespace AurigaPetProject2023.UIviaWPF.Entities
{
    public class RentDateGenerator : IRentDateGenerator
    {
        public RentDatesInfo GetRentDatesInfo(RentLength rentLength)
        {
            RentDatesInfo rentDatesInfo = new RentDatesInfo();
            rentDatesInfo.StartDate = DateTime.Now;
            int addDaysCount = rentLength switch
            {
                RentLength.Week => 7,
                RentLength.TwoWeeks => 14,
                _ => throw new Exception("Передан неучтенный вавриант срока аренды")

            };

            rentDatesInfo.EndDate = rentDatesInfo.StartDate
                .AddDays(addDaysCount);

            return rentDatesInfo;
        }
    }
}
