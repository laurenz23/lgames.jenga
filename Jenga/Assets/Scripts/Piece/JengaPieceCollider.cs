using UnityEngine;

namespace LGAMES.Jenga
{
    public class JengaPieceCollider : MonoBehaviour
    {

        #region :: Class Reference
        [Header("Class Reference")]
        [SerializeField] private JengaPiece jengaPiece;
        #endregion

        #region :: Lifecycle
        private void Start()
        {
            enabled = false;
        }
        #endregion

        #region :: Events
        private void OnCollisionEnter(Collision collision)
        {
            jengaPiece.JengaPieceCollisionEnter(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            jengaPiece.JengaPieceCollisionExit(collision);
        }
        #endregion

    }
}
