#if UNITY_EDITOR 
using UnityEditor;
#endif
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject curUserInputField;
    [SerializeField] private TextMeshProUGUI highScoreOutput;
    private string _userID;


    private void Start()
    {
        highScoreOutput.text = $" Best Score: {PersistenceManager.Instance.highScore} by {PersistenceManager.Instance.bestUser}";
    }

    #region Buttons
    public void StartGame()
    {
        _userID = curUserInputField.GetComponent<TMP_InputField>().text;
        if (_userID != string.Empty)
        {
            PersistenceManager.Instance.curUser = _userID;
            SceneManager.LoadScene(1); 
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    #endregion
}
