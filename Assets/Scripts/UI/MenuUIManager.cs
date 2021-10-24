#if UNITY_EDITOR 
using UnityEditor;
#endif
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI userID;
    
    
    public void StartGame()
    {
        SendUserID();
        SceneManager.LoadScene(1);
    }
    
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    
    #region Persistence
    private void SendUserID()
    {
        PersistenceManager.Instance.userID = userID.text;
    }
    #endregion


}
