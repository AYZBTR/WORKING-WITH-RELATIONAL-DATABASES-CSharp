using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAST_TASK4
{
    class Dentist
    {
      

        public int Id { get; set; }
        public string Name { get; set; }
        public string TelNum { get; set; }

        public List<Dentist> GetAllDentists(SqlConnection myConnection)
        {
            List<Dentist> list = new List<Dentist>();
            string queryString = "SELECT * FROM Dentist";
                SqlCommand command = new SqlCommand(queryString, myConnection);
            using (SqlDataReader reader= command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}, {1}, {2}", reader[0], reader[1], reader[2]));
                }
            }
            return list;
        }

        public void PlaceDentist(Dentist dentist, SqlConnection myConnection)
        {
            string insertNew = "INSERT INTO Dentist(Name, TelNum) VALUES(@newName, @newTelNum)";
            SqlCommand command = new SqlCommand(insertNew, myConnection);
            Console.Write("\nEnter Name:");
            string received = Console.ReadLine();
            SqlParameter sqlParameter = new SqlParameter
            {
                ParameterName = "@newName",
                Value = received,
                SqlDbType = System.Data.SqlDbType.NVarChar

            };
            command.Parameters.Add(sqlParameter);
            Console.Write("\nEnter Contact Number:");
            received = Console.ReadLine();
            sqlParameter = new SqlParameter
            {
                ParameterName = "@newTelNum",
                Value = received,
                SqlDbType = System.Data.SqlDbType.NVarChar
            };
            command.Parameters.Add(sqlParameter);
            int numberOfRows = command.ExecuteNonQuery();
            if (numberOfRows > 0)
                Console.WriteLine("Sucessfully inserted information.");
            else if (numberOfRows==0)
                Console.WriteLine("No such employee...");

            string queryString = "SELECT * FROM Dentist";
            command = new SqlCommand(queryString, myConnection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}, {1}, {2}", reader[0], reader[1], reader[2]));
                }
            }

        }
       
            public void RemoveDentist(Dentist dentist, SqlConnection myConnection)
        {
            string remove = "DELETE FROM Dentist WHERE Name=@dName";
            SqlCommand command = new SqlCommand(remove, myConnection);
            Console.Write("\nEnter Name:");
            string received = Console.ReadLine();
            SqlParameter sqlParameter = new SqlParameter
            {
                ParameterName = "@dName",
                Value = received,
                SqlDbType = System.Data.SqlDbType.NVarChar

            };
            command.Parameters.Add(sqlParameter);
            int numberOfRows = command.ExecuteNonQuery();
            if (numberOfRows > 0)
                Console.WriteLine("Successfully Removed the information.");
            else if (numberOfRows == 0)
                Console.WriteLine("No such employee...");

            Console.WriteLine("After removing the information:");
            string queryString = "SELECT * FROM Dentist";
            command = new SqlCommand(queryString, myConnection);
            using (SqlDataReader reader= command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}, {1}, {2}", reader[0], reader[1], reader[2]));
                }
            }
            
        }

        public void Reform(Dentist dentist, SqlConnection myConnection)
        {
            
            string modify = "UPDATE Dentist SET TelNum=@newTelNum WHERE Name=@dName";

            SqlCommand command = new SqlCommand(modify, myConnection);

            Console.Write("\nEnter Doctor Name: ");
            string received = Console.ReadLine();
            SqlParameter sqlParameter = new SqlParameter
            {
                ParameterName = "@dName",
                Value = received,
                SqlDbType = System.Data.SqlDbType.NVarChar
            };


            Console.Write("\nEnter updated contact details:");
            received = Console.ReadLine();

            command.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter
            {
                ParameterName = "@newTelNum",
                Value = received,
                SqlDbType = System.Data.SqlDbType.NVarChar
            };
            command.Parameters.Add(sqlParameter);

            int numberOfRows = command.ExecuteNonQuery();
            if (numberOfRows > 0)
                Console.WriteLine("Successfully updated information.");
            else if (numberOfRows == 0)
                Console.WriteLine("No such employee in the company.");

            Console.WriteLine("After possibly updating information:");
            string queryString = "SELECT * FROM Dentist";
            command = new SqlCommand(queryString, myConnection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}, {1}, {2}", reader[0], reader[1], reader[2]));
                }
            }

        }


    }
}

