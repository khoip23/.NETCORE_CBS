namespace StudentManagement.Models
{
    public class UpdateMenu
    {
        private Student student;
        public UpdateMenu(Student student)
        {
            this.student = student;
        }

        public void DisplayMenu()
        {
            Console.WriteLine("1. Update Math grade");
            Console.WriteLine("2. Update Literature grade");
            Console.WriteLine("3. Update English grade");

            int choice = Utils.GetIntInput("Choose an option: ", "Invalid choice.");
            switch (choice)
            {
                case 1:
                    student.MathScore = Utils.GetDoubleInput("Enter new Math grade: ", "Score must be between 0 and 10.");
                    Console.WriteLine("Math grade updated successfully!");
                    break;
                case 2:
                    student.LiteratureScore = Utils.GetDoubleInput("Enter new Literature grade: ", "Score must be between 0 and 10.");
                    Console.WriteLine("Literature grade updated successfully!");
                    break;
                case 3:
                    student.EnglishScore = Utils.GetDoubleInput("Enter new English grade: ", "Score must be between 0 and 10.");
                    Console.WriteLine("English grade updated successfully!");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
