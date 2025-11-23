using System;

namespace Sinhvien
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Student() { }

        public Student(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public void Input()
        {
            int tempInt;
            Console.Write("Nhập mã số (Id): ");
            while (!int.TryParse(Console.ReadLine(), out tempInt))
                Console.Write("Mã số không hợp lệ. Nhập lại Id (số nguyên): ");
            Id = tempInt;

            Console.Write("Nhập họ tên: ");
            Name = Console.ReadLine();

            Console.Write("Nhập tuổi: ");
            while (!int.TryParse(Console.ReadLine(), out tempInt))
                Console.Write("Tuổi không hợp lệ. Nhập lại tuổi (số nguyên): ");
            Age = tempInt;
        }

        public void Show()
        {
            Console.WriteLine($"ID: {Id} | Tên: {Name} | Tuổi: {Age}");
        }
    }
}
