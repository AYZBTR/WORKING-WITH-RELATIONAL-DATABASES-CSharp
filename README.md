# WORKING-WITH-RELATIONAL-DATABASES-CSharp

To give you a kick-start, use the scripts from Learn to create database Dentist (if you do not have it already – it is the same as in previous task). 

This is a continuation of the previous task. This time make your solution strongly typed. Add class
class Dentist
{
        public int Id { get; set; }
        public string Name { get; set; }
        public string TelNum { get; set; }
}
Implement class instance methods:

public List<Dentist> GetAllDentists(SqlConnection myConnection)
public void InsertDentist(Dentist dentist, SqlConnection myConnection)
public void DeleteDentist(Dentist dentist, SqlConnection myConnection)
public void UpdateDentist(Dentist dentist, SqlConnection myConnection)

…and test that they work: 


1. Who are the dentists available in the dentist station?

2. Add one more dentist to table Dentist.

3. The phone number of dentist Gyro Gearloose has changed.Implement the change to table Dentist.

4. Unfortunately, by now Gyro has left the Company. Remove him from table Dentist.
