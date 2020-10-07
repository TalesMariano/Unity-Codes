## Links
* https://docs.unity3d.com/ScriptReference/ExecuteInEditMode.html

### OnValidate()
- This function is called when the script is loaded or a value is changed in the Inspector (Called in the editor only).
- https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnValidate.html


### Change Helper URL
[HelpURL("http://example.com/docs/MyComponent.html")]

https://docs.unity3d.com/ScriptReference/HelpURLAttribute.html


### Create new Tab Editor
https://medium.com/@ricardo.valerio/how-to-make-a-unity-editor-window-3cd05440c6c0

    using UnityEditor;
    using UnityEngine;

    public class MyEditorWindow : EditorWindow
    {

        [MenuItem("My Tools/My Editor Window", false, 1)]
        public static void ShowWindow()
        {
            GetWindow(typeof(MyEditorWindow));
        }

        public void OnGUI()
        {
            // Layout the UI
        }
    }
