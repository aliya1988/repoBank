using System;
using System.Collections.Generic;
using System.Text;

namespace BANK
{
    class CreditDocument
    {
        private Credit credit;
        private Client client;
        public CreditDocument(double summ, double percentRate, DateTime dtStart, int creditTerm, string clientFirstName, string clientSecondName)
        {
            client = new Client(clientFirstName, clientSecondName);
            credit = new Credit(summ, percentRate, dtStart, creditTerm);
        }
        public void CalculateCredit()
        {
            credit.Calculate();//расчет графика

        }
        public void ShowSchedule()
        {
            Console.Clear();
            Console.WriteLine($"Индивидуальный график платежей по кредиту для клиента {client.GetName()}:"); ;
            credit.ShowSchedule();//показать график платежей
        }
    }
}
