using Steal_lab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steal_lab
{
    public class Hacker: Interface1
    {

        public string username = "securityGod82";
        private string password = "mySuperSecretPassw0rd";

        public string Password
        {
            get => password;
            set => password = value;
        }

        private int Id { get; set; }

        public double BankAccountBalance { get; private set; }

        public void DownloadAllBankAccountsInTheWorld()
        {
        }
    }
}
