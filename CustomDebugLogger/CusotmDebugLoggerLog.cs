using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomDebugLoggerLog : MonoBehaviour
{
    private CustomDebugLogInfo storedInfo;
    [SerializeField] private TMP_Text logText;

    public void SetInfo(CustomDebugLogInfo newLog)
    {
        storedInfo = newLog;
        CustomDebugLogInfo l = storedInfo;

        logText.text = "[" + l.logTime + "] " + l.logText;
        logText.color = l.logColor;
    }  

    public void RemoveLog()
    {
        CustomDebugLogger.Instance.RemoveLog(this);
        Destroy(gameObject);
    }
}