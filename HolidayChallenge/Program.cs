﻿
using System;
using System.Collections.Generic;
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

            Console.WriteLine("Informe a data-base a ser pesquisada: ");
            
            DateTime dateInput;

            if (!DateTime.TryParse(Console.ReadLine(), out dateInput))
            {
                Console.WriteLine("Data Inválida.");
                return;
            }
            
            Console.WriteLine("\nInforma a quantidade de parcelas: ");
            int numberOfInstallment;
            if (!int.TryParse(Console.ReadLine(), out numberOfInstallment))
            {
                Console.WriteLine("Número de Parcelas Inválido.");
                return;
            }
            
            //fazer a lógica do main, validando as datas das parcelas
            List<DateTime> DueDateList = new List<DateTime>();
            
            int x = 0;
            while (x < numberOfInstallment){
                dateInput = dateInput.AddMonths(1);
                var dueDate = ValidateDate.BusinessDayValidation(dateInput);
                DueDateList.Add(dueDate);                
                x++;
            }
            Console.WriteLine("\nDatas de vencimento");
            foreach (var dueDate in DueDateList)
            {
                Console.WriteLine(formatDate(dueDate));
            }

            ////DateTime List Solution
            //var holidays = Holiday.GetNationalHolidayList(dateInput.Year);

            //if (holidays.Contains(dateInput))
            //{
            //    Console.WriteLine("A data informada é feriado. :)");
            //}
            //else
            //{
            //    Console.WriteLine("A data informada não é feriado. :(");
            //}

            ////Holiday List Solution
            //var holidaysList = Holiday.GetNationalHolidayByYear(dateInput.Year);

            //Console.WriteLine();

            //Console.WriteLine("Lista de feriados: ");
            //holidaysList.ForEach(x => Console.WriteLine($"{formatDate(x.Date)} - {x.HolidayName}"));



            //Console.WriteLine();

            //var isHoliday = holidaysList.Find(x => x.Date.Equals(dateInput));
            //Console.WriteLine(isHoliday);
            //if (isHoliday == null)
            //{
            //    Console.WriteLine($"A data informada ({formatDate(dateInput)}) não é feriado. :(");
            //}
            //else
            //{
            //    Console.WriteLine($"A data informada informada " +
            //        $"({formatDate(isHoliday.Date)}) é feriado!!! :) - " +
            //        $"{isHoliday.HolidayName}");
            //}
        }
    }
}
