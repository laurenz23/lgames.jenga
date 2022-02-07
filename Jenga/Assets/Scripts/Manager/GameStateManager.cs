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

        #region :: Variables 
        private GameState currentGameState;
        #endregion 

        #region :: Class Reference
        private static GameStateManager instance;

        public static GameStateManager Instance()
        {
            return instance;
        }
        #endregion 

        #region :: Listeners 
        public delegate void ListenerGameStateUpdate(GameState newGameState);
        public static event ListenerGameStateUpdate EventGameStateUpdate;
        #endregion 

        #region :: Cycles 
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        private void Start()
        {
            SetGameState(GameState.GAMESTART);
        }
        #endregion 

        #region :: Properties 
        public GameState GetCurrentGameState()
        {
            return currentGameState;
        }
        #endregion 

        #region :: Events 
        public void SetGameState(GameState newGameState)
        {
            currentGameState = newGameState;
            EventGameStateUpdate?.Invoke(currentGameState);
        }
        #endregion 

    }
}
