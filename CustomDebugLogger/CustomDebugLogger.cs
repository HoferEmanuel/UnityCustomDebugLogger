using UnityEngine;

public class CustomDebugLoggerLog : MonoBehaviour
{
    public static CustomDebugLoggerLog Instance;

    [SerializeField] private Transform logContent;
    [SerializeField] private CustomDebugLoggerLog logPrefab;

    [SerializeField] private List<CustomDebugLogInfo> logs = new List<CustomDebugLogInfo>();
    [SerializeField] private CustomDebugFocusType currentFocus = CustomDebugFocusType.None;

    private void Awake()
    {
        Instance = this;

        //subscribe ot the Debug-event
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        //unsubscribe
        Application.logMessageReceived -= HandleLog;
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        //Gets called after the Log-Message-Recieved-Event
        CustomDebugLogInfo newLog = new CustomDebugLogInfo(logString, type);
        AddLog(currentLog);
    }

    public void AddLog(CustomDebugLogInfo newLog) => logs.Add(newLog);

    public void RemoveLog(CustomDebugLogInfo targetLog)
    {
        if (logs.Contains(targetLog))
            logs.Remove(targetLog);
    }

    public void FocusLogType(CustomDebugFocusType targetType) => currentFocus = targetType; 

    public void ClearLogs() 
    {
        foreach(Transform t in logContent)
            Destroy(t.gameObject);
    }

    public void DrawLogs()
    {
        ClearLogs();

        //check if any logtype is focused
        if(currentFocus == FocusLogType.None)
        {
            //show all logs
            foreach(var log in logs)
                DrawLog(log);
        }
        else
        {
            //only show focused logtypes
            foreach(var log in logs)
            {
                if(log.logType.ToString() == currentFocus.ToString())
                    DrawLog(log);
            }
        }
    }

    private void DrawLog(CustomDebugLogInfo newLogInfo)
    {
        //instantiate customdebuglogInfo and set logContent as parent
        CustomDebugLoggerLog newLog = Instance(logPrefab, logContent);
        newLog.SetInfo(newLogInfo);
    }
}

public enum CustomDebugFocusType {None, Log, Warning, Error, Exception}