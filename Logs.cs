// Based on ARFoundation ARWorldMap

    [Tooltip("UI Text component to display error messages")]
    [SerializeField]
    Text m_ErrorText;

    /// <summary>
    /// The UI Text component used to display error messages
    /// </summary>
    public Text errorText
    {
        get { return m_ErrorText; }
        set { m_ErrorText = value; }
    }

    [Tooltip("The UI Text element used to display log messages.")]
    [SerializeField]
    Text m_LogText;

    /// <summary>
    /// The UI Text element used to display log messages.
    /// </summary>
    public Text logText
    {
        get { return m_LogText; }
        set { m_LogText = value; }
    }

    [Tooltip("The UI Text element used to display the current AR world mapping status.")]
    [SerializeField]
    Text m_MappingStatusText;

    /// <summary>
    /// The UI Text element used to display the current AR world mapping status.
    /// </summary>
    public Text mappingStatusText
    {
        get { return m_MappingStatusText; }
        set { m_MappingStatusText = value; }
    }
    
    IEnumerator Save()
    {
        if (sessionSubsystem == null)
        {
            Log("No session subsystem available. Could not save.");
            yield break;
        }
    }
    
    IEnumerator Load()
    {
        var sessionSubsystem = (ARKitSessionSubsystem)m_ARSession.subsystem;
        if (sessionSubsystem == null)
        {
            Log("No session subsystem available. Could not load.");
            yield break;
        }

        var file = File.Open(path, FileMode.Open);
        if (file == null)
        {
            Log(string.Format("File {0} does not exist.", path));
            yield break;
        }

        Log(string.Format("Reading {0}...", path));
        Log("Apply ARWorldMap to current session.");
    }
    
    void Log(string logMessage)
    {
        m_LogMessages.Add(logMessage);
    }
    
    void Update()
    {
        var numLogsToShow = 20;
        string msg = "";
        for (int i = Mathf.Max(0, m_LogMessages.Count - numLogsToShow); i < m_LogMessages.Count; ++i)
        {
            msg += m_LogMessages[i];
            msg += "\n";
        }
        SetText(logText, msg);

        SetText(mappingStatusText, string.Format("Mapping Status: {0}", sessionSubsystem.worldMappingStatus));
    }

    List<string> m_LogMessages;
