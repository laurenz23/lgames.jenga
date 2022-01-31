using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LGAMES.Jenga
{
    public class JengaManager : MonoBehaviour
    {

        #region :: Inspector Variables
        [Header("Jenga Setup")]
        [SerializeField] private int numStories = 12;
        [Header("Jenga Piece")]
        [SerializeField] private GameObject jengaPiece_prefab;
        [SerializeField] private List<Material> defaultSkinList;
        [SerializeField] private Material hoverSkin;
        [SerializeField] private Material selectedSkin;
        #endregion

        #region :: Variables 
        private protected int numPerStory = 3;
        private int totalJengaPiece;
        private float jengaPieceWidth;
        private float jengaPieceHeight;
        #endregion

        #region :: Lifecycle
        private void Start()
        {
            totalJengaPiece = numPerStory * numStories;
            jengaPieceWidth = jengaPiece_prefab.GetComponentInChildren<BoxCollider>().size.x;
            jengaPieceHeight = jengaPiece_prefab.GetComponentInChildren<BoxCollider>().size.y;

            SetupJengaPiece();
        }
        #endregion

        #region :: Properties
        public float GetJengaPieceWidth()
        {
            return jengaPieceWidth;
        }
        
        public float GetJengaPieceHeight()
        {
            return jengaPieceHeight;
        }

        public int GetTotalJengaPiece()
        {
            return totalJengaPiece;
        }
        #endregion

        #region :: Functions
        private void SetupJengaPiece()
        {
            bool decrementSkinIndex = false;
            int defaultSkinIndex = 0; 
            float newYPos = 0f;
            float newHorizontalPos;

            for (int x = 0; x < numStories; x++)
            {
                newHorizontalPos = -Mathf.RoundToInt(numPerStory / 2f) + 1f;

                for (int i = 0; i < numPerStory; i++)
                {
                    // populate at z axis jenga piece
                    if (x % 2 == 0)
                        CreateJengaPiece(defaultSkinIndex,
                            new Vector3(0f, newYPos, newHorizontalPos),
                            new Vector3(0f, 0f, 0f));
                    // populate at x axis and rotate jenga piece
                    else
                        CreateJengaPiece(defaultSkinIndex,
                            new Vector3(newHorizontalPos, newYPos, 0f),
                            new Vector3(0f, 90f, 0f));

                    newHorizontalPos += GetJengaPieceWidth();

                    // next jenga piece skin
                    if (decrementSkinIndex)
                        defaultSkinIndex--;
                    else
                        defaultSkinIndex++;
                    // use again the skin and avoid overlapping the list index 
                    if (defaultSkinIndex >= defaultSkinList.Count)
                    {
                        decrementSkinIndex = true;
                        defaultSkinIndex--;
                    }
                    else if (defaultSkinIndex < 0 && decrementSkinIndex)
                    {
                        decrementSkinIndex = false;
                        defaultSkinIndex = 0;
                    }
                }

                // next jenga group story
                newYPos += GetJengaPieceHeight();
            }
        }

        public void CreateJengaPiece(int skinIndex, Vector3 setPosition, Vector3 setRotation)
        {
            GameObject newJengaPiece_obj = Instantiate(jengaPiece_prefab);
            JengaPiece jengaPiece = newJengaPiece_obj.GetComponent<JengaPiece>();
            jengaPiece.GetRigidbody().velocity = Vector3.zero;
            jengaPiece.transform.position = setPosition;
            jengaPiece.transform.eulerAngles = setRotation;
            jengaPiece.SetSkinProperties(
                defaultSkinList[skinIndex], 
                hoverSkin, 
                selectedSkin);
            jengaPiece.UseDefaultSkin();
        }
        #endregion

        #region :: Testing
        [ContextMenu("Calculate Two Numbers")]
        public void CalculateNumber()
        {
            Debug.Log("Calculated: " + Mathf.Round(numPerStory / 2f), this);
        }
        #endregion

    }
}
