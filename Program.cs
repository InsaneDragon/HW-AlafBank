using System;
using System.Data.SqlClient;
using System.Data;
namespace HW
{
    class Program
    {
        private static int ID { get; set; }
        private static int score { get; set; }
        private static string creditstatus { get; set; }
        private static bool work { get; set; }
        private static bool isAdmin { get; set; }
        private static bool Isregistered { get; set; }

        static void Main()
        {
            ID = 0;
            Isregistered = false;
            bool statuschoosed = false;
            isAdmin = false;
            work = true;
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=AlafDB;Integrated Security=True");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("Welcome to Bank Alaf");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choose your status");
            Console.WriteLine("1.Admin");
            Console.WriteLine("2.Guest");
            System.Console.Write("Status:");
            string stat = Console.ReadLine();
            if (stat == "1")
            {
                isAdmin = true;
                statuschoosed = true;
            }
            if (stat == "2") { statuschoosed = true; }
            while (statuschoosed == false)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Choose your status from list below!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1.Admin");
                Console.WriteLine("2.Guest");
                System.Console.Write("Status:");
                stat = Console.ReadLine();
                if (stat == "1")
                {
                    isAdmin = true;
                    statuschoosed = true;
                }
                if (stat == "2") { statuschoosed = true; }
            }
            while (work)
            {
                while (ID == 0 && work == true)
                {
                    Console.WriteLine();
                    System.Console.WriteLine("1.Register");
                    System.Console.WriteLine("2.Login");
                    System.Console.WriteLine("3.Quit");
                    Console.Write("Choice:");
                    string status = Console.ReadLine();
                    switch (status)
                    {
                        case "1":
                            {
                                Account acc = Registration(con);
                                while (Isregistered == false)
                                {
                                    acc = Registration(con);
                                }
                                if (Isregistered == true)
                                {
                                    con.Open();
                                    string insert = string.Format($"insert into Account(Login,Password,FirstName,SecondName,MiddleName,BirthDate,FinishedCredits,ExpiredCredits) values({acc.Login},'{acc.Password}','{acc.FirstName}','{acc.SecondName}','{acc.MiddleName}',{acc.BirthDate},0,0)");
                                    SqlCommand command = new SqlCommand(insert, con);
                                    SqlDataReader reader = command.ExecuteReader();
                                    con.Close();
                                }
                            }
                            break;
                        case "2":
                            {
                                ID = Sign(con);
                                if (ID != 0)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    System.Console.WriteLine("You Loged in successfully");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    System.Console.WriteLine("Incorrect Login or Password");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            break;
                        case "3":
                            {
                                work = false;
                                ID = 1;
                            }
                            break;
                    }
                }
                if (work == true)
                {
                    System.Console.WriteLine("1.Take credit");
                    System.Console.WriteLine("2.View binds");
                    System.Console.WriteLine("3.Grafik pogasheniya");
                    System.Console.WriteLine("4.Quit");
                    Console.Write("Choice:");
                    string choise = Console.ReadLine();
                    switch (choise)
                    {
                        case "1":
                            {
                                Console.Clear();
                                System.Console.Write("On what sum you want to take credit:");
                                double Sum = double.Parse(Console.ReadLine());
                                System.Console.WriteLine("Choose Gender");
                                System.Console.WriteLine("1.Male");
                                System.Console.WriteLine("2.FeMale");
                                System.Console.Write("Gender:");
                                string gender = Console.ReadLine();
                                Console.Clear();
                                System.Console.WriteLine("Choose Status");
                                System.Console.WriteLine("1.Single");
                                System.Console.WriteLine("2.Married");
                                System.Console.WriteLine("3.Divorced");
                                System.Console.WriteLine("4.Widower");
                                System.Console.Write("Status:");
                                string Status = Console.ReadLine();
                                Console.Clear();
                                System.Console.Write("Age:");
                                int Age = int.Parse(Console.ReadLine());
                                Console.Clear();
                                System.Console.WriteLine("Choose Nationality");
                                System.Console.WriteLine("1.Tajik");
                                System.Console.WriteLine("2.Foreigner");
                                System.Console.Write("Nationality:");
                                string Nationality = Console.ReadLine();
                                Console.Clear();
                                System.Console.Write("Salary:");
                                double Salary = double.Parse(Console.ReadLine());
                                Console.Clear();
                                System.Console.WriteLine("Choose Target of Credit");
                                System.Console.WriteLine("1.House equipment");
                                System.Console.WriteLine("2.Repair");
                                System.Console.WriteLine("3.Phone");
                                System.Console.WriteLine("4.Else");
                                System.Console.Write("Target:");
                                string CreditTarget = Console.ReadLine();
                                Console.Clear();
                                System.Console.WriteLine("Choose Credit DeadLine");
                                System.Console.WriteLine("1.6 month");
                                System.Console.WriteLine("2.9 month");
                                System.Console.WriteLine("3.12 month");
                                System.Console.WriteLine("4.24 month");
                                System.Console.Write("DeadLine:");
                                string DeadLine = Console.ReadLine();
                                credit credit = new credit();
                                if (gender == "1") { credit.Gender = "Male"; score++; }
                                if (gender == "2") { credit.Gender = "Female"; score += 2; }
                                if (Status == "1") { credit.FamilyStatus = "Single"; score++; }
                                if (Status == "2") { credit.FamilyStatus = "Married"; score += 2; }
                                if (Status == "3") { credit.FamilyStatus = "Divorced"; score++; }
                                if (Status == "4") { credit.FamilyStatus = "Widower"; score += 2; }
                                if (Age > 25 && Age < 36) { score++; }
                                if (Age > 35 && Age < 63) { score += 2; }
                                if (Age >= 63) { score++; }
                                if (Nationality == "1") { credit.Nationality = "Tajik"; score++; }
                                if (Nationality == "2") { credit.Nationality = "Foreigner"; }
                                credit.Sum = Sum;
                                if (Salary * 0.8 > Sum) { score += 4; }
                                if (Salary * 0.8 <= Sum && Salary * 1.5 > Sum) { score += 3; }
                                if (Salary * 1.5 <= Sum && Salary * 2.5 >= Sum) { score += 2; }
                                if (Salary * 2.5 < Sum) { score += 1; }
                                if (CreditTarget == "1") { credit.TargetCredit = "House equipment"; score += 2; }
                                if (CreditTarget == "2") { credit.TargetCredit = "Repair"; score += 1; }
                                if (CreditTarget == "3") { credit.TargetCredit = "Phone"; }
                                if (CreditTarget == "4") { credit.TargetCredit = "Else"; score -= 1; }
                                if (DeadLine == "1") { credit.ExpiredCredits = "6"; score++; }
                                if (DeadLine == "2") { credit.ExpiredCredits = "9"; score++; }
                                if (DeadLine == "3") { credit.ExpiredCredits = "12"; score++; }
                                if (DeadLine == "4") { credit.ExpiredCredits = "24"; score++; }
                                con.Open();
                                string insert1 = string.Format($"select * from Account where ID={ID}");
                                SqlCommand command1 = new SqlCommand(insert1, con);
                                SqlDataReader reader1 = command1.ExecuteReader();
                                int closedcredits = 0;
                                int expired = 0;
                                while (reader1.Read())
                                {
                                    closedcredits = int.Parse(reader1["FinishedCredits"].ToString());
                                    expired = int.Parse(reader1["ExpiredCredits"].ToString());
                                }
                                con.Close();
                                if (closedcredits == 0) score--;
                                if (closedcredits == 1 || closedcredits == 2) score++;
                                if (closedcredits >= 3) score += 2;
                                if (expired == 4) score--;
                                if (expired >= 5 && expired <= 7) score -= 2;
                                if (expired > 7) score -= 3;
                                credit.Salary = Salary;
                                Console.Clear();
                                if (score > 11) { creditstatus = "Accepted"; Console.ForegroundColor = ConsoleColor.Green; System.Console.WriteLine("Congratulations your credit was accepted"); Console.ForegroundColor = ConsoleColor.White; }
                                if (score <= 11) { creditstatus = "Declined"; Console.ForegroundColor = ConsoleColor.Red; System.Console.WriteLine("Your credit was declined! but you can try next time"); Console.ForegroundColor = ConsoleColor.White; }
                                con.Open();
                                string insert = string.Format($"insert into Credits(PersonID,Value,Status,Day,Month,Year,Gender,FamilyStatus,Nationality,Salary,CreditTarget,Term) values({ID},{credit.Sum},'{creditstatus}',{DateTime.Now.Day},{DateTime.Now.Month},{DateTime.Now.Year},'{credit.Gender}','{credit.FamilyStatus}','{credit.Nationality}',{credit.Salary},'{credit.TargetCredit}','{credit.ExpiredCredits}')");
                                SqlCommand command = new SqlCommand(insert, con);
                                SqlDataReader reader = command.ExecuteReader();
                                con.Close();
                            }
                            break;
                        case "3":
                            {
                                Console.Clear();
                                con.Open();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                System.Console.WriteLine("Your Credits");
                                Console.ForegroundColor = ConsoleColor.White;
                                string com = string.Format($"select * from Credits where PersonID={ID} and Status='Accepted'");
                                if (isAdmin == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    System.Console.WriteLine("Credits of every User");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    com = string.Format($"select * from Credits where Status='Accepted'");
                                }
                                SqlCommand command = new SqlCommand(com, con);
                                SqlDataReader reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    double valuepermonth = Math.Round(double.Parse(reader["Value"].ToString()) / int.Parse(reader["Term"].ToString()));
                                    System.Console.WriteLine($"You need to pay {valuepermonth} per month {reader["Term"].ToString()} monthes. Total:{reader["Value"].ToString()}");
                                }
                                con.Close();
                            }
                            break;
                        case "4":
                            {
                                work = false;
                            }
                            break;
                        case "2":
                            {
                                Console.Clear();
                                con.Open();
                                string insert = string.Format($"select * from Credits where PersonID={ID}");
                                if (isAdmin == true)
                                {
                                    insert = string.Format($"select * from Credits");
                                }
                                SqlCommand command = new SqlCommand(insert, con);
                                SqlDataReader reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    string Date = reader["Day"].ToString() + "-" + reader["Month"].ToString() + "-" + reader["Year"].ToString();
                                    System.Console.WriteLine($"ID:{reader["ID"]},Credit:{reader[2]},Status:{reader[3]},FamilyStatus:{reader["FamilyStatus"]},Nationality:{reader["Nationality"]},Salary:{reader["Salary"]},Target:{reader["CreditTarget"]},Term:{reader["Term"]}");
                                }
                                con.Close();
                            }
                            break;
                    }
                }
            }
            static int Sign(SqlConnection con)
            {
                Console.Clear();
                int ID = 0;
                System.Console.Write("Write you PhoneNumber:");
                string PhoneNumber = Console.ReadLine();
                System.Console.Write("Write you Password:");
                string Password = Console.ReadLine();
                Console.Clear();
                con.Open();
                try
                {
                    string insert = string.Format($"select * from Account where Login={PhoneNumber} and Password='{Password}'");
                    SqlCommand command = new SqlCommand(insert, con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ID = int.Parse(reader[0].ToString());
                        break;
                    }
                }
                catch (Exception ex)
                {
                }
                con.Close();
                return (ID);
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
}