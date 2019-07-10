public class Example
{
   public static void Main()
   {
   
      // Switch
      Color c = (Color) (new Random()).Next(0, 3);
      switch (c)
      {
         case Color.Red:
            Console.WriteLine("The color is red");
            break;
         case Color.Green:
            Console.WriteLine("The color is green");
            break;
         case Color.Blue:
            Console.WriteLine("The color is blue");   
            break;
         default:
            Console.WriteLine("The color is unknown.");
            break;   
      }
      
      //Check if all bools[] are true
      bool CheckBoolList(bool[] bl)
      {
          foreach (var item in bl)
          {
              if (!item)
                  return false;
          }
          return true;
      }
      
      //Simple Check
      public void ReceivePassword(string pword)
      {
          //Assim não
         /* if(pword == senha)
          {
              buttonPrise.interactable = true;
          }
          else
          {
              buttonPrise.interactable = false;
          }*/

          buttonPrise.interactable = pword == senha;
      }
      
      
      void DoStuff(){
         /*
         if(want2do){
            if(reallyWant){
               // Dostuff  
               // stuff
               // stuff
            }
         }*/
         
         if(!want2do)
            return;
         if(!reallyWant)
            return;
         
         // Dostuff  
         // stuff
         // stuff
         
      }
   }
}
