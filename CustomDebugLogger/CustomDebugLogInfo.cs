using UnityEngine;

[System.Serializable]
public class CustomDebugLogInfo
{
    public String logTime;
    public String logText;
    public LogType logType;
    public Color logColor;

    public CustomDebugLogInfo(String logText, LogType logType)
    {
        this.logText = logText;
        this.logType = logType;
        logTime = DateTime.Now.ToString("HH:mm:ss");
        logColor = GetLogColor(logType);
    }

    private Color GetLogColor(LogType logType)
    {
        switch(logType)
        {
            case LogType.Error:
                return Color.red;
            case LogType.Exception:
                return Color.orange;
            case LogType.Warning:
                return Color.green;
            default:
                return Color.white;
        }
    }
}