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

        #region :: Variables 
        private Ray ray;
        private RaycastHit hit;

        private JengaPiece jengaPieceSelected;
        private Vector3 offset;
        private float zCoordinate;
        #endregion 

        #region :: Class Reference
        [SerializeField] private CameraManager cameraManager;
        [SerializeField] private JengaManager jengaManager;
        #endregion 

        #region :: Lifecycles 
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
            // move jenga piece
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
        #endregion 

        #region :: Properties 
        public void SetEnabled()
        {
            enabled = true;
        }
        
        public void SetDisabled()
        {
            enabled = false;
        }
        #endregion 

        #region :: Events 
        private void ScreenInputStart(InputAction.CallbackContext context)
        {
            cameraManager.OnInputBegin();

            ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag(nameof(JengaPiece)))
                {
                    jengaPieceSelected = hit.transform.GetComponentInParent<JengaPiece>();
                    jengaPieceSelected.PieceSelected();

                    zCoordinate = Camera.main.WorldToScreenPoint(jengaPieceSelected.transform.position).z;
                    offset = jengaPieceSelected.transform.position - GetMouseWorldPos();
                }
            }
        }

        private void ScreenInputEnd(InputAction.CallbackContext context)
        {
            if (jengaPieceSelected == null)
                return;

            if (jengaManager.GetActionPhase() == ActionPhase.REMOVING)
                if (jengaPieceSelected.IsRemoveFromStack())
                    jengaPieceSelected.MoveToPieceIndicator();

            jengaPieceSelected.PieceUnselected();
            jengaPieceSelected = null;
        }
        #endregion 

        #region :: Functions 
        private Vector3 GetMouseWorldPos()
        {
            Vector3 mousePoint = Mouse.current.position.ReadValue();
            mousePoint.z = zCoordinate;

            return Camera.main.ScreenToWorldPoint(mousePoint);
        }
        #endregion 

    }
}
