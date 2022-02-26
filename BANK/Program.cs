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

    class Credit
    {
        private
        double summ;
        double percentRate;
        DateTime dtStart;
        int creditTerm;
        double[,] paymentSchedule;
        bool isPaymentScheduleCalculated;

        public Credit(double summ, double percentRate, DateTime dtStart, int creditTerm)
        {
            this.summ = summ;
            this.percentRate = percentRate;
            this.dtStart = dtStart;
            this.creditTerm = creditTerm;
            isPaymentScheduleCalculated = false;
            paymentSchedule = new double[this.creditTerm, 5];
        }

        public void Calculate()
        {
            double tmpPercentRate = percentRate / 100 / 12;
            double tmpSumm = summ;
            double monthlyPayment = summ * tmpPercentRate /
                    (1 - Math.Pow((1 + tmpPercentRate), -creditTerm));

            for (int i = 0; i < creditTerm; i++)
            {
                //ежемесячный платеж
                paymentSchedule[i, 0] = monthlyPayment;

                //проценты за текущий месяц
                paymentSchedule[i, 1] = tmpSumm * tmpPercentRate;

                //погашение основного долга на сумму
                paymentSchedule[i, 2] = paymentSchedule[i, 0] - paymentSchedule[i, 1];

                //остаток долга
                tmpSumm -= paymentSchedule[i, 2];
                paymentSchedule[i, 3] = tmpSumm;
            }
            isPaymentScheduleCalculated = true;
        }

        public void ShowSchedule()
        {
            if (!isPaymentScheduleCalculated) return;
            DateTime currentDate = dtStart;

            Console.Clear();
            Console.WriteLine("{0, -14}{1, -14}{2, -14}{3, -14}{4, -14}", "Дата платежа", "Ежем. платеж", "Проценты", "Основной долг", "Остаток долга");
            for (int i = 0; i < creditTerm; i++)
            {
                currentDate = currentDate.AddMonths(1);
                Console.WriteLine
                    (
                        $"{currentDate.ToString("dd/MM/yyyy"),-14}" +
                        $"{paymentSchedule[i, 0].ToString("N2"),-14}" +
                        $"{paymentSchedule[i, 1].ToString("N2"),-14}" +
                        $"{paymentSchedule[i, 2].ToString("N2"),-14}" +
                        $"{paymentSchedule[i, 3].ToString("N2"),-14}"
                    );
            }
            Console.WriteLine("-------------------------------");
        }
    }
}
