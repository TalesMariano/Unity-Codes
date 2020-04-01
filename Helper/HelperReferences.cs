using UnityEngine;

public class HelperReferences : MonoBehaviour
{
    /// <summary>
    /// Check if there is any missing references on the monobehavior
    /// only works on public fields
    /// </summary>
    /// <param name="obj"> (this) </param>
    public static void CheckMissingReferences(object obj)
    {
        var type = obj.GetType();   // Get Obj type

        foreach (var p in type.GetFields()) // For each of its fields
        {
            if (p.GetValue(obj) == null)    // Check if field is null
            {
                Debug.LogError("Missing Reference: " + p.Name);
                return;
            }
        }
    }
