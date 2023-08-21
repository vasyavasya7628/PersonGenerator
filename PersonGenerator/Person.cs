namespace PersonGenerator;

public class Person
{
    public string[] CreditCardNumbers { get; init; }
    public int Age { get; init; }
    public string[] Phones { get; set; }
    public long BirthDate { get; set; }
    public double Salary { get; set; }
    public bool IsMarried { get; set; }
    public Gender Gender { get; set; }
    public Child[] Children { get; set; }
}

public class Child
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long BirthDate { get; set; }
    public Gender Gender { get; set; }
}

public enum Gender
{
    Male,
    Female
}