using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LGAMES.Jenga
{
    public enum GameState
    {
        GAMESTART,
        GAMEPAUSE,
        GAMECOMPLETE,
        GAMEOVER
    }

    public interface IGameState
    {
        public abstract void OnGameStateUpdate(GameState newGameState);
    }

    public class GameStateManager : MonoBehaviour
    {

        #region Class Instance --------------------------------------------------------------------
        private static GameStateManager instance;

        public static GameStateManager Instance()
        {
            return instance;
        }
        #endregion End Class Instance -------------------------------------------------------------

        #region Variables -------------------------------------------------------------------------
        private GameState currentGameState;
        #endregion End Variables ------------------------------------------------------------------

        #region Listener --------------------------------------------------------------------------
        public delegate void ListenerGameStateUpdate(GameState newGameState);
        public static event ListenerGameStateUpdate EventGameStateUpdate;
        #endregion End Listener -------------------------------------------------------------------

        #region Cycles ----------------------------------------------------------------------------
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
        #endregion End Cycles ---------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------
        public GameState GetCurrentGameState()
        {
            return currentGameState;
        }
        #endregion End Properties -----------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------
        public void SetGameState(GameState newGameState)
        {
            currentGameState = newGameState;
            EventGameStateUpdate?.Invoke(currentGameState);
        }
        #endregion End Events ---------------------------------------------------------------------

    }
}
