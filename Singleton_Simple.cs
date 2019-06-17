using UnityEngine;

public class Singleton_Simple : MonoBehaviour
{
    //Singleton
    public static Singleton_Simple instance = null;
    void Awake()
    {
        if (instance == null)       //Check if instance already exists
            instance = this;        //if not, set instance to this
        else if (instance != this)  //If instance already exists and it's not this:
            Destroy(gameObject);    //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        DontDestroyOnLoad(gameObject); //Sets this to not be destroyed when reloading scene
    }
}
