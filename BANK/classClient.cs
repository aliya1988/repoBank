using System;
using System.Collections.Generic;
using System.Text;

namespace BANK
{
    class Client
    {
        private string firstName, secondName;
        public Client(string name, string secondName)
        {
            firstName = name;
            secondName = secondName;
        }
        public string GetName()
        {
            return $"{firstName} {secondName}";
        }
    }
}
