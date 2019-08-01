    void OnApplicationQuit()
    {
        // Sent to all game objects before the application quits.
        // In the editor this is called when the user stops playmode.
        Debug.Log("Application ending after " + Time.time + " seconds");
    }
    
    void OnValidate()
    {
        // This function is called when the script is loaded or a value is changed in the Inspector (Called in the editor only).
        // You can use this to ensure that when you modify data in an editor, that data stays within a certain range.
    }
    
    
