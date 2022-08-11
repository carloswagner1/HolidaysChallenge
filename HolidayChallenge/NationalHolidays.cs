using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaysChallenge
{
    public class Holiday
    {
        public DateTime date { get; set; }
        public string? holidayName { get; set; }
    }
    public class NationalHolidays
    {
        //List DateTime Solution
        public static List<DateTime> GetNationalHolidayList(int year)
        {

            var holidaysList = new List<DateTime>();
            var easterDate = CalculateEasterDay(year);
            var carnivalDate = CalculateCarnival(easterDate);
            var corpusChristiDate = CalculateCorpusChristi(easterDate);
            var godsFriday = CalculateGodsFriday(easterDate);

            holidaysList.Add(new DateTime(year, 1, 1));   //Ano novo 
            holidaysList.Add(new DateTime(year, 4, 21));  //Tiradentes
            holidaysList.Add(new DateTime(year, 5, 1));   //Dia do trabalho
            holidaysList.Add(new DateTime(year, 9, 7));   //Dia da Independência do Brasil
            holidaysList.Add(new DateTime(year, 10, 12)); //Nossa Senhora Aparecida
            holidaysList.Add(new DateTime(year, 11, 2));  //Finados
            holidaysList.Add(new DateTime(year, 11, 15)); //Proclamação da República
            holidaysList.Add(new DateTime(year, 12, 25)); //Natal
            holidaysList.Add(easterDate);                 //Páscoa
            holidaysList.Add(carnivalDate);               //Carnaval
            holidaysList.Add(corpusChristiDate);          //CorpusChristi
            holidaysList.Add(godsFriday);                 // Sexta-Feira Santa

            holidaysList.Sort();

            return holidaysList;
        }

        //List Holiday Solution
        public static List<Holiday> GetNationalHolidayByYear(int year)
        {
            //fixed holidays

            var easterDate = CalculateEasterDay(year);
            var carnivalDate = CalculateCarnival(easterDate);
            var corpusChristiDate = CalculateCorpusChristi(easterDate);
            var godsFridayDate = CalculateGodsFriday(easterDate);


            var holidaysList = new List<Holiday>
            {
                new Holiday {date = new DateTime(year, 1, 1), holidayName = "Confraternização Universal"},
                new Holiday {date = new DateTime(year, 4, 21), holidayName = "Tiradentes" },
                new Holiday {date = new DateTime(year, 5, 1), holidayName = "Dia do Trabalho"},
                new Holiday {date = new DateTime(year, 9, 7), holidayName = "Dia da Indenpendência do Brasil" },
                new Holiday {date = new DateTime(year, 10, 12), holidayName = "Dia de Nossa Senhora Aparecida" },
                new Holiday {date = new DateTime(year, 11, 2), holidayName = "Dia de Finados" },
                new Holiday {date = new DateTime(year, 11, 15), holidayName = "Dia da Proclamação da República" },
                new Holiday {date = new DateTime(year, 12, 25), holidayName = "Natal" },
                new Holiday {date = carnivalDate, holidayName = "Carnaval" },
                new Holiday {date = godsFridayDate, holidayName = "Sexta-Feira Santa" },
                new Holiday {date = easterDate, holidayName = "Dia de Páscoa" },
                new Holiday {date = corpusChristiDate, holidayName = "Corpus Christi" }
            };

            holidaysList = holidaysList.OrderBy(holiday => holiday.date).ToList();

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
                DateTime easterDate = new DateTime(year, 4, 19);
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

        public static DateTime CalculateCorpusChristi(DateTime easterDate)
        {
            var corpusChristiDate = easterDate.AddDays(60);
            return corpusChristiDate;
        }

        public static DateTime CalculateCarnival(DateTime easterDate)
        {
            var carnivalDate = easterDate.AddDays(-47);
            return carnivalDate;
        }

        public static DateTime CalculateGodsFriday(DateTime easterDate)
        {
            var godsFriday = easterDate.AddDays(-2);
            return godsFriday;
        }
    }

    
}
