using System;

class Program
{
    static void Main()
    {
        Console.Write("What is your porcentage? ");
        string grade = Console.ReadLine();
        int leter = int.Parse(grade);

        string res = "";

        if (leter >= 97)
        {
            res = "A+";
        }
        else if (leter >= 93 && leter <= 96)
        {
            res = "A";
        }
        else if (leter >= 90 && leter <= 92)
        {
            res = "A-";
        }
        else if (leter >= 87 && leter <= 89)
        {
            res = "B+";
        }
        else if (leter >= 83 && leter <= 86)
        {
            res = "B";
        }
        else if (leter >= 80 && leter <= 82)
        {
            res = "B-";
        }
        else if (leter >= 77 && leter <= 79)
        {
            res = "C+";
        }
        else if (leter >= 73 && leter <= 76)
        {
            res = "C";
        }
        else if (leter >= 70 && leter <= 72)
        {
            res = "C-";
        }
        else if (leter >= 67 && leter <= 69)
        {
            res = "D+";
        }
        else if (leter >= 63 && leter <= 66)
        {
            res = "D";
        }
        else if (leter >= 60 && leter <= 62)
        {
            res = "D-";
        }
        else if (leter < 60)
        {
            res = "F";
        }
        Console.WriteLine($"Your letter grade is: {res}");
    }
}
