using System;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Menu menu = new Menu();
        menu.LoadToFile();
        int choice;
        do
        {
            menu.ShowMenuFuction();
            choice = Utils.GetIntInput("Choose an option: ", "Invalid input, please enter a valid number.");
            switch (choice)
            {
                case 1:
                    menu.AddStudent();
                    break;
                case 2:
                    menu.SearchStudentByName();
                    break;
                case 3:
                    menu.UpdateStudentGrade();
                    break;
                case 4:
                    menu.CategorizeStudentsByPerformance();
                    break;
                case 5:
                    menu.DeleteStudent();
                    break;
                case 6:
                    menu.ShowStudentByPerformance();
                    break;
                case 7:
                    menu.ShowStudentByPerformanceAscending();
                    break;
                case 8:
                    menu.ShowStudentByPerformanceDescending();
                    break;
                case 9:
                    menu.ShowStudentByNameAscending();
                    break;
                case 10:
                    menu.SaveToFile();
                    break;
                case 11:
                    menu.LoadToFile();
                     System.Console.WriteLine("Load from file successfully !");
                    break;
                case 12:
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid function. Please select again.");
                    break;
            }
        } while (choice != 12);
    }
}
