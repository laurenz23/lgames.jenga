using UnityEngine;

namespace LGAMES.Jenga
{
    public class PieceChecker : MonoBehaviour
    {

        #region :: Variables
        private JengaPiece jengaPiece;
        #endregion

        #region :: Class Reference
        [SerializeField] private JengaPieceIndicator jengaPieceIndicator;
        #endregion

        #region :: Events
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.GetComponent<JengaPieceCollider>())
            {
                jengaPiece = collider.GetComponentInParent<JengaPiece>();

                if (jengaPiece.jengaPieceIndicator == null)
                {
                    //jengaPiece.jengaPieceIndicator = jengaPieceIndicator;
                    jengaPiece.transform.rotation = transform.rotation;
                    jengaPiece.GetRigidbody().isKinematic = false;
                    jengaPieceIndicator.SlotOccupied();
                }
                else
                    jengaPiece = null;
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.GetComponent<JengaPieceCollider>())
            {
                if (jengaPiece == null)
                    return;

                //jengaPiece.jengaPieceIndicator = null;
                jengaPiece = null;
                jengaPieceIndicator.SlotUnccupied();
            }
        }
        #endregion

    }
}
