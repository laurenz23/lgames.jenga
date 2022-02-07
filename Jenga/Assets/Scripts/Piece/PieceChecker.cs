using UnityEngine;

namespace LGAMES.Jenga
{
    public class PieceChecker : MonoBehaviour
    {

        #region :: Class Reference
        [SerializeField] private JengaPieceInvisible jengaPieceInvisible;
        #endregion

        #region :: Events
        private void OnTriggerEnter(Collider other)
        {
            jengaPieceInvisible.OnJengaPieceEnter(other);
        }

        private void OnTriggerExit(Collider other)
        {
            jengaPieceInvisible.OnJengaPieceExit(other);
        }
        #endregion

    }
}
