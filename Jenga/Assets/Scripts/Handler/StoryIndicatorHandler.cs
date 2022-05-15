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
        private List<JengaPieceIndicator> jengaPieceIndicatorList;

        [Header("Class Reference")]
        [SerializeField] private JengaManager jengaManager;
        #endregion

        #region :: Lifecycle
        private void Start()
        {
            jengaPieceIndicatorList = jengaManager.GetJengaPieceIndicatorList();
        }
        #endregion

        #region :: Properties
        public bool IsAllOccupied()
        {
            foreach (JengaPieceIndicator jpi in jengaPieceIndicatorList)
            {
                if (!jpi.IsOccupied())
                {
                    return false;
                }
            }

            return true;
        }

        public Vector3 GetIndicatorRotationEulerAngles()
        {
            return jengaPieceIndicatorList[0].transform.eulerAngles;
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
            foreach (JengaPieceIndicator jpi in jengaPieceIndicatorList)
            {
                jpi.SetYPosition(yPos);
                jpi.ShowMesh();
            }
        }
        #endregion

    }
}
