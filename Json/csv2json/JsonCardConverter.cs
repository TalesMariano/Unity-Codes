using UnityEngine;

public class JsonCardConverter : MonoBehaviour
{
    public TextAsset jsonFile;

    [TextArea(3, 15)]
    public string jsonText;

    [Tooltip(" All Assets of Cards ")]
    public TargetCard[] arrayCards;

    [ContextMenu("ConvertCards")]
    void ConvertCards()
    {
        // Get json text
        string s;

        if (jsonFile)
            s = jsonFile.text;
        else if (jsonText!= null)
            s = jsonText;
        else
        {
            Debug.LogError("Missing text");
            return;
        }

        // Prepare text

        var pos = s.IndexOf("[");
        s = s.Substring(pos + 1); // cut away the first "["
        pos = s.LastIndexOf(']');
        s = s.Substring(0, pos - 1); // cut away "]" at the end

        s = s.Replace("resourceName", "\"resourceName\"");        // make resourceName and resourceNumber into things for classes
        s = s.Replace("resourceNumber", "\"resourceNumber\"");
        s = s.Replace("\"[", "[");  // remove " from beging and end of material
        s = s.Replace("]\"", "]");

        // Split jsons
        s = s.Replace(" },", " }!");    // add split separator
        string[] individualJson = s.Split('!'); // split


        int smallestNumber = Mathf.Min(individualJson.Length, arrayCards.Length);   // get smalest number to prevent error

        for (int i = 0; i < smallestNumber; i++)
        {
            //Debug.Log(individualJson[i]);
            JsonUtility.FromJsonOverwrite(individualJson[i], arrayCards[i]);
        }

        Debug.Log("Conversion Done!");
    }
}
