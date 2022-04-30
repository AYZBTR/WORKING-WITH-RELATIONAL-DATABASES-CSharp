using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_LAST_TASK4
{
    class Program
    {
        static void Main(string[] args)
        {
            int NMB;
            bool value;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter your Choice: ");
            Console.WriteLine("\nEnter 1: If you want to show all available information");
            Console.WriteLine("\nEnter 2: If you want to Add information");
            Console.WriteLine("\nEnter 3: If you want to update information.");
            Console.WriteLine("\nEnter 4: If you want to delete information.");
            Console.WriteLine("\nEnter 5: If you want to do nothing");
            Console.ResetColor();

            string connectionString = @"Data Source=(Localdb)\mssqllocaldb;Initial Catalog= Dentist; Integrated Security= true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("\nEnter your Choice:");
                    Console.ResetColor();

                    string received = Console.ReadLine();
                    while (!int.TryParse(received, out NMB) || (NMB != 1) && (NMB != 2) && (NMB != 3) && (NMB != 4) && (NMB != 5))
                    {
                        Console.Write("\nNot Valid...Try Again: ");
                        received = Console.ReadLine();
                    }

                    switch (NMB)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("You choose to show all the data");
                            Console.ResetColor();
                            try
                            {
                                sqlConnection.Open();
                                Dentist dentists = new Dentist();
                                List<Dentist> AllDentist = dentists.GetAllDentists(sqlConnection);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            sqlConnection.Close();
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("You have chosen to add some data...");
                            Console.ResetColor();
                            try
                            {
                                sqlConnection.Open();
                                Dentist addDentists = new Dentist();
                                addDentists.PlaceDentist(addDentists, sqlConnection);
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine(ex.Message);
                            }
                            sqlConnection.Close();
                            break;

                        case 3:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("You have chosen to update some data...");
                            Console.ResetColor();
                            try
                            {
                                sqlConnection.Open();
                                Dentist update = new Dentist();
                                update.Reform(update, sqlConnection);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);

                            }
                            sqlConnection.Close();
                            break;

                        case 4:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("You have chosen to Delete some data...");
                            Console.ResetColor();
                            try
                            {
                                sqlConnection.Open();
                                Dentist delDentist = new Dentist();
                                delDentist.RemoveDentist(delDentist, sqlConnection);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);

                            }
                            sqlConnection.Close();
                            break;

                        case 5:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("You have chosen to do nothing. Program ends here. Thank you...");
                            Console.ResetColor();
                            value = false;
                            return;
                            break;

                    }

                } while (value = true);

        }
}   }

