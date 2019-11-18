/// Code by Tales Mariano. TalesMariano.com
/// References:
/// https://qa.fmod.com/t/how-to-change-the-parameter-of-an-event-using-c/12879
/// https://www.youtube.com/watch?v=QujIch7TPBU
/// https://www.fmod.com/resources/documentation-studio?version=2.0&page=parameters-reference.html#distance

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFmodExample : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string NAMEEVENT = "event:/sound_mus";
    public FMOD.Studio.EventInstance AUDIOEVENT;
    public FMOD.Studio.ParameterInstance PARAMETEREVENT;
    public FMOD.Studio.ParameterInstance parameterColor;

    void Start()
    {
        AUDIOEVENT = FMODUnity.RuntimeManager.CreateInstance(NAMEEVENT);
        AUDIOEVENT.getParameter("area", out PARAMETEREVENT);
        AUDIOEVENT.getParameter("color", out parameterColor);

        AUDIOEVENT.start();
    }

    void Update()
    {
       // PARAMETEREVENT.setValue(testValueColor);
    }


    public void SetArea(int numArea)
    {
        SetArea((float)numArea);
    }

    public void SetArea(float numArea)
    {
        StopCoroutine("IChangingParameterArea");
        StartCoroutine("IChangingParameterArea", numArea );

    }


    public void SetColor(float numColor)
    {

        StopCoroutine("IChangingParameterColor");
        StartCoroutine("IChangingParameterColor", numColor);
    }

    public void StartMusic()
    {
       // AUDIOEVENT.start();
    }


    IEnumerator IChangingParameterColor(float numColor)
    {
        float areaIni = numColor;
        float areaFin = areaIni + 1;

        for (float i = areaIni; i < areaFin; i += Time.deltaTime)
        {
            parameterColor.setValue(i);
            yield return null;
        }

        parameterColor.setValue(areaFin);
        Debug.Log("Color is " + areaFin);
    }

    IEnumerator IChangingParameterArea(float numArea)
    {
        //const float duration = 1;

        float areaIni = numArea;
        float areaFin = areaIni + 1;

        for (float i = areaIni; i < areaFin; i+= Time.deltaTime)
        {
            PARAMETEREVENT.setValue(i);
            yield return null;
        }

        PARAMETEREVENT.setValue(areaFin);

        Debug.Log("Area is " + areaFin);
    }
}
