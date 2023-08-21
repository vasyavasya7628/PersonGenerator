using System.Text.Json;
using Bogus;

namespace PersonGenerator;

public static class Program
{
    public static void Main()
    {
        List<Person> persons = GenerateRandomPersons(10000);
        string json = JsonSerializer.Serialize(persons,
            new JsonSerializerOptions { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        string programDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(programDirectory, "Persons.json");
        File.WriteAllText(filePath, json);
        persons.Clear();
    }


    static List<Person> GenerateRandomPersons(int count)
    {
        var faker = new Faker();

        List<Person> persons = new List<Person>();

        for (int i = 0; i < count; i++)
        {
            Person person = new Person
            {
                CreditCardNumbers = new[] { faker.Finance.CreditCardNumber() },
                Age = faker.Random.Int(18, 80),
                Phones = new[] { faker.Phone.PhoneNumber() },
                BirthDate = faker.Date.Past().ToUniversalTime().ToFileTimeUtc(),
                Salary = faker.Random.Double(1000, 10000),
                IsMarried = faker.Random.Bool(),
                Gender = faker.PickRandom<Gender>(),
                Children = GenerateRandomChildren(faker)
            };


            persons.Add(person);
        }

        return persons;
    }


    static Child[] GenerateRandomChildren(Faker faker)
    {
        int childCount = faker.Random.Int(0, 3);

        List<Child> children = new List<Child>();

        for (int i = 0; i < childCount; i++)
        {
            Child child = new Child
            {
                Id = i + 1,
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                BirthDate = faker.Date.Past(10, DateTime.Now.AddYears(-18)).ToUniversalTime().ToFileTimeUtc(),
                Gender = faker.PickRandom<Gender>()
            };

            children.Add(child);
        }

        return children.ToArray();
    }
}