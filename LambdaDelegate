public class UI_ServerError{

  //Receive Unityevent as Delegate
  public void ReceiveEvent(UnityAction event1)
  {
    FirstButton.onClick.AddListener(event1);
    event1.Invoke();
  }
  
  void Update()
  {
    ReceiveEvent(() => Application.Quit());
    
    ReceiveEvent(() => { Function(Interaction_Manager.instance.defaultScreen); });
  }
  
  //https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions
  
  
  // videos
  //https://www.youtube.com/watch?v=G5R4C8BLEOc
  //https://www.youtube.com/watch?v=TdiN18PR4zk


}
