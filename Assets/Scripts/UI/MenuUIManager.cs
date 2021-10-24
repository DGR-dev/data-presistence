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
        SaveUserID();
        SceneManager.LoadScene(1);
    }

    private void SaveUserID()
    {
        PersistenceManager.Instance.userID = userID.text;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
