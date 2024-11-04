using System;

public class Person
{
    // Приватні поля
    private string name;
    private DateTime birthYear;

    // Властивості тільки для читання
    public string Name
    {
        get { return name; }
    }

    public DateTime BirthYear
    {
        get { return birthYear; }
    }

    // Конструктор за замовчуванням
    public Person()
    {
        name = "Unknown";
        birthYear = DateTime.Now;
    }

    // Конструктор з двома параметрами
    public Person(string name, DateTime birthYear)
    {
        this.name = name;
        this.birthYear = birthYear;
    }

    // Метод для обчислення віку
    public int Age()
    {
        int age = DateTime.Now.Year - birthYear.Year;
        if (DateTime.Now.DayOfYear < birthYear.DayOfYear)
            age--;
        return age;
    }

    // Метод для введення даних про особу
    public void Input()
    {
        Console.Write("Enter name: ");
        name = Console.ReadLine();
        Console.Write("Enter birth year (yyyy): ");
        int year = int.Parse(Console.ReadLine());
        birthYear = new DateTime(year, 1, 1);
    }

    // Метод для зміни імені
    public void ChangeName(string newName)
    {
        name = newName;
    }

    // Метод ToString
    public override string ToString()
    {
        return $"Name: {name}, Age: {Age()}";
    }

    // Метод для виведення інформації про особу
    public void Output()
    {
        Console.WriteLine(ToString());
    }

    // Оператор рівності за іменем
    public static bool operator ==(Person p1, Person p2)
    {
        return p1.name == p2.name;
    }

    public static bool operator !=(Person p1, Person p2)
    {
        return !(p1 == p2);
    }

    // Переоприділення Equals та GetHashCode
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Person person = (Person)obj;
        return name == person.name;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення 6 об'єктів типу Person
        Person[] people = new Person[6];
        for (int i = 0; i < people.Length; i++)
        {
            people[i] = new Person();
            Console.WriteLine($"\nEnter details for person {i + 1}:");
            people[i].Input();
        }

        Console.WriteLine("\nPerson's names and ages:");
        foreach (var person in people)
        {
            int age = person.Age();
            Console.WriteLine($"Name: {person.Name}, Age: {age}");
            if (age < 16)
            {
                person.ChangeName("Very Young");
            }
        }

        Console.WriteLine("\nUpdated information about all persons:");
        foreach (var person in people)
        {
            person.Output();
        }

        Console.WriteLine("\nPersons with the same names:");
        for (int i = 0; i < people.Length; i++)
        {
            for (int j = i + 1; j < people.Length; j++)
            {
                if (people[i] == people[j])
                {
                    Console.WriteLine($"Person {i + 1} and Person {j + 1} have the same name.");
                    people[i].Output();
                    people[j].Output();
                }
            }
        }
    }
}