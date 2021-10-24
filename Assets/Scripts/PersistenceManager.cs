using System.IO;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;
    
    public string userID;
    public int userScore;
    
    public string bestUserID;
    public int bestUserScore;
    
    
    private void Awake()
    {
        SingletonSetup();
    }

    private void SingletonSetup()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    #region Data Persistence

    [System.Serializable]
    public class SaveData
    {
        public string userID;
        public int userScore;
    }
    
    
    public void SaveUserData()
    {
        SaveData data = new SaveData();
        data.userID = userID;
        data.userScore = userScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    
    public void LoadUserData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            userID = data.userID;
            userScore = data.userScore;
        }
    }
    #endregion
}