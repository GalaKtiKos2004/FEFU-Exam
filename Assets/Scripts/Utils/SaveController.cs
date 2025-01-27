using UnityEngine;

public class SaveController : MonoBehaviour
{
    public static SaveController Instance { get; private set; }

    private const string LastCheckPointKey = "LastCheckPoint";
    private const string CheckPointXKey = "CheckPointX";
    private const string CheckPointYKey = "CheckPointY";
    private const string CheckPointZKey = "CheckPointZ";

    private Vector3 _defaultStartPosition;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void InitializeStartPosition(Vector3 startPosition)
    {
        _defaultStartPosition = startPosition;
    }

    public void SaveCheckPoint(string checkPointID, Vector3 position)
    {
        PlayerPrefs.SetString(LastCheckPointKey, checkPointID);
        PlayerPrefs.SetFloat(CheckPointXKey, position.x);
        PlayerPrefs.SetFloat(CheckPointYKey, position.y);
        PlayerPrefs.SetFloat(CheckPointZKey, position.z);
        PlayerPrefs.Save();
        Debug.Log($"Saved checkpoint: {checkPointID} at {position}");
    }

    public Vector3 LoadLastCheckPointPosition()
    {
        if (!PlayerPrefs.HasKey(LastCheckPointKey))
        {
            Debug.Log("No checkpoint found. Using default start position.");
            Debug.Log($"Default start position: {_defaultStartPosition}");
            return _defaultStartPosition;
        }

        float x = PlayerPrefs.GetFloat(CheckPointXKey);
        float y = PlayerPrefs.GetFloat(CheckPointYKey);
        float z = PlayerPrefs.GetFloat(CheckPointZKey);
        return new Vector3(x, y, z);
    }
}
