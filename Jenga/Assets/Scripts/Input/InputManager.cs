using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LGAMES.Jenga
{
    public class InputManager: MonoBehaviour
    {
        #region Classes ---------------------------------------------------------------------------
        private InputMap inputMap;
        private InputController inputController;
        private GameStateManager gameStateManager;
        #endregion End Classes --------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------
        public delegate void ListenerMouseLeftClickStart(InputAction.CallbackContext context);
        public static event ListenerMouseLeftClickStart EventMouseLeftClickStart;

        public delegate void ListenerMouseLeftClickEnd(InputAction.CallbackContext context);
        public static event ListenerMouseLeftClickEnd EventMouseLeftClickEnd;
        #endregion Events -------------------------------------------------------------------------

        #region Cycles ----------------------------------------------------------------------------
        private void Awake()
        {
            inputMap = new InputMap();
            inputController = GetComponent<InputController>();
            gameStateManager = GameStateManager.Instance();
        }

        private void OnEnable()
        {
            inputMap.Enable();
        }

        private void OnDisable()
        {
            inputMap.Disable();
        }

        private void Start()
        {
            inputMap.ScreenInput.MouseLeftClick.started += context => OnMouseLeftClickStart(context);
            inputMap.ScreenInput.MouseLeftClick.canceled += context => OnMouseLeftClickEnd(context);
        }
        #endregion End Cycles ---------------------------------------------------------------------

        #region Actions ---------------------------------------------------------------------------
        private void OnMouseLeftClickStart(InputAction.CallbackContext context)
        {
            if (gameStateManager.GetCurrentGameState() == GameState.GAMESTART)
                inputController.SetEnabled();

            EventMouseLeftClickStart?.Invoke(context);
        }

        private void OnMouseLeftClickEnd(InputAction.CallbackContext context)
        {
            EventMouseLeftClickEnd?.Invoke(context);

            if (gameStateManager.GetCurrentGameState() == GameState.GAMESTART)
                inputController.SetDisabled();
        }
        #endregion End Actions --------------------------------------------------------------------

    }
}
