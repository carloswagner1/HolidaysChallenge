using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaysChallenge
{
    public class Holiday
    {
        public DateTime Date { get; set; }
        public string? HolidayName { get; set; }
    }
    public class ValidateDate
    {

        //Set DueDate in a BussinessDay
        public static DateTime BusinessDayValidation(DateTime date)
        {
            int monday = 1;
            int friday = 5;
            //var holidays = GetNationalHolidayList(date.Year);
            bool isNotBusinessDay = ((int)date.DayOfWeek >= monday 
                && (int)date.DayOfWeek <= friday);
            //bool isNotHoliday = !holidays.Contains(date);
            //if (isNotHoliday && isNotBusinessDay)
            //    return date;
            var holidaysList = GetNationalHolidayByYear(date.Year);
            var isHoliday = holidaysList.Find(x => x.Date.Equals(date));
            if (isHoliday == null && isNotBusinessDay)
                return date;

            var newDate = date.AddDays(1);
            return BusinessDayValidation(newDate);
        }
        //List DateTime Solution
        public static List<DateTime> GetNationalHolidayList(int year)
        {
            //fixed holidays
            var newYearDay = new DateTime(year, 1, 1);       //Ano novo
            var tiradentesDay = new DateTime(year, 4, 21);   //Tiradentes
            var laborDay = new DateTime(year, 5, 1);         //Dia do Trabalho
            var independenceDay = new DateTime(year, 9, 7);  //Dia da Independencia
            var nossaSenhoraDay = new DateTime(year, 10, 12);//Dia de Nossa Senhora Aparecida 
            var allSoulsDay = new DateTime(year, 11, 2);     //Dia de Finados
            var proclamationRepublicDay = new DateTime(year, 11, 15); //Proclamação da República
            var christmasDay = new DateTime(year, 12, 25);   //Natal
            //mobile Holidays
            var easterDay = CalculateEasterDay(year);        //Páscoa
            var carnivalDay = easterDay.AddDays(-47);        //Carnaval
            var corpusChristiDay = easterDay.AddDays(60);    //Cospus Christi
            var godsFridayDay = easterDay.AddDays(-2);       //friday-Feira Santa

            var holidaysList = new List<DateTime>();

            holidaysList.Add(newYearDay);
            holidaysList.Add(carnivalDay);
            holidaysList.Add(godsFridayDay);
            holidaysList.Add(easterDay);
            holidaysList.Add(tiradentesDay);
            holidaysList.Add(laborDay);
            holidaysList.Add(corpusChristiDay);
            holidaysList.Add(independenceDay);
            holidaysList.Add(nossaSenhoraDay);
            holidaysList.Add(allSoulsDay);
            holidaysList.Add(proclamationRepublicDay);
            holidaysList.Add(christmasDay);

            return holidaysList;
        }
        //List Holiday Solution
        public static List<Holiday> GetNationalHolidayByYear(int year)
        {


            //fixed holidays
            var newYearDay = new Holiday
            {
                Date = new DateTime(year, 1, 1),
                HolidayName = "Confraternização Universal"
            };
            var tiradentesDay = new Holiday
            {
                Date = new DateTime(year, 4, 21),
                HolidayName = "Tiradentes"
            };
            var laborDay = new Holiday
            {
                Date = new DateTime(year, 5, 1),
                HolidayName = "Dia do Trabalho"
            };
            var independenceDay = new Holiday
            {
                Date = new DateTime(year, 9, 7),
                HolidayName = "Dia da Indenpendência do Brasil"
            };
            var nossaSenhoraDay = new Holiday
            {
                Date = new DateTime(year, 10, 12),
                HolidayName = "Dia de Nossa Senhora Aparecida"
            };
            var allSoulsDay = new Holiday
            {
                Date = new DateTime(year, 11, 2),
                HolidayName = "Dia de Finados"
            };
            var proclamationRepublicDay = new Holiday
            {
                Date = new DateTime(year, 11, 15),
                HolidayName = "Dia da Proclamação da República"
            };
            var christmasDay = new Holiday
            {
                Date = new DateTime(year, 12, 25),
                HolidayName = "Natal"
            };

            //mobile holidays
            var easterDay = new Holiday
            {
                Date = CalculateEasterDay(year),
                HolidayName = "Dia de Páscoa"
            };
            var carnivalDay = new Holiday
            {
                Date = easterDay.Date.AddDays(-47),
                HolidayName = "Carnaval"
            };
            var corpusChristiDay = new Holiday
            {
                Date = easterDay.Date.AddDays(60),
                HolidayName = "Corpus Christi"
            };
            var godsFridayDay = new Holiday
            {
                Date = easterDay.Date.AddDays(-2),
                HolidayName = "friday-Feira Santa"
            };

            var holidaysList = new List<Holiday>();

            holidaysList.Add(newYearDay);
            holidaysList.Add(carnivalDay);
            holidaysList.Add(godsFridayDay);
            holidaysList.Add(easterDay);
            holidaysList.Add(tiradentesDay);
            holidaysList.Add(laborDay);
            holidaysList.Add(corpusChristiDay);
            holidaysList.Add(independenceDay);
            holidaysList.Add(nossaSenhoraDay);
            holidaysList.Add(allSoulsDay);
            holidaysList.Add(proclamationRepublicDay);
            holidaysList.Add(christmasDay);


            return holidaysList;
        }
        public static DateTime CalculateEasterDay(int year)
        {
            /*Algoritmo de Gauss*/

            var metonicCycle = year % 19; // Ciclo metônico.
            var leapDays = year % 4; //Dias bissextos
            var extraDayOfLeadYears = year % 7;
            //Para obter o número aúreo, é necessário obter os cálculos de dois auxiliares
            var century = Math.Floor((double)year / 100);
            var auxiliar = ((13 + 8 * century) / 25);
            var goldenNumber = (15 - auxiliar + century - (century / 4)) % 30;

            var leapDaysdifference = (4 + century - (century / 4)) % 7;
            var daysToEasterFullMoon = (19 * metonicCycle + goldenNumber) % 30;
            var easterFullMoonToNextSunday = (leapDaysdifference + 2 * leapDays + 4 * extraDayOfLeadYears +
                6 * daysToEasterFullMoon) % 7;
            var days = (int)(22 + daysToEasterFullMoon + easterFullMoonToNextSunday);

            if ((daysToEasterFullMoon == 29) && (easterFullMoonToNextSunday == 6))
            {
                var easterDate = new DateTime(year, 4, 19);
                return easterDate;
            }
            else if ((daysToEasterFullMoon == 28) && (easterFullMoonToNextSunday == 6))
            {
                DateTime easterDate = new DateTime(year, 4, 18);
                return easterDate;
            }
            else
            {
                if (days > 31)
                {
                    DateTime easterDate = new DateTime(year, 4, (days - 31));
                    return easterDate;
                }
                else
                {
                    DateTime easterDate = new DateTime(year, 3, days);
                    return easterDate;
                }
            }
        }
    }    
}
