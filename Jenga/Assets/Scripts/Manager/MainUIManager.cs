using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

namespace LGAMES.Jenga
{
    public class MainUIManager : MonoBehaviour
    {

        #region :: Inspector Variables
        [SerializeField] private Button start_button;
        #endregion

        #region :: Variables 
        private string play_str = "Play"; 
        private string pause_str = "Pause"; 

        private TextMeshProUGUI start_buttonText;
        #endregion 

        #region :: Lifecycles 
        private void Start()
        {
            start_buttonText = start_button.GetComponentInChildren<TextMeshProUGUI>();
            start_buttonText.text = play_str;
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
        #endregion

        #region :: Functions 
        private void SetGamePause()
        {
            start_buttonText.text = pause_str;
            GameStateManager.Instance().SetGameState(GameState.GAMEPAUSE);
        }

        private void SetGameResume()
        {
            start_buttonText.text = play_str;
            GameStateManager.Instance().SetGameState(GameState.GAMESTART);
        }
        #endregion

    }
}
