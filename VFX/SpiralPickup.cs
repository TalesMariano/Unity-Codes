    IEnumerator SpiralAnim()
    {
        const float duration = 1.5f;
        float centerDistance = 1f;

        Vector3 startScale = transform.localScale;

        Vector3 targetPos;

        float x, y;

        for (float i = 0; i < duration; i += Time.deltaTime )
        {
            if (centerDistance > 0)
                centerDistance -= Time.deltaTime * duration / 2;

            x = Mathf.Cos(i * Mathf.PI * 2) * centerDistance;
            y = Mathf.Sin(i * Mathf.PI * 2) * centerDistance;

            targetPos = new Vector3(x, y, 0);

            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, Time.deltaTime*3);

            transform.localScale = Vector3.Lerp(startScale, startScale / 2, i / duration);

            yield return null;
        }

        //transform.localPosition = new Vector3(0, 0, 0);
    }
