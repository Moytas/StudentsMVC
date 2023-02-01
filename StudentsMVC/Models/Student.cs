namespace StudentsMVC.Models
{
  public class Student
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Grade { get; set; }
    
    public Student(int id, string name,string lname,int grade)
    {
      Id = id;
      Name = name;
      LastName = lname;
      Grade = grade;
    }

  }
}
