using Sinhvien;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        List<Student> students = new List<Student>()
        {
            new Student(1, "An", 16),
            new Student(2, "Binh", 18),
            new Student(3, "Anh", 15),
            new Student(4, "Cuong", 14),
            new Student(5, "Alicya", 17)
        };

        bool exit = false;
        while (!exit)
        {
            ShowMenu();
            Console.Write("Chọn chức năng (0-8): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                //case "1":
                //    AddStudent(students);
                //    break;
                case "1":
                    DisplayAll(students);
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "2":
                    DisplayAge15to18(students);
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "3":
                    DisplayNameStartWithA(students);
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "4":
                    DisplayTotalAge(students);
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "5":
                    DisplayOldestStudents(students);
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "6":
                    DisplaySortedByAge(students);
                    Console.ReadLine();
                    Console.Clear();
                    break;
                //case "8":
                //    DisplayHelpSampleLinq(students);
                //    break;
                case "0":
                    exit = true;
                    Console.WriteLine("Kết thúc chương trình. Tạm biệt!");
                    break;
                default:
                    Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
            Console.WriteLine();
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("=== MENU QUẢN LÝ HỌC SINH (LINQ) ===");
        //Console.WriteLine("1. Thêm sinh viên");
        Console.WriteLine("1. In toàn bộ danh sách học sinh (a)");
        Console.WriteLine("2. In học sinh tuổi từ 15 đến 18 (b)");
        Console.WriteLine("3. In học sinh có tên bắt đầu bằng 'A' (c)");
        Console.WriteLine("4. Tính tổng tuổi của tất cả học sinh (d)");
        Console.WriteLine("5. In học sinh có tuổi lớn nhất (e)");
        Console.WriteLine("6. Sắp xếp và in danh sách theo tuổi tăng dần (f)");
        //Console.WriteLine("8. Thực thi toàn bộ các tác vụ a→f liên tiếp");
        Console.WriteLine("0. Thoát");
    }

    static void AddStudent(List<Student> students)
    {
        Console.WriteLine("=== Thêm sinh viên mới ===");
        Student s = new Student();
        s.Input();

        if (students.Any(x => x.Id == s.Id))
        {
            Console.WriteLine("Cảnh báo: Đã tồn tại sinh viên có cùng Id. Không thêm nếu không muốn trùng.");
            Console.Write("Bạn có muốn thêm vẫn (y/n)? ");
            string t = Console.ReadLine();
            if (!t.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Hủy thêm sinh viên.");
                return;
            }
        }

        students.Add(s);
        Console.WriteLine("Thêm sinh viên thành công!");
    }

    static void DisplayAll(List<Student> students)
    {
        Console.WriteLine("=== Toàn bộ danh sách học sinh ===");
        if (!students.Any())
        {
            Console.WriteLine("Danh sách rỗng.");
            return;
        }
        students.ForEach(s => s.Show());
    }

    static void DisplayAge15to18(List<Student> students)
    {
        Console.WriteLine("=== Học sinh có tuổi từ 15 đến 18 ===");
        var q = students.Where(s => s.Age >= 15 && s.Age <= 18).ToList();
        if (!q.Any()) Console.WriteLine("Không có học sinh thỏa điều kiện.");
        else q.ForEach(s => s.Show());
    }

    static void DisplayNameStartWithA(List<Student> students)
    {
        Console.WriteLine("=== Học sinh có tên bắt đầu bằng chữ 'A' ===");
        var q = students.Where(s => !string.IsNullOrEmpty(s.Name) && s.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase)).ToList();
        if (!q.Any()) Console.WriteLine("Không có học sinh thỏa điều kiện.");
        else q.ForEach(s => s.Show());
    }

    static void DisplayTotalAge(List<Student> students)
    {
        Console.WriteLine("=== Tổng tuổi của tất cả học sinh ===");
        int total = students.Sum(s => s.Age);
        Console.WriteLine($"Tổng tuổi = {total}");
    }

    static void DisplayOldestStudents(List<Student> students)
    {
        Console.WriteLine("=== Học sinh có tuổi lớn nhất ===");
        if (!students.Any())
        {
            Console.WriteLine("Danh sách rỗng.");
            return;
        }
        int maxAge = students.Max(s => s.Age);
        var q = students.Where(s => s.Age == maxAge).ToList();
        q.ForEach(s => s.Show());
    }

    static void DisplaySortedByAge(List<Student> students)
    {
        Console.WriteLine("=== Danh sách sắp xếp theo tuổi tăng dần ===");
        var q = students.OrderBy(s => s.Age).ToList();
        q.ForEach(s => s.Show());
    }

    //static void DisplayHelpSampleLinq(List<Student> students)
    //{
 
    //    DisplayAll(students);
    //    Console.WriteLine();
    //    DisplayAge15to18(students);
    //    Console.WriteLine();
    //    DisplayNameStartWithA(students);
    //    Console.WriteLine();
    //    DisplayTotalAge(students);
    //    Console.WriteLine();
    //    DisplayOldestStudents(students);
    //    Console.WriteLine();
    //    DisplaySortedByAge(students);
    //}
}
