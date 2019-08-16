// Based on
// http://gabrielkoenig.com/ghosttime/world-space-to-screen-space-ui/

using UnityEngine;

public class WorldToCanvas : MonoBehaviour
{
    public Transform guy3d;
    public RectTransform guyUI;
    public Vector2 canvasSize;

    void Start(){
        // Set guyUI anchor min and max to 0,0
    }

    void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(guy3d.transform.position);
        guyUI.anchoredPosition = new Vector2(viewPos.x * canvasSize.x, viewPos.y * canvasSize.y);
        //planetLabels[i].gameObject.SetActive(viewPos.z > 0);

    }
}
