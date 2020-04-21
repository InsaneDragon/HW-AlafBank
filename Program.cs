using System;
using System.Data;
using System.Data.SqlClient;

namespace AlafBank
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Account
    {
        public int Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string BirthDate { get; set; }
    }
    class credit
    {
        public string Gender { get; set; }
        public string FamilyStatus { get; set; }
        public string Age { get; set; }
        public string Nationality { get; set; }
        public double Salary { get; set; }
        public string ClosedCredits { get; set; }
        public string ExpiredCredits { get; set; }
        public string TargetCredit { get; set; }
        public string CredidTerm { get; set; }
        public double Sum { get; set; }
    }
}
