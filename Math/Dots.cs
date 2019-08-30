using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dot : MonoBehaviour
{
    public float angle;

    public float dot;

    public Transform camcam;

    Vector3 startPos;

    public bool visible;
    bool lastVisible;
    public bool focus;
    bool lastFocus;

    public Animator[] anim;


    public UnityEvent eventFocus;
    public UnityEvent eventUnfocus;
    public UnityEvent eventVisible;
    public UnityEvent eventInvisible;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        angle = Vector3.Angle(camcam.transform.forward, transform.position - camcam.transform.position);

        dot = Vector3.Dot(-transform.forward, (camcam.position - transform.position).normalized); ;

        visible = dot > 0;

        focus = dot > 0.7f;

        //transform.position = startPos + Vector3.forward * (Time.timeSinceLevelLoad % 1);

        if(focus != lastFocus)
        {
            if (focus)
                OnFocus();
            else
                OnUnfocus();
        }

        if (visible != lastVisible) {
            if (visible)
                OnVisible();
            else
                OnInvisible();
            //visible? OnVisible(): OnInvisible();
        }

        lastVisible = visible;
        lastFocus = focus;
    }

    void OnFocus()
    {
        eventFocus.Invoke();
        foreach (var a in anim)
        {
            a.SetBool("On", true);
        }
    }

    void OnUnfocus()
    {
        eventUnfocus.Invoke();
    }

    void OnVisible()
    {
        eventVisible.Invoke();
    }

    void OnInvisible()
    {
        eventInvisible.Invoke();
        foreach (var a in anim)
        {
            a.SetBool("On", false);
        }
    }
    void OnDrawGizmos()
    {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, transform.position - transform.forward);
    }
}
