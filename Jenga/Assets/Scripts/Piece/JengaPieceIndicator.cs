using UnityEngine;

namespace LGAMES.Jenga
{
    public class JengaPieceIndicator : MonoBehaviour
    {

        #region :: Inspector Variables
        [SerializeField] private GameObject meshObj;
        #endregion

        #region :: Variables
        private bool isOccupied = false;
        #endregion

        #region :: Class Reference
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
        public void SlotOccupied()
        {
            isOccupied = true;
            storyIndicatorHandler.NewStoryIndicator();
            HideMesh();
        }

        public void SlotUnccupied()
        {
            isOccupied = false;
            storyIndicatorHandler.NewStoryIndicator();
            ShowMesh();
        }
        #endregion

    }
}
