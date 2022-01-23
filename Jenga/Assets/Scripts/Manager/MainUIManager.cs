using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace LGAMES.Jenga
{
    public class MainUIManager : MonoBehaviour
    {

        #region Attributes ------------------------------------------------------------------------
        #endregion End Attributes -----------------------------------------------------------------

        #region Cycles ----------------------------------------------------------------------------
        #endregion End Cycles ---------------------------------------------------------------------

        #region Functions -------------------------------------------------------------------------
        public void OnGameStartAction()
        {
            // pause game
            if (GameStateManager.Instance().GetCurrentGameState() == GameState.GAMESTART)
                GameStateManager.Instance().SetGameState(GameState.GAMEPAUSE);
            // start game
            else if (GameStateManager.Instance().GetCurrentGameState() == GameState.GAMEPAUSE)
                GameStateManager.Instance().SetGameState(GameState.GAMESTART);
        }
        #endregion End Functions ------------------------------------------------------------------

    }
}
