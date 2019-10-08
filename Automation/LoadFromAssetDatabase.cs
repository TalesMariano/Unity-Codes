// Tales Mariano - Tales.mariano.com
// References: 
// https://docs.unity3d.com/ScriptReference/AssetDatabase.LoadAssetAtPath.html
// https://docs.unity3d.com/ScriptReference/AssetDatabase.GUIDToAssetPath.html
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CreateBulas : MonoBehaviour
{
    public Sprite[] sprites;

    public GameObject prefabImage;
    public Transform targetFather;

#if UNITY_EDITOR
    [ContextMenu("DoAll")]
    void DoAll()
    {
        LoadAssets();
        CreateImages();
    }


    [ContextMenu("LoadAssets")]

    void LoadAssets()
    {

        
        string[]  guids2 = AssetDatabase.FindAssets("t:texture2D", new[] { "Assets/Bulas" }); // get a list of GUIDs based on search terms

        sprites = new Sprite[guids2.Length];

        for (int i = 0; i < guids2.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids2[i]); // Get the path of obj based on GUID

            sprites[i] = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite)); // Load asset based on path
        }
    }

    void CreateImages()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            GameObject go = Instantiate(prefabImage, targetFather) as GameObject;
            go.GetComponent<Image>().sprite = sprites[i];
        }


    }
#endif
}
