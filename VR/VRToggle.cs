// Tales Mariano - TalesMariano.com
// Used on Unity 2018.4.8f1
// Based on the script on:
// http://talesfromtherift.com/googlevr-cardboard-switch-between-normal-mode-and-vr-mode-at-run-time/
// https://docs.unity3d.com/ScriptReference/XR.XRSettings.LoadDeviceByName.html
// Adapted by me
using System.Collections;
using UnityEngine;
//using UnityEngine.VR;
using UnityEngine.XR;


public class VRToggle : MonoBehaviour
{

    [Header("Camera Controll")]
    public Transform cam;
    bool onVR = false;

    void Update()
    {
        /*
        if(!XRSettings.enabled)
            cam.localRotation = UnityEngine.XR.InputTracking.GetLocalRotation(XRNode.CenterEye);
        */

    }

    public void ToggleVR()
    {

        if (XRSettings.loadedDeviceName == "None")
        {
            StartCoroutine(LoadDevice("cardboard"));
            onVR = true;
        }
        else
        {
            StartCoroutine(LoadDevice("None"));
            onVR = false;
        }
    }
    
    IEnumerator LoadDevice(string newDevice)
    {
        UnityEngine.XR.XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        UnityEngine.XR.XRSettings.enabled = true;
    }


    public void SetCardboard()
    {
        StartCoroutine(LoadDevice("cardboard"));
        onVR = true;
    }

    public void SetNone()
    {
        StartCoroutine(LoadDevice("None"));
        onVR = false;
    }
}
