//logをのこるクラス
using System.IO;
using UnityEngine;

public class MyLogCallback : MonoBehaviour
{

    FileInfo fileInfo;

    StreamWriter m_writer;
    System.Text.UTF8Encoding encoding;
    // Use this for initialization
    void Start()
    {
        string path;
#if UNITY_EDITOR
        path = Application.streamingAssetsPath;
#else
        path = Application.persistentDataPath;
#endif
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        path += "/log.txt";
        if (File.Exists(path) == true)
        {
            File.Delete(path);
        }

        FileInfo file = new FileInfo(path);
        m_writer = file.CreateText();

        Application.logMessageReceived += LogCallback;

        DontDestroyOnLoad(gameObject);
    }

    void LogCallback(string condition, string stackTrace, LogType type)
    {
        string content = "";
        content += System.DateTime.Now + ":" + type.ToString() + ": " + "\r\n" +
         "condition" + ": " + condition + "\r\n" +
         "stackTrace" + ": " + stackTrace + "\r\n" +
         "--------------------------------------" + "\r\n";


        m_writer.Write(content);
    }

    void Stop()
    {
#if UNITY_EDITOR
        if (UnityEditor.EditorApplication.isPlaying == false)
        {
            if (m_writer != null)
            {
                m_writer.Close();
                m_writer.Dispose();
            }
            Application.logMessageReceived -= LogCallback;
        }
#endif
    }
    void OnDestroy()
    {
        if (m_writer != null)
        {
            m_writer.Close();
            m_writer.Dispose();
        }
        Application.logMessageReceived -= LogCallback;
    }
}
