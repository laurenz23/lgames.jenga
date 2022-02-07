using UnityEngine;
using System.Collections;

namespace LGAMES.Jenga
{
    /// <summary>
    /// Handle game time that runs in coroutine every given seconds.
    /// Time will stop when game is complete or over.
    /// </summary>
    public class TimeHandler : MonoBehaviour
    {

        #region :: Variables
        private int currentMinute = 0;
        private int currentSecond = 0;
        #endregion

        #region :: Listener
        public delegate void ListenerTime(int timeMin, int timeSec, string timeStr);
        public event ListenerTime EventTime;
        #endregion 

        #region :: Lifecycle
        private void OnEnable()
        {
            GameStateManager.EventGameStateUpdate += OnGameStateUpdate;
        }

        private void OnDisable()
        {
            GameStateManager.EventGameStateUpdate -= OnGameStateUpdate;
        }
        #endregion

        #region :: Properties
        public string GetTimeString()
        {
            return currentMinute.ToString("00") + ":" + currentSecond.ToString("00s");
        }

        public int GetTimeMinute()
        {
            return currentMinute;
        }

        public int GetTimeSecond()
        {
            return currentSecond;
        }
        #endregion

        #region :: Events
        private void TimeUpdate(int timeMin, int timeSec, string timeStr)
        {
            EventTime?.Invoke( timeMin, timeSec, timeStr);
        }

        private void OnGameStateUpdate(GameState newGameState)
        {
            if (newGameState == GameState.GAMESTART)
                StartCoroutine(nameof(Timer));
            else
                StopCoroutine(nameof(Timer));
        }
        #endregion

        #region :: Functions
        public void ResetTime()
        {
            currentMinute = 0;
            currentSecond = 0;
        }
        #endregion

        #region :: Enumerator
        IEnumerator Timer()
        {
            while (true)
            {
                currentSecond++;

                if (currentSecond % 60 == 0)
                {
                    currentMinute++;
                    currentSecond = 0;
                }

                TimeUpdate(currentMinute, currentSecond, GetTimeString());
                yield return new WaitForSeconds(1f);
            }
        }
        #endregion 

    }
}
