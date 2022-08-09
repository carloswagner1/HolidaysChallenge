using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaysChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<DateTime, string> formatDate = (date) =>
                String.Format("{0:D2}/{1:D2}/{2:D4}", date.Day, date.Month, date.Year);

            Console.WriteLine("Informe a data a ser pesquisada: ");

            var dateInput = Convert.ToDateTime(Console.ReadLine());
            //DateTime List Solution
            var holidays = NationalHolidays.GetNationalHolidayList(dateInput.Year);

            if (holidays.Contains(dateInput))
            {
                Console.WriteLine("A data informada é feriado. :)");
            }
            else
            {
                Console.WriteLine("A data informada não é feriado. :(");
            }

            //Holiday List Solution
            var holidaysList = NationalHolidays.GetNationalHolidayByYear(dateInput.Year);
            Console.WriteLine();

            Console.WriteLine("Lista de feriados: ");
            foreach (var holiday in holidaysList)
            {
                Console.WriteLine($"{formatDate(holiday.date)} - {holiday.holidayName}");
            }

            Console.WriteLine();

            var isHoliday = holidaysList.SingleOrDefault(holiday => holiday.date.Equals(dateInput));

            if (isHoliday == null)
            {
                Console.WriteLine($"A data informada ({formatDate(dateInput)}) não é feriado. :(");
            }
            else
            {
                Console.WriteLine($"A data informada informada " +
                    $"({formatDate(isHoliday.date)}) é feriado!!! :) - " +
                    $"{isHoliday.holidayName}");
            }
        }
    }
}
