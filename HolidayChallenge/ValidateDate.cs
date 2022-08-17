using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaysChallenge
{
    public class ValidateDate
    {

        //Set DueDate in a BussinessDay
        public static DateTime BusinessDayValidation(DateTime date)
        {
            int monday = 1;
            int friday = 5;
            //var holidays = Holiday.GetNationalHolidayList(date.Year);
            bool isNotBusinessDay = ((int)date.DayOfWeek >= monday 
                && (int)date.DayOfWeek <= friday);
            //bool isNotHoliday = !holidays.Contains(date);
            //if (isNotHoliday && isNotBusinessDay)
            //    return date;
            var holidaysList = Holiday.GetNationalHolidayByYear(date.Year);
            var isHoliday = holidaysList.Find(x => x.Date.Equals(date));
            if (isHoliday == null && isNotBusinessDay)
                return date;

            var newDate = date.AddDays(1);
            return BusinessDayValidation(newDate);
        }
    }    
}
