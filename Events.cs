    void OnEnable()
    {
        GetComponent<ARReferencePointManager>().referencePointsChanged += OnReferencePointsChanged;
    }

    void OnDisable()
    {
        GetComponent<ARReferencePointManager>().referencePointsChanged -= OnReferencePointsChanged;
    }
