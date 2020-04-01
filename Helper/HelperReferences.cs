using UnityEngine;

public class HelperReferences : MonoBehaviour
{
    public static void CheckMissingReferences(object obj)
    {
        var type = obj.GetType();

        foreach (var p in type.GetFields())
        {
            if (p.GetValue(obj) == null)
            {
                Debug.LogError("Missing Reference: " + p.Name);
                return;
            }
        }
    }
}
