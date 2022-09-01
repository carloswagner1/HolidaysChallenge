using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HolidaysChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            // Função para formatar a data
            Func<DateTime, string> formatDate = (date) =>
                String.Format("{0:D2}/{1:D2}/{2:D4}", date.Day, date.Month, date.Year);

            ////Holidays List By Year (Example)
            //var holidaysList = Holiday.GetNationalHolidayByYear(2022);
            //foreach (var holiday in holidaysList)
            //{
            //    Console.WriteLine($"{formatDate(holiday.Date)} - {holiday.HolidayName}");
            //}
            //Console.WriteLine();

            //DueDate App
            Console.WriteLine("Informe a data-base a ser pesquisada: ");
            
            DateTime dateInput;

            while (!DateTime.TryParse(Console.ReadLine(), out dateInput))
            {
                Console.WriteLine("Data Inválida. \nInforme a data-base a ser pesquisada: ");
                
            }
            
            Console.WriteLine("\nInforma a quantidade de parcelas: ");
            int numberOfInstallments;
            while (!int.TryParse(Console.ReadLine(), out numberOfInstallments) || numberOfInstallments < 0)
            {
                Console.WriteLine("Número de Parcelas Inválido.\nInforma a quantidade de parcelas: ");                
            }

            //fazer a lógica do main, validando as datas das parcelas
            var DueDateList = ValidateDate.DueDateList(dateInput, numberOfInstallments);
            
            Console.WriteLine("\nData de vencimento das parcelas: ");
            foreach (var dueDate in DueDateList)
            {
                Console.WriteLine(formatDate(dueDate) + " - " + dueDate.DayOfWeek);
            }
        }
    }
}
