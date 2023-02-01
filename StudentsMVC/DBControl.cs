using Microsoft.Data.SqlClient;
using StudentsMVC.Models;

namespace StudentsMVC
{
    public class DBControl
    {
    string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Datalabs Student\\source\\repos\\StudentsMVC\\ConsoleApp1\\Students.mdf\";Integrated Security = True";
    SqlConnection _connection;

    public Student GetStudent(int index)
    {
      SqlCommand sql;
      _connection = new SqlConnection(ConnectionString);
      _connection.Open();
      string name;
      string lname;
      try
      {
        
        sql = new SqlCommand(String.Format("Select Name from Students where Id = {0}", index), _connection);
        name = sql.ExecuteScalar().ToString();
        sql = new SqlCommand(String.Format("Select LastName from Students where Id = {0}", index), _connection);
        lname = sql.ExecuteScalar().ToString();

        sql = new SqlCommand(String.Format("Select Grade from Students where Id = {0}", index), _connection);
      }
      catch
      {
        return new Student(-1, "Error", "Error", -1);
      }
      int grade;

      try
      {
        grade = (int)sql.ExecuteScalar();
      }
      catch
      {
        grade = 0;
      }

      return new Student(index, name, lname, grade);

    }

    public List<Student> GetStudents()
    {
      _connection = new SqlConnection(ConnectionString);
      _connection.Open();
      SqlCommand sql = new SqlCommand("Select count(*) from Students",_connection);


      int max = (int)sql.ExecuteScalar();

      List<Student> returnList = new List<Student>();

      for(int i = 0; i < max; i++)
      {
        sql = new SqlCommand(String.Format("Select Name from Students where Id = {0}", i+1), _connection);
        string name = sql.ExecuteScalar().ToString();
        sql = new SqlCommand(String.Format("Select LastName from Students where Id = {0}", i + 1), _connection);
        string lname = sql.ExecuteScalar().ToString();

        sql = new SqlCommand(String.Format("Select Grade from Students where Id = {0}", i + 1), _connection);

        int grade;

        try
        {
          grade = (int)sql.ExecuteScalar();
        }
        catch
        {
          grade = 0;
        }

        returnList.Add(new Student(i + 1, name, lname, grade));
      }

      return returnList;
    }
    }
}
