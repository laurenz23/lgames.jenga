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
            if (jengaPiece.IsSelected())
            {
                if (collision.transform.GetComponent<JengaPieceCollider>())
                    jengaPiece.GetRigidbody().isKinematic = false;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (jengaPiece.IsSelected())
            {
                if (collision.transform.GetComponent<JengaPieceCollider>())
                    jengaPiece.GetRigidbody().isKinematic = true;
            }
        }
        #endregion

    }
}
