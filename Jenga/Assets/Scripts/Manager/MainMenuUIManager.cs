using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{

    #region :: Inspector Variables
    [SerializeField] private Button startButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button exitButton;
    #endregion

    #region :: Variables
    // add class variable here...
    // public variables must hide in inspector
    // private variables 
    #endregion

    #region :: Class Reference
    // add class reference here...
    // [Header("Class Reference")]
    #endregion

    #region :: Listeners
    // add listeners here...
    #endregion

    #region :: Lifecycle
    private void OnApplicationQuit()
    {
        Debug.Log("Application Quit", this);
    }
    #endregion

    #region :: Properties
    // add class properties here...
    // setter first
    // getter second
    #endregion

    #region :: Events
    public void OnStartAction()
    {
        SceneManager.LoadScene("MainInGameScene");
    }

    public void OnSettingAction()
    {
        Debug.Log("Setting Action", this);
    }

    public void OnExitAction()
    {
        Application.Quit();
    }
    #endregion

    #region :: Functions
    // add functions or methods here... 
    #endregion

    #region :: Enumerator 
    // add IEnumerator here...
    #endregion

}
