using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

[Serializable]
public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Salary { get; set; }
}

class Program
{
    static void Main()
    {
        // Binary Serialization and Deserialization
        Employee employee = new Employee
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Salary = 50000.0
        };

        SerializeBinary(employee);
        Employee deserializedEmployeeBinary = DeserializeBinary();

        DisplayEmployeeDetails("Binary Deserialization", deserializedEmployeeBinary);

        // XML Serialization and Deserialization
        SerializeXml(employee);
        Employee deserializedEmployeeXml = DeserializeXml();

        DisplayEmployeeDetails("XML Deserialization", deserializedEmployeeXml);
        Console.ReadKey();
    }

    static void SerializeBinary(Employee employee)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream("F:/employee.bin", FileMode.Create))
        {
            formatter.Serialize(stream, employee);
        }
    }

    static Employee DeserializeBinary()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream("F:/employee.bin", FileMode.Open))
        {
            return (Employee)formatter.Deserialize(stream);
        }
    }

    static void SerializeXml(Employee employee)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Employee));
        using (FileStream stream = new FileStream("F:/employee.xml", FileMode.Create))
        {
            serializer.Serialize(stream, employee);
        }
    }

    static Employee DeserializeXml()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Employee));
        using (FileStream stream = new FileStream("F:/employee.xml", FileMode.Open))
        {
            return (Employee)serializer.Deserialize(stream);
        }
    }

    static void DisplayEmployeeDetails(string header, Employee employee)
    {
        Console.WriteLine($"--- {header} ---");
        Console.WriteLine($"ID: {employee.Id}");
        Console.WriteLine($"First Name: {employee.FirstName}");
        Console.WriteLine($"Last Name: {employee.LastName}");
        Console.WriteLine($"Salary: {employee.Salary}");
        Console.WriteLine();
    }
}
