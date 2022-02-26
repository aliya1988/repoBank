using System;

namespace BANK
{
    class Program
    {
        static void Main(string[] args)
        {
            string val;
            double summ = 0; //сумма кредита
            double percentRate = 0;//проценты

            DateTime dtStart = DateTime.Parse("2022-01-01");
            int creditTerm = 0;//срок кредита
            Console.WriteLine("Введите сумму кредита");
            val = Console.ReadLine();
            summ = Convert.ToDouble(val);

            Console.WriteLine("Введите % ставку");
            val = Console.ReadLine();
            percentRate = Convert.ToDouble(val);

            Console.WriteLine("Введите дату выдачи кредита");
            val = Console.ReadLine();
            dtStart = Convert.ToDateTime(val);

            Console.WriteLine("Введите срок кредита в месяцах");
            val = Console.ReadLine();
            creditTerm = Convert.ToInt32(val);

            Credit newCredit = new Credit(summ, percentRate, dtStart, creditTerm);
            newCredit.Calculate();//расчет графика
            newCredit.ShowSchedule();//показать график платежей
            Console.Write("Нажмите любую клавишу для завершения программы...");
            Console.ReadKey();
        }
    }

}
