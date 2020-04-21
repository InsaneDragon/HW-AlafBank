using System;
using System.Data;
using System.Data.SqlClient;

namespace AlafBank
{
    class Program
    {
        private static int ID { get; set; }
        private static int score { get; set; }
        private static string creditstatus { get; set; }
        private static bool work { get; set; }
        private static bool isAdmin { get; set; }
        private static bool Isregistered { get; set; }
        static void Main(string[] args)
        {
        }

        static Account Registration(SqlConnection con)
        {
            System.Console.Write("Write you PhoneNumber(It will be your login):");
            string PhoneNumber = Console.ReadLine();
            System.Console.Write("Write you FirstName:");
            string FirstName = Console.ReadLine();
            System.Console.Write("Write you SecondName:");
            string SecondName = Console.ReadLine();
            System.Console.Write("Write you MiddleName:");
            string MiddleName = Console.ReadLine();
            System.Console.Write("Write your Year of Birth:");
            string BirthDate = Console.ReadLine();
            System.Console.Write("Create Password:");
            string Password = Console.ReadLine();
            System.Console.Write("Confirm Password:");
            string Confirm = Console.ReadLine();
            Account account = new Account();
            while (Password != Confirm)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Confirmation is incorrect!");
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.Write("Create Password:");
                Password = Console.ReadLine();
                System.Console.Write("Confirm Password:");
                Confirm = Console.ReadLine();
            }
            try
            {
                Console.Clear();
                {
                    account.Login = int.Parse(PhoneNumber);
                    account.Password = Password;
                    account.FirstName = FirstName;
                    account.SecondName = SecondName;
                    account.MiddleName = MiddleName;
                    account.BirthDate = BirthDate;
                };
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Your Account was added successfully");
                Console.ForegroundColor = ConsoleColor.White;
                Isregistered = true;
                con.Open();
                string command = string.Format($"select * from Account where Login={account.Login}");
                SqlCommand com = new SqlCommand(command, con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Isregistered = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("This Login already exists!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("You wrote incorrect information! Registration was failed");
                Console.ForegroundColor = ConsoleColor.White;
            }
            return (account);
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
