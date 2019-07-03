//Origin
//https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/using-properties

public class Date
{
    private int month = 7;  // Backing store

    public int Month
    {
        get
        {
            return month;
        }
        set
        {
            if ((value > 0) && (value < 13))
            {
                month = value;
            }
        }
    }
}

class Employee
{
    private string name;
    public string Name
    {
        get
        {
            return name != null ? name : "NA";
        }
    }
}

//Mini

    public bool CreatingPoints
    {
        get { return creatingPoints; }
        set { creatingPoints = value;}
    }
    public bool creatingPoints = true;
