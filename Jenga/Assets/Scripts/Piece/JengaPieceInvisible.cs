using UnityEngine;

namespace LGAMES.Jenga
{
    public class JengaPieceInvisible : MonoBehaviour
    {

        #region :: Inspector Variables
        [SerializeField] private GameObject meshObj;
        #endregion

        #region :: Variables
        private bool isOccupied = false;
        #endregion

        #region :: Class Reference
        private JengaPiece jengaPiece;
        private StoryIndicatorHandler storyIndicatorHandler;
        #endregion

        #region :: Lifecycle
        // add class lifecycle here...
        #endregion

        #region :: Properties
        public void SetStoryIndicatorHandler(StoryIndicatorHandler storyIndicatorHandler)
        {
            this.storyIndicatorHandler = storyIndicatorHandler;
        }

        public void SetYPosition(float yPos)
        {
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }

        public bool IsOccupied()
        {
            return isOccupied;
        }

        public void ShowMesh()
        {
            meshObj.SetActive(true);
        }

        public void HideMesh()
        {
            meshObj.SetActive(false);
        }
        #endregion

        #region :: Functions
        public void OnJengaPieceEnter(Collider collider)
        {
            if (collider.GetComponent<JengaPieceCollider>())
            {
                jengaPiece = collider.GetComponentInParent<JengaPiece>();
                jengaPiece.transform.rotation = transform.rotation;
                jengaPiece.GetRigidbody().isKinematic = false;

                storyIndicatorHandler.NewStoryIndicator();
                HideMesh();

                isOccupied = true;
            }
        }

        public void OnJengaPieceExit(Collider collider)
        {
            if (collider.GetComponent<JengaPieceCollider>())
            {
                jengaPiece.GetRigidbody().isKinematic = true;
                jengaPiece = null;

                storyIndicatorHandler.NewStoryIndicator();
                ShowMesh();

                isOccupied = false;
            }
        }
        #endregion

    }
}
