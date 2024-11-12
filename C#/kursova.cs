using System;
public class X
{
    private string textValue;          
    private int numericValue;           
    private DateTime dateValue;         
    private static int objectCount = 0; 
    
    
    public X(string text, int number, DateTime date)
    {
        TextValue = text;
        NumericValue = number;
        dateValue = date;
        objectCount++;  
    }

    
    public string TextValue
    {
        get
        {
            return string.Join(" ", textValue.ToUpper().ToCharArray());
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                textValue = value;
            else
                throw new ArgumentException("Текстът не може да бъде празен.");
        }
    }

    public int NumericValue
    {
        get { return numericValue; }
        set
        {
            if (value >= 0)
                numericValue = value;
            else
                throw new ArgumentException("Числото трябва да бъде положително.");
        }
    }

    public int DaysSinceYearStart
    {
        get
        {
            DateTime startOfYear = new DateTime(dateValue.Year, 1, 1);
            return (dateValue - startOfYear).Days + 1;
        }
    }

    public virtual void SomeOperation()
    {
        Console.WriteLine($"Операция с числото: {numericValue * 2}");
    }

    public void SomeOperation(int multiplier)
    {
        Console.WriteLine($"Операция с числото, умножено по {multiplier}: {numericValue * multiplier}");
    }

    public virtual void Print()
    {
        Console.WriteLine("Това е методът Print от клас X");
    }

    public static int GetObjectCount()
    {
        return objectCount;
    }
}

public class Y : X
{
    public Y(string text, int number, DateTime date) : base(text, number, date)
    {
    }

    public override void Print()
    {
        Console.WriteLine("Това е методът Print от клас Y");
    }
}

class Program
{
    static void Main(string[] args)
    {
        X objX = new X("Женева", 10, new DateTime(2022, 1, 10));

        objX.TextValue = "Женева";  
        objX.NumericValue = 20;     

        Console.WriteLine("TextValue: " + objX.TextValue);
        Console.WriteLine("NumericValue: " + objX.NumericValue);
        Console.WriteLine("DaysSinceYearStart: " + objX.DaysSinceYearStart);

        objX.SomeOperation();                  
        objX.SomeOperation(3);                 
        objX.Print();                          

        Console.WriteLine("Брой обекти от клас X: " + X.GetObjectCount());

        Y objY = new Y("София", 5, DateTime.Now);

        objY.Print();

        Console.ReadLine();
    }
}