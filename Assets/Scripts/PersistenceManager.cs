using System.IO;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;
    
    public string curUser;
    public string bestUser;
    public int highScore;
    
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadUser();
    }

    #region Data Persistence
    [System.Serializable]
    public class SaveData
    {
        public string bestUser;
        public int highScore;
    }
    
    public void SaveUser()
    {
        SaveData data = new SaveData();
        data.bestUser = bestUser;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    
    public void LoadUser()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestUser = data.bestUser;
            highScore = data.highScore;
        }
    }
    #endregion
}