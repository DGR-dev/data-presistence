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

    private void SaveUserID()
    {
        
       
    }

    private void SaveUserScore()
    {
        
        
    }
    
    #endregion
}