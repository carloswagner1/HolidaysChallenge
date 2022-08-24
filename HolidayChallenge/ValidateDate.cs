using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaysChallenge
{
    public class ValidateDate
    {
        public static List<DateTime> DueDateList(DateTime dateInput, int numberOfInstallments)
        {
            var businessDateList = new List<DateTime>();
            //var holidays = Holiday.GetNationalHolidayList(date.Year);
            var holidayByPeriodList = Holiday.GetHolidayByPeriod(dateInput, 
                dateInput.AddMonths(numberOfInstallments + 1));

            int x = 0;
            while (x < numberOfInstallments)
            {
                dateInput = dateInput.AddMonths(1);
                var dueDate = BusinessDayValidation(dateInput, holidayByPeriodList);
                businessDateList.Add(dueDate);
                x++;
            }
            return businessDateList;
        }

        public static DateTime BusinessDayValidation(DateTime date, List<Holiday> holidayByPeriodList)
        {
            int monday = 1;
            int friday = 5;
           
            bool isNotBusinessDay = ((int)date.DayOfWeek >= monday
                && (int)date.DayOfWeek <= friday);
            //bool isNotHoliday = !holidays.Contains(date);
            //if (isNotHoliday && isNotBusinessDay)
            //    return date;
            //var holidaysList = Holiday.GetNationalHolidayByYear(date.Year);
            var isHoliday = holidayByPeriodList.Find(x => x.Date.Equals(date));
            if (isHoliday == null && isNotBusinessDay)
                return date;

            var newDate = date.AddDays(1);
            return BusinessDayValidation(newDate, holidayByPeriodList);
        } 
    }    
}
