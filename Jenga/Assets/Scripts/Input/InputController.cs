using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LGAMES.Jenga
{
    /// <summary>
    /// This script is being enabled and disabled 
    /// from <c>InputManager</c>. 
    /// If input is detected the script is enabled, 
    /// once input is ended the script is disabled.
    /// </summary>
    public class InputController: MonoBehaviour
    {

        #region Attributes ------------------------------------------------------------------------
        [SerializeField] private CameraManager cameraManager;
        #endregion End Attributes -----------------------------------------------------------------

        #region Variables -------------------------------------------------------------------------
        private Ray ray;
        private RaycastHit hit;

        private JengaPiece jengaPieceSelected;
        private Vector3 offset;
        private float zCoordinate;
        #endregion End Variables ------------------------------------------------------------------

        #region Cycles ----------------------------------------------------------------------------
        private void OnEnable()
        {
            InputManager.EventMouseLeftClickStart += ScreenInputStart;
            InputManager.EventMouseLeftClickEnd += ScreenInputEnd;
        }

        private void OnDisable()
        {
            InputManager.EventMouseLeftClickStart -= ScreenInputStart;
            InputManager.EventMouseLeftClickEnd -= ScreenInputEnd;
        }

        private void Start()
        {
            SetDisabled();
        }

        private void Update()
        {
            // move piece
            if (jengaPieceSelected != null)
            {
                jengaPieceSelected.transform.position = GetMouseWorldPos() + offset;
            }
            // move camera
            else
            {
                cameraManager.OnInputPerforming();
            }
        }
        #endregion End Cycles ---------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------
        public void SetEnabled()
        {
            enabled = true;
        }
        
        public void SetDisabled()
        {
            enabled = false;
        }
        #endregion End Properties -----------------------------------------------------------------

        #region Actions ---------------------------------------------------------------------------
        private void ScreenInputStart(InputAction.CallbackContext context)
        {
            cameraManager.OnInputBegin();

            ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("JengaPiece"))
                {
                    jengaPieceSelected = hit.transform.GetComponentInParent<JengaPiece>();
                    jengaPieceSelected.SetSelectedSkin();

                    zCoordinate = Camera.main.WorldToScreenPoint(jengaPieceSelected.transform.position).z;
                    offset = jengaPieceSelected.transform.position - GetMouseWorldPos();
                }
            }
        }

        private void ScreenInputEnd(InputAction.CallbackContext context)
        {
            if (jengaPieceSelected == null)
                return;

            jengaPieceSelected.SetDefaultSkin();
            jengaPieceSelected = null;
        }
        #endregion End Actions --------------------------------------------------------------------

        #region Functions -------------------------------------------------------------------------
        private Vector3 GetMouseWorldPos()
        {
            Vector3 mousePoint = Mouse.current.position.ReadValue();
            mousePoint.z = zCoordinate;

            return Camera.main.ScreenToWorldPoint(mousePoint);
        }
        #endregion End Functions ------------------------------------------------------------------

    }
}
