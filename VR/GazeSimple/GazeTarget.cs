using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GazeTarget : MonoBehaviour
{
    public bool gazing = false;

    public UnityEvent fillEvent;

    [Header("UI")]
    public Image fillImage;
    float filling = 0; 

    [Header("Audio")]
    public AudioSource aSource;

    [Header("Animation")]
    public CanvasGroup canvasGroup;
    public AnimationCurve aCurse;

    [Header("Disable")]
    public GameObject objDisable;

    private void OnEnable()
    {
        StartCoroutine(FadeIn());
    }

    void Update()
    {
            if (gazing)
            {
                filling += Time.deltaTime;
                fillImage.fillAmount = filling;
                if (filling > 1)
                {
                    FillAction();
                }
            }
           else
            {
                filling = 0;
                fillImage.fillAmount = filling;
            }

    }

    void FillAction()
    {
        aSource.Play();
        StartCoroutine(AnimNDie());
        fillEvent.Invoke();
    }

    IEnumerator FadeIn()
    {
        const float duration = 0.7f;

        for (float i = duration; i >=0 ; i -= Time.deltaTime)
        {
            canvasGroup.alpha = (duration - i) / duration;
            //transform.localScale = Vector3.LerpUnclamped(startScale, Vector3.zero, aCurse.Evaluate(i / duration));
            yield return null;
        }

        canvasGroup.alpha = 1;
    }

    IEnumerator AnimNDie()
    {
        const float duration = 0.7f;
        Vector3 startScale = transform.localScale;


        for (float i = 0; i < duration; i+= Time.deltaTime)
        {
            canvasGroup.alpha = (duration - i)/duration;
            transform.localScale = Vector3.LerpUnclamped(startScale, Vector3.zero, aCurse.Evaluate( i / duration));
            yield return null;
        }

        canvasGroup.alpha = 0;
        transform.localScale = Vector3.zero;
        objDisable.SetActive(false);
    }
}
