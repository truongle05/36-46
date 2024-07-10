using System;
using System.Collections.Generic;
using System.Linq;

// a. Tạo lớp trừu tượng Person
public abstract class Person
{
    private string _name;
    private string _id;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string Id
    {
        get { return _id; }
        set { _id = value; }
    }
}

// b. Tạo interface Kpi
public interface Kpi
{
    float Kpi();
}

// c. Tạo lớp Student kế thừa Person và cài đặt Kpi
public class Student : Person, Kpi
{
    private string _department;
    public float Gpa { get; set; }

    public string Department
    {
        get { return _department; }
        set
        {
            if (value == "ICT" || value == "ECO")
            {
                _department = value;
            }
            else
            {
                throw new ArgumentException("Department must be either 'ICT' or 'ECO'.");
            }
        }
    }

    public Student(string name, string id, string department, float gpa)
    {
        Name = name;
        Id = id.Length == 8 && id.All(char.IsDigit) ? id : throw new ArgumentException("ID must be 8 numeric characters.");
        Department = department;
        Gpa = gpa;
    }

    public float Kpi()
    {
        return Gpa;
    }
}

// d. Khai báo obs trong hàm Main()
class Program
{
    static void Main(string[] args)
    {
        Person obs = null;

        try
        {
            // e. Cấp phát obs là Student với thông tin hợp lệ
            obs = new Student("Nguyễn Tiến Dũng", "12345678", "ICT", 3.5f);
            Console.WriteLine($"KPI: {((Student)obs).Kpi()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            // g. Cấp phát obs với thông tin không hợp lệ
            obs = new Student("Nguyễn Văn A", "12345", "ICT", 3.2f);  // Sai ID
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            obs = new Student("Nguyễn Văn B", "12345678", "ENG", 3.2f);  // Sai Department
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // h. Nhập danh sách sinh viên
        List<Person> list1 = new List<Person>();
        List<Person> list2 = new List<Person>();

        Console.WriteLine("Nhập danh sách sinh viên ngồi bàn 1 lớp 23IT5 (kết thúc nhập nếu nhập name là #):");
        while (true)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            if (name == "#") break;

            Console.Write("ID: ");
            string id = Console.ReadLine();

            Console.Write("Department: ");
            string department = Console.ReadLine();

            Console.Write("GPA: ");
            float gpa;
            if (!float.TryParse(Console.ReadLine(), out gpa))
            {
                Console.WriteLine("GPA phải là số.");
                continue;
            }

            try
            {
                list1.Add(new Student(name, id, department, gpa));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine("Nhập danh sách sinh viên ngồi bàn 2 lớp 23IT6 (kết thúc nhập nếu nhập name là #):");
        while (true)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            if (name == "#") break;

            Console.Write("ID: ");
            string id = Console.ReadLine();

            Console.Write("Department: ");
            string department = Console.ReadLine();

            Console.Write("GPA: ");
            float gpa;
            if (!float.TryParse(Console.ReadLine(), out gpa))
            {
                Console.WriteLine("GPA phải là số.");
                continue;
            }

            try
            {
                list2.Add(new Student(name, id, department, gpa));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Hiển thị list1 và list2
        Console.WriteLine("Danh sách sinh viên ngồi bàn 1:");
        foreach (Student student in list1)
        {
            Console.WriteLine($"Name: {student.Name}, ID: {student.Id}, Department: {student.Department}, GPA: {student.Gpa}");
        }

        Console.WriteLine("Danh sách sinh viên ngồi bàn 2:");
        foreach (Student student in list2)
        {
            Console.WriteLine($"Name: {student.Name}, ID: {student.Id}, Department: {student.Department}, GPA: {student.Gpa}");
        }

        // k. Khai báo list_list kiểu List của List và bổ sung list1, list2 vào list_list
        List<List<Person>> list_list = new List<List<Person>> { list1, list2 };

        // Hiển thị list_list
        Console.WriteLine("Danh sách các list:");
        foreach (var list in list_list)
        {
            foreach (Student student in list)
            {
                Console.WriteLine($"Name: {student.Name}, ID: {student.Id}, Department: {student.Department}, GPA: {student.Gpa}");
            }
        }

        // l. Tạo Dictionary dic11 cho list1 với trường khóa là id
        Dictionary<string, Student> dic11 = new Dictionary<string, Student>();
        foreach (Student student in list1)
        {
            dic11[student.Id] = student;
        }

        // Tìm sinh viên có tên là "Nam"
        Console.WriteLine("Sinh viên có tên là 'Nam' trong list1:");
        foreach (var student in dic11.Values)
        {
            if (student.Name.Contains("Nam"))
            {
                Console.WriteLine($"Name: {student.Name}, ID: {student.Id}, Department: {student.Department}, GPA: {student.Gpa}");
            }
        }
    }
}
