using UnityEngine;

public class VisionAngleLimiter : MonoBehaviour
{
    public Transform world;

    public float angleDiference;

    float limit =  45f;
    float limitDot = 0.9f;

    Vector3 worldY;
    Vector3 myY;

    Quaternion worldY2;
    Quaternion myY2;

    void Update()
    {
        worldY = new Vector3(0, world.eulerAngles.y, 0); //
        myY = new Vector3(0, transform.eulerAngles.y, 0);

        worldY2 = Quaternion.Euler(0, world.eulerAngles.y, 0).normalized;
        myY2 = Quaternion.Euler(0, transform.eulerAngles.y, 0).normalized;

        angleDiference = Quaternion.Dot(worldY2, myY2); //transform.eulerAngles.y - world.eulerAngles.y;

        
        if ( Mathf.Abs( angleDiference) < limitDot)
        {
            Quaternion plus45 = Quaternion.Euler(0, 45, 0);

            world.rotation = Quaternion.Lerp(world.rotation, myY2, Time.deltaTime );
        }

        //world.rotation = Quaternion.Lerp(world.rotation, transform.rotation, Time.deltaTime*2);
    }


    /// <summary>
    /// Draws a line showing where the camera is pointing
    /// </summary>
    void OnDrawGizmos()
    {
        // Draws a blue line from this transform to the target
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    }
}
