using Labb1_Entity_Framework.Context;
using Labb1_Entity_Framework.Models;
using System;

namespace Labb1_Entity_Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext();

            Start();
            

            void Start()
            {
                Console.Clear();
                Console.WriteLine("Do you want to log in as \n-------------- \n1: Employee \n2: Admin ");
                try
                {
                    int UserInput = Convert.ToInt32(Console.ReadLine());

                    if (UserInput == 1)
                    {
                        LoginEmployee();
                    }
                    if (UserInput == 2)
                    {
                        LoginAdmin();
                    }
                    if (UserInput < 1 || UserInput > 2)
                    {
                        Console.WriteLine("Invalid option, please try again.");
                        Console.ReadKey();
                        Start();
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input, input must be a number. Press any Key to return to the menu.");
                    Console.ReadKey();
                    Start();
                }
            }

            void LoginEmployee()
            {
            Console.Clear();

            var employees = context.Employees;

            foreach (var item in employees)
            {

                Console.WriteLine(item.EmployeeId + " = " + item.FirstName + " " + item.LastName);

            }
            Console.WriteLine("Choose Employee");
            int pickedEmployee = Convert.ToInt32(Console.ReadLine());


            var employeeChosen = context.LeaveApplications;

         
                
            Console.WriteLine("Whats your reason for this leave?");
            string InputReason = Console.ReadLine();

            Console.WriteLine("Start date? (yyyy/MM/dd)");
            DateTime startDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("End date? (yyyy/MM/dd)");
            DateTime endDate = Convert.ToDateTime(Console.ReadLine());

            LeaveApplication leaves = new LeaveApplication()
            {
                Reason = InputReason,
                StartDate = startDate,
                EndDate = endDate,
                ForeignEmployeeId = pickedEmployee,
                CurrentDate = DateTime.Now
            };
            context.LeaveApplications.Add(leaves);
            context.SaveChanges();

            Console.WriteLine("You have successfully submitted one application for a leave.");
            
            }
            Console.ReadKey();
            Start();
           

            void LoginAdmin()
            {
                Console.Clear();
                Console.WriteLine("Welcome to Admin menu");
                Console.WriteLine("Specific persons History(1) or Monthly History(2)? Or press 3 to go back to the start. ");

                try
                {
                    int aInput = Convert.ToInt32(Console.ReadLine());

                    if (aInput == 1)
                    {
                        History();
                    }
                    if (aInput == 2)
                    {
                        Monthly();
                    }
                    if (aInput == 2)
                    {
                        Start();
                    }
                    if (aInput < 1 || aInput > 3)
                    {
                        Console.WriteLine("Invalid number please try again.");
                    }

                }
                catch
                {
                    Console.WriteLine("You must enter a number.. Please try again. ");
                }
            }

            
            void History()
            {
                var employees = context.Employees;

                foreach (var item in employees)
                {
                    Console.WriteLine(item.EmployeeId + " = " + item.FirstName + " " + item.LastName);
                }

                Console.WriteLine("Pick your employee: ");

                var historyInput = Convert.ToInt32(Console.ReadLine());
                var LeavesHistory = context.LeaveApplications;

                foreach (var item in LeavesHistory)
                {
                    if (item.ForeignEmployeeId == historyInput)
                    {
                        Console.WriteLine("Employee ID:" + item.ForeignEmployeeId + ", Reason: " + item.Reason + ", " + item.StartDate.Date.ToString("yyyy/MM/dd") + " - " + item.EndDate.Date.ToString("yyyy/MM/dd") + ", " + "Application made: " + item.CurrentDate.ToString());

                    }
                }
            Console.ReadKey();
            LoginAdmin();
            }
            

            void Monthly()
            {
                Console.WriteLine("What month (1-12)");
                int Month = Convert.ToInt32(Console.ReadLine());

                var MonthlyHistory = context.LeaveApplications;


                foreach (var item in MonthlyHistory)
                {
                    if ((item.StartDate.Month >= Month) && (item.EndDate.Month <= Month))
                    {
                        Console.WriteLine("Employee ID:" + item.ForeignEmployeeId + ", Reason:" + item.Reason + ", " + item.StartDate.Date.ToString("yyyy/MM/dd") + " - " + item.EndDate.Date.ToString("yyyy/MM/dd") );
                    }
                }
            Console.ReadKey();
            LoginAdmin();
            }
            
        }
    }
}


