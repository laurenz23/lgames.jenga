using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LGAMES.Jenga
{
    public class StoryIndicatorHandler : MonoBehaviour
    {

        #region :: Variables
        private float newStoryPos;
        #endregion

        #region :: Class Reference
        private List<JengaPieceInvisible> jengaPieceInvisibleList;

        [Header("Class Reference")]
        [SerializeField] private JengaManager jengaManager;
        #endregion

        #region :: Lifecycle
        private void Start()
        {
            jengaPieceInvisibleList = jengaManager.GetJengaPieceIndicatorList();
        }
        #endregion

        #region :: Properties
        public bool IsAllOccupied()
        {
            foreach (JengaPieceInvisible jpi in jengaPieceInvisibleList)
            {
                if (!jpi.IsOccupied())
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region :: Functions
        public void NewStoryIndicator()
        {
            if (IsAllOccupied())
            {
                newStoryPos = jengaManager.GetJengaNextStory();
                newStoryPos += jengaManager.GetJengaPieceHeight();

                jengaManager.SetJengaNextStory(newStoryPos);
                SetNewYPosStoryIndicator(newStoryPos);
            }
            //else
            //{
            //    newStoryPos -= newStoryPos;

            //    jengaManager.SetJengaNextStory(newStoryPos);
            //    SetNewYPosStoryIndicator(newStoryPos);
            //}
        }

        private void SetNewYPosStoryIndicator(float yPos)
        {
            foreach (JengaPieceInvisible jpi in jengaPieceInvisibleList)
            {
                jpi.SetYPosition(yPos);
                jpi.ShowMesh();
            }
        }
        #endregion

    }
}
