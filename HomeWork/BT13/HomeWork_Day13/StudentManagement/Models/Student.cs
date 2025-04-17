namespace StudentManagement.Models
{
    public class Student
    {
        public static int count = 1;
        public int Id { get; set; }
        public string? Name { get; set; }
        public double MathScore { get; set; }
        public double EnglishScore { get; set; }
        public double LiteratureScore { get; set; }

        public Student()
        {
            Id = count++;
        }

        public void InputInfo()
        {
            Name = Utils.GetStringInput("Enter student name: ", "Name cannot be empty.");
            MathScore = Utils.GetDoubleInput("Enter Math score: ", "Score must be between 0 and 10.");
            EnglishScore = Utils.GetDoubleInput("Enter English score: ", "Score must be between 0 and 10.");
            LiteratureScore = Utils.GetDoubleInput("Enter Literature score: ", "Score must be between 0 and 10.");
        }

        public void OutputInfo()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine($"| Student ID: {Id}");
            Console.WriteLine($"| Student Name: {Name}");
            Console.WriteLine($"| Math Grade: {MathScore}");
            Console.WriteLine($"| English Grade: {EnglishScore}");
            Console.WriteLine($"| Literature Grade: {LiteratureScore}");

        }

        public double AverageScore(Student student)
        {
            return (student.MathScore + student.EnglishScore + student.LiteratureScore) / 3;
        }

        public void OutputInfoWithCategory(string performance, double averageScore)
        {
            OutputInfo();
            Console.WriteLine("Category: " + performance + " with " + averageScore);
            Console.WriteLine("==============================================");
        }
    }
}
