

  public var variable;
  
      private string name;
      
      public string Name
      {
          get { return name; }
          set { name = value; }
      }
  
  enum WeekDays
{
    Monday = 0,
    Tuesday =1,
    Wednesday = 2,
    Thursday = 3,
    Friday = 4,
    Saturday =5,
    Sunday = 6
}

Console.WriteLine(WeekDays.Friday);
Console.WriteLine((int)WeekDays.Friday);

enum WeekDays
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

Console.WriteLine((int)WeekDays.Monday);
Console.WriteLine((int)WeekDays.Friday);

[System.Serializable]
class Test : System.Object
{
    public int p = 5;
    public Color c = Color.white;
}

public Test testinho;
  


///Enum

//Set this outise class
public enum Direction { Up, Right, Left, Down, None = -1 }

public static class DirectionExtetions
{
    public static int Oposite(this Direction dir)
    {
        return ((int)dir + 2) % 4;
    }

    public static Direction OpositeEnum(this Direction dir)
    {
        return (Direction)(((int)dir + 2) % 4);
    }

}
