using UnityEngine;
using System.Collections;
 
public class StateMachine : MonoBehaviour {
 
    public enum State {
        Crawl,
        Walk,
        Die,
    }
 
    public State state;
   
  
}
