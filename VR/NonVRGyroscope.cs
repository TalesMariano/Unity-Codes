/// Based on Scripts / Pages
/// https://docs.unity3d.com/2017.2/Documentation/Manual/VRDevices-GoogleVR.html
/// https://docs.unity3d.com/ScriptReference/Gyroscope.html // even if it didnt work

using UnityEngine;
using UnityEngine.XR;


public class NonVRGyroscope : MonoBehaviour{

    protected void Update()
    {
        if(!XRSettings.enabled)
            transform.localRotation = InputTracking.GetLocalRotation(XRNode.CenterEye);
    }
}
