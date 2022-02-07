using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace LGAMES.Jenga
{
    public class InGameUIManager: MonoBehaviour
    {

        #region :: Inspector Variables
        [Header("Top Navigator")]
        [SerializeField] private TextMeshProUGUI timeTextMP;
        [SerializeField] private Button pauseButton;

        [Header("Pause Section")]
        [SerializeField] private Transform pauseMenu;
        #endregion

        #region :: Variables 
        #endregion

        #region :: Class Reference
        [Header("Class Reference")]
        public TimeHandler timeHandler;
        #endregion

        #region :: Lifecycles 
        private void OnEnable()
        {
            timeHandler.EventTime += OnTimeUpdate;
        }

        private void OnDisable()
        {
            timeHandler.EventTime -= OnTimeUpdate;
        }

        private void Start()
        {
            pauseMenu.gameObject.SetActive(false);
        }
        #endregion 

        #region :: Events
        public void OnUIGameStateAction()
        {
            // set current game state to pause  
            if (GameStateManager.Instance().GetCurrentGameState() == GameState.GAMESTART)
            {
                SetGamePause();
            }
            // set current game state to resume 
            else if (GameStateManager.Instance().GetCurrentGameState() == GameState.GAMEPAUSE)
            {
                SetGameResume();
            }
        }

        public void OnSettingAction()
        {
            Debug.Log("Settings", this);
        }

        public void OnMainMenuAction()
        {
            SceneManager.LoadScene("MainMenuScene");
        }

        private void OnTimeUpdate(int timeMin, int timeSec, string timeStr)
        {
            timeTextMP.SetText(timeStr);
        }
        #endregion

        #region :: Functions 
        private void SetGamePause()
        {
            pauseMenu.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);

            GameStateManager.Instance().SetGameState(GameState.GAMEPAUSE);
        }

        private void SetGameResume()
        {
            pauseMenu.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(true);

            GameStateManager.Instance().SetGameState(GameState.GAMESTART);
        }
        #endregion

    }
}
