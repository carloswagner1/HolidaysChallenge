using System.Collections.Generic;
using System.Globalization;

namespace HolidaysChallenge
{
    public class Holiday
    {
        public DateTime Date { get; set; }
        public int HolidayValue { get; set; }
        public string? HolidayName { get; set; }

        //List Holiday Solution
        public static List<Holiday> GetHolidayByPeriod(DateTime initialDate, DateTime finalDate)
        {
            var initialYear = initialDate.Year;
            var finalYear = finalDate.Year;
            var holidayByYear = new List<Holiday>();
            var holidayByPeriod = new List<Holiday>();
            while (initialYear <= finalYear)
            {                
                holidayByYear.AddRange(GetNationalHolidayByYear(initialYear));
                initialYear++;                
            }
            holidayByPeriod = holidayByYear.FindAll(x => x.Date > initialDate && x.Date < finalDate);
            return holidayByPeriod;
        }
        public static List<Holiday> GetNationalHolidayByYear(int year)
        {
            //CultureInfo culture = CultureInfo.InstalledUICulture;

            //check system interface language
            CultureInfo culture = CultureInfo.CurrentUICulture;
            Dictionary<int, string> holidayNames = GetHolidayNames(culture.Name);
            
            //Fixed holiday 
            var newYearDay = new Holiday
            {
                Date = new DateTime(year, 1, 1),
                HolidayName = holidayNames[1]
            };
            var tiradentesDay = new Holiday
            {
                Date = new DateTime(year, 4, 21),
                HolidayName = holidayNames[5]
            };
            var laborDay = new Holiday
            {
                Date = new DateTime(year, 5, 1),
                HolidayName = holidayNames[6]
            };
            var independenceDay = new Holiday
            {
                Date = new DateTime(year, 9, 7),
                HolidayName = holidayNames[8]
            };
            var nossaSenhoraDay = new Holiday
            {
                Date = new DateTime(year, 10, 12),
                HolidayName = holidayNames[9]
            };
            var allSoulsDay = new Holiday
            {
                Date = new DateTime(year, 11, 2),
                HolidayName = holidayNames[10]
            };
            var proclamationRepublicDay = new Holiday
            {
                Date = new DateTime(year, 11, 15),
                HolidayName = holidayNames[11]
            };
            var christmasDay = new Holiday
            {
                Date = new DateTime(year, 12, 25),
                HolidayName = holidayNames[12]
            };
            //mobile holiday
            var easterDay = new Holiday
            {
                Date = CalculateEasterDay(year),
                HolidayName = holidayNames[4]
            };
            var carnivalDay = new Holiday
            {
                Date = easterDay.Date.AddDays(-47),
                HolidayName = holidayNames[2]
            };
            var corpusChristiDay = new Holiday
            {
                Date = easterDay.Date.AddDays(60),
                HolidayName = holidayNames[7]
            };
            var godsFridayDay = new Holiday
            {
                Date = easterDay.Date.AddDays(-2),
                HolidayName = holidayNames[3]
            };
            //create HolidayList
            var holidayList = new List<Holiday>();
            holidayList.Add(newYearDay);
            holidayList.Add(carnivalDay);
            holidayList.Add(godsFridayDay);
            holidayList.Add(easterDay);
            holidayList.Add(tiradentesDay);
            holidayList.Add(laborDay);
            holidayList.Add(corpusChristiDay);
            holidayList.Add(independenceDay);
            holidayList.Add(nossaSenhoraDay);
            holidayList.Add(allSoulsDay);
            holidayList.Add(proclamationRepublicDay);
            holidayList.Add(christmasDay);
            return holidayList;
        }
        public static Dictionary<int, string> GetHolidayNames(string language)
        {
            if(language == "pt-BR")
            {
                Dictionary<int, string> portuguese = new Dictionary<int, string>()
                {
                    {1, "Confraternização Universal"},
                    {2, "Carnaval"},
                    {3, "Sexta-Feira Santa"},
                    {4, "Pascoa"},
                    {5, "Tiradentes"},
                    {6, "Dia do Trabalho"},
                    {7, "Corpus Christi"},
                    {8, "Dia da Independência do Brasil"},
                    {9, "Dia de Nossa Senhora Aparecida"},
                    {10, "Dia de Finados"},
                    {11, "Dia da Proclamação da República"},
                    {12, "Natal"}
                };
                return portuguese;
            }
            else
            {
                Dictionary<int, string> defaultLanguage = new Dictionary<int, string>()
                {
                    {1, "New Year Day"},
                    {2, "Carnival" },
                    {3, "Gods Friday Day"},
                    {4, "Easter"},
                    {5, "Tiradentes Day"},
                    {6, "Labor Day"},
                    {7, "Corpus Christi"},
                    {8, "Independence Day"},
                    {9, "Nossa Senhora Aparecida Day"},
                    {10, "All Soul's Day"},
                    {11, "Proclamation Republic Day"},
                    {12, "Christmas"}
                };
                return defaultLanguage;
            }
        }
        //List DateTime Solution        
        public static List<DateTime> GetNationalHolidayList(int year)
        {
            //fixed holiday
            var newYearDay = new DateTime(year, 1, 1);       //Ano novo
            var tiradentesDay = new DateTime(year, 4, 21);   //Tiradentes
            var laborDay = new DateTime(year, 5, 1);         //Dia do Trabalho
            var independenceDay = new DateTime(year, 9, 7);  //Dia da Independencia
            var nossaSenhoraDay = new DateTime(year, 10, 12);//Dia de Nossa Senhora Aparecida 
            var allSoulsDay = new DateTime(year, 11, 2);     //Dia de Finados
            var proclamationRepublicDay = new DateTime(year, 11, 15); //Proclamação da República
            var christmasDay = new DateTime(year, 12, 25);   //Natal
            //mobile Holiday
            var easterDay = CalculateEasterDay(year);        //Páscoa
            var carnivalDay = easterDay.AddDays(-47);        //Carnaval
            var corpusChristiDay = easterDay.AddDays(60);    //Cospus Christi
            var godsFridayDay = easterDay.AddDays(-2);       //friday-Feira Santa
            //create holidayList
            var holidayList = new List<DateTime>();
            holidayList.Add(newYearDay);
            holidayList.Add(carnivalDay);
            holidayList.Add(godsFridayDay);
            holidayList.Add(easterDay);
            holidayList.Add(tiradentesDay);
            holidayList.Add(laborDay);
            holidayList.Add(corpusChristiDay);
            holidayList.Add(independenceDay);
            holidayList.Add(nossaSenhoraDay);
            holidayList.Add(allSoulsDay);
            holidayList.Add(proclamationRepublicDay);
            holidayList.Add(christmasDay);
            return holidayList;
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
