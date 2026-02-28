using System;

public class InvalidStudentAgeException : Exception
{
    public InvalidStudentAgeException(string message) : base(message) { }
    public InvalidStudentAgeException(string message, Exception inner) : base(message, inner) { }
}

public class InvalidStudentNameException : Exception
{
    public InvalidStudentNameException(string message) : base(message) { }
    public InvalidStudentNameException(string message, Exception inner) : base(message, inner) { }
}

public class Program
{
    public static void Main()
    {
        HandleDivision();
        HandleConversion();
        HandleArrayAccess();
        ValidateStudentData();
    }

    static void HandleDivision()
    {
        try
        {
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());

            int result = a / b;
            Console.WriteLine("Result: " + result);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
            PrintExceptionDetails(ex);
        }
        finally
        {
            Console.WriteLine("Operation Completed");
            Console.WriteLine();
        }
    }

    static void HandleConversion()
    {
        try
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + num);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: Invalid number format.");
            PrintExceptionDetails(ex);
        }
        finally
        {
            Console.WriteLine("Operation Completed");
            Console.WriteLine();
        }
    }

    static void HandleArrayAccess()
    {
        try
        {
            int[] arr = { 10, 20, 30 };
            Console.Write("Enter index (0-2): ");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Value: " + arr[index]);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Error: Invalid array index.");
            PrintExceptionDetails(ex);
        }
        finally
        {
            Console.WriteLine("Operation Completed");
            Console.WriteLine();
        }
    }

    static void ValidateStudentData()
    {
        while (true)
        {
            try
            {
                Console.Write("Enter student name: ");
                string name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                    throw new InvalidStudentNameException("Student name cannot be empty.");

                Console.Write("Enter student age: ");
                int age;

                try
                {
                    age = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    throw new InvalidStudentAgeException("Age must be a valid integer.", ex);
                }

                if (age < 18 || age > 60)
                    throw new InvalidStudentAgeException("Student age must be between 18 and 60.");

                Console.WriteLine("Student data is valid.");
                break;
            }
            catch (InvalidStudentNameException ex)
            {
                Console.WriteLine("Custom Exception: " + ex.Message);
                PrintExceptionDetails(ex);
            }
            catch (InvalidStudentAgeException ex)
            {
                Console.WriteLine("Custom Exception: " + ex.Message);

                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }

                PrintExceptionDetails(ex);
            }
            finally
            {
                Console.WriteLine("Operation Completed");
                Console.WriteLine();
            }
        }
    }

    static void PrintExceptionDetails(Exception ex)
    {
        Console.WriteLine("Message: " + ex.Message);
        Console.WriteLine("StackTrace: " + ex.StackTrace);
        if (ex.InnerException != null)
        {
            Console.WriteLine("InnerException: " + ex.InnerException.Message);
        }
    }
}