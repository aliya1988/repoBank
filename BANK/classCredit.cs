using System;
using System.Collections.Generic;
using System.Text;

namespace BANK
{
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
