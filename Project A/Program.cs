using System;

namespace ProjectA
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                var student = new Student("Sum", "Ting", "Wong", "M8O-201Б-21", "C#");
                Console.WriteLine(student);

                student.FirstName = "Wi";
                student.LastName = "Tu";
                student.MiddleName = "Lo";
                student.Group = "M8O-201Б-21";
                student.Course = "Go";

                Console.WriteLine(student);

                var student2 = new Student("Ho", "Lee", "Fuk", "M8O-201Б-21", "C#");
                Console.WriteLine(student.Equals(student2));

                var student3 = new Student("Wi", "Tu", "Lo", "M8O-201Б-21", "Go");
                Console.WriteLine(student.Equals(student3));
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
