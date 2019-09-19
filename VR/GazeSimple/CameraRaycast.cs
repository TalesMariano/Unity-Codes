// Code by Tales Mariano - TalesMariano.com
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    Transform lastCast; 
    GazeTarget lastTarget;                          //last obj gazed

    const float maxDistance = 40;                   //gaze max distance

    public Transform cursor;                        // 3d obj that works as a cursor, usualy a sphere

    private void FixedUpdate()
    {
        RaycastHit hit;                             // Raycast from the front of the camera
        var fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, maxDistance))
        {
            if (hit.transform.tag == "Gaze")        // If the obj hit have a tag gaze
            {
                if(lastTarget == null)              // this is for minimizing the use of GetComponent
                {
                    lastTarget = hit.collider.gameObject.transform.GetComponent<GazeTarget>();
                }
                lastTarget.gazing = true;           // then its gazing

            }
            else                                    // so if the raycast still hits and obj but the tag is not gaze, clear the last target
            {
                lastTarget.gazing = false;
                lastTarget = null;
            }
            cursor.position = hit.point;            //ajust position of the cursor
        }
        else
        {
            if(lastTarget != null)                  //Clear last target when ray does not hit anything
            {
                lastTarget.gazing = false;
                lastTarget = null;
            }

            cursor.position = transform.position + fwd * (maxDistance/2);   //when not tracking anything, set the cursor at had the max distance
        }
    }
}
