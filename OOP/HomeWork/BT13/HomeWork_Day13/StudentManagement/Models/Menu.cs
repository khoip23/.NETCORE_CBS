// File: Menu.cs
using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Text.Json;
using StudentManagement.Models;
public class Menu
{
    public List<Student>? list { get; set; } = new();

    public void ShowMenuFuction()
    {
        Console.WriteLine(@"
            1/ Add new student
            2/ Search by name
            3/ Update grade of student
            4/ Categorize students by performance
            5/ Delete student
            6/ Show student by performance
            7/ Show student by performance ascending
            8/ Show student by performance descending
            9/ Show student by name ascending
            10/ Save to file
            11/ Load from file
            12/ Quit
        ");
    }

    public int ChooseFunction()
    {
        return Utils.GetIntInput("Choose a fucntion: ", "Invalid");
    }

    public void AddStudent()
    {
        Student student = new();
        student.InputInfo();
        list.Add(student);
        Console.WriteLine("Add new student successfully !", "Invalid");
    }

    public void ShowAllStudents()
    {
        if (list.Count == 0)
        {
            Console.WriteLine("The list of student is empty !", "Invalid");
            return;
        }

        foreach (var item in list)
        {
            item.OutputInfo();
        }
    }

    public void DeleteStudent()
    {
        int studentId = Utils.GetIntInput("Nhập mã sinh viên cần xoá: ", "Invalid");
        var studentToRemove = list?.Find(stu => stu.Id == studentId);
        if (studentToRemove != null)
        {
            list?.Remove(studentToRemove);
            Console.WriteLine("Xoá thành công !");
        }
        else
        {
            Console.WriteLine("Mã sinh viên không tồn tại !");
        }
    }

    public void SearchStudentByName()
    {
        string name = Utils.GetStringInput("Nhập tên sinh viên cần tìm: ", "Invalid");
        var students = list?.FindAll(stu => stu.Name.ToLower().Contains(name));
        if (students.Count > 0)
        {
            foreach (var student in students)
            {
                student.OutputInfo();
            }
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên.", "Invalid");
        }
    }

    public void UpdateStudentGrade()
    {
        int studentId = Utils.GetIntInput("Student ID: ", "Invalid");


        var student = list?.Find(stu => stu.Id == studentId);

        if (student != null)
        {
            UpdateMenu updateMenu = new(student);
            updateMenu.DisplayMenu();
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    public async void SaveToFile()
    {
        // Đưa dữ liệu object -> json string
        string listStudent = JsonSerializer.Serialize(this.list);
        Console.WriteLine("add file success");
        // lưu dữ liệu string thành danh sach sinh viên vao file
        await File.WriteAllTextAsync("DSSV.json", listStudent);
        string currentDirectory = Directory.GetCurrentDirectory();
        Console.WriteLine(currentDirectory);

    }

    public async void LoadToFile()
    {
        //Read text (string) from file   
        string strDSSV = await File.ReadAllTextAsync("./DSSV.json");
        // Chuyển đổi text thành object theo định dạng muốn chuyển
        list = JsonSerializer.Deserialize<List<Student>>(strDSSV);

    }

    public void CategorizeStudentsByPerformance()
    {




        foreach (Student item in list)
        {
            double averageScore = item.AverageScore(item);
            // Categorize based on average score
            if (averageScore < 5)
            {
                System.Console.WriteLine("Danh sách học sinh yếu: ");
                item.OutputInfoWithCategory("Yếu", averageScore);
            }
            else if (averageScore >= 5 && averageScore <= 6.5)
            {
                System.Console.WriteLine("Danh sách học sinh trung bình: ");
                item.OutputInfoWithCategory("Trung Bình", averageScore);
            }
            else if (averageScore >= 6.5 && averageScore < 8)
            {
                System.Console.WriteLine("Danh sách học sinh khá: ");
                item.OutputInfoWithCategory("Khá", averageScore);
            }
            else
            {
                System.Console.WriteLine("Danh sách học sinh giỏi: ");
                item.OutputInfoWithCategory("Giỏi", averageScore);
            }
        }
    }
    public void ShowStudentByPerformance()
    {
        foreach (var student in list)
        {
            double averageScore = student.AverageScore(student);
            string performanceCategory;

            if (averageScore >= 8)
                performanceCategory = "Giỏi";
            else if (averageScore >= 6.5)
                performanceCategory = "Khá";
            else if (averageScore >= 5)
                performanceCategory = "Trung Bình";
            else
                performanceCategory = "Yếu";

            student.OutputInfoWithCategory(performanceCategory, averageScore);
        }
    }

    public void ShowStudentByPerformanceAscending()
    {
        var sortedStudents = list?.OrderBy(s => s.AverageScore(s)).ToList();
        Console.WriteLine("Danh sách sinh viên theo thứ tự điểm trung bình tăng dần:");
        foreach (var student in sortedStudents)
        {
            student.OutputInfo();
        }
    }

    public void ShowStudentByPerformanceDescending()
    {
        var sortedStudents = list?.OrderByDescending(s => s.AverageScore(s)).ToList();
        Console.WriteLine("Danh sách sinh viên theo thứ tự điểm trung bình giảm dần:");
        foreach (var student in sortedStudents)
        {
            student.OutputInfo();
        }
    }

    

    public void ShowStudentByNameAscending()
    {
        var sortedStudents = list?.OrderBy(s => s.Name.Split(' ').Last()).ToList();
        Console.WriteLine("Danh sách sinh viên theo thứ tự tên từ Z-A:");
        foreach (var student in sortedStudents)
        {
            student.OutputInfo();
        }
    }

}
