using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LGAMES.Jenga
{
    public class ScreenInput : MonoBehaviour
    {

        #region Variables -------------------------------------------------------------------------
        private JengaPiece jengaPiece;
        private JengaPiece jengaPieceSelected;
        private Vector3 offset;
        private float zCoordinate;
        #endregion End Variables ------------------------------------------------------------------

        #region Cycles ----------------------------------------------------------------------------
        void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("JengaPiece"))
                {
                    if (jengaPiece != null)
                        jengaPiece.SetDefaultSkin();

                    jengaPiece = hit.transform.GetComponentInParent<JengaPiece>();
                    jengaPiece.SetHoverSkin();

                    if (Mouse.current.leftButton.wasPressedThisFrame)
                    {
                        jengaPieceSelected = jengaPiece;
                        jengaPieceSelected.SetSelectedSkin();

                        zCoordinate = Camera.main.WorldToScreenPoint(jengaPieceSelected.transform.position).z;
                        offset = jengaPieceSelected.transform.position - GetMouseWorldPos();
                    }
                }
                else
                {
                    if (jengaPiece != null)
                    {
                        jengaPiece.SetDefaultSkin();
                        jengaPiece = null;
                    }
                }
            }
            else
            {
                if (jengaPiece != null)
                {
                    jengaPiece.SetDefaultSkin();
                    jengaPiece = null;
                }
            }

            if (jengaPieceSelected != null)
            { 
                if (Mouse.current.leftButton.isPressed)
                {
                    jengaPieceSelected.transform.position = GetMouseWorldPos() + offset;
                }
            }
        }
        #endregion End Cycles ---------------------------------------------------------------------

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
