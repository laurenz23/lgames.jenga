using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LGAMES.Jenga
{
    public class JengaManager : MonoBehaviour
    {

        #region :: Inspector Variables
        [Header("Jenga Setup")]
        [SerializeField] private int numStory = 12;
        [Header("Jenga Piece")]
        [SerializeField] private GameObject jengaPiece_prefab;
        [SerializeField] private List<Material> defaultSkinList;
        [SerializeField] private Material hoverSkin;
        [SerializeField] private Material selectedSkin;
        [Header("Jenga Piece Invisible")]
        [SerializeField] private GameObject jengaPieceInvisible_prefab;
        #endregion

        #region :: Variables 
        private protected int numPerStory = 3;
        private int totalJengaPiece;
        private float jengaPieceWidth;
        private float jengaPieceHeight;
        private float pieceNewYPos = 0;
        #endregion

        #region :: Class Reference
        [Header("Class Reference")]
        [SerializeField] private StoryIndicatorHandler storyIndicatorHandler;

        private List<JengaPiece> jengaPieceList = new List<JengaPiece>();
        private List<JengaPieceInvisible> jengaPieceInvisibleList = new List<JengaPieceInvisible>();
        #endregion

        #region :: Lifecycle
        private void Start()
        {
            totalJengaPiece = numPerStory * numStory;
            jengaPieceWidth = jengaPiece_prefab.GetComponentInChildren<BoxCollider>().size.x;
            jengaPieceHeight = jengaPiece_prefab.GetComponentInChildren<BoxCollider>().size.y;

            SetupJengaPiece();
        }
        #endregion

        #region :: Properties
        public List<JengaPiece> GetJengaPieceList()
        {
            return jengaPieceList;
        }

        public List<JengaPieceInvisible> GetJengaPieceIndicatorList()
        {
            return jengaPieceInvisibleList;
        }

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

        public int GetJengaNumberStory()
        {
            return numStory;
        }

        public void SetJengaNextStory(float value)
        {
            pieceNewYPos = value;
        }

        public float GetJengaNextStory()
        {
            return pieceNewYPos;
        }
        #endregion

        #region :: Functions
        private void SetupJengaPiece()
        {
            bool decrementSkinIndex = false;
            int defaultSkinIndex = 0; 
            float newHorizontalPos;

            for (int x = 0; x <= numStory; x++)
            {
                newHorizontalPos = -Mathf.RoundToInt(numPerStory / 2f) + 1f;

                for (int i = 0; i < numPerStory; i++)
                {
                    if (x == numStory)
                    {
                        // populate at z axis jenga piece invisible
                        if (x % 2 == 0)
                            CreateJengaPieceInvisible(
                                new Vector3(0f, pieceNewYPos, newHorizontalPos),
                                Vector3.zero);
                        // populate at x axis and rotate jenga piece
                        else
                            CreateJengaPieceInvisible(
                                new Vector3(0f, pieceNewYPos, newHorizontalPos),
                                new Vector3(0f, 90f, 0f));
                    }
                    else
                    {
                        // populate at z axis jenga piece
                        if (x % 2 == 0)
                            CreateJengaPiece(defaultSkinIndex,
                                new Vector3(0f, pieceNewYPos, newHorizontalPos),
                                Vector3.zero);
                        // populate at x axis and rotate jenga piece
                        else
                            CreateJengaPiece(defaultSkinIndex,
                                new Vector3(newHorizontalPos, pieceNewYPos, 0f),
                                new Vector3(0f, 90f, 0f));

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

                    newHorizontalPos += GetJengaPieceWidth();
                }

                // next jenga group story
                pieceNewYPos += GetJengaPieceHeight();
            }

            // remove the annoying moving bug when jenga piece stack is getting higher
            foreach (JengaPiece jp in jengaPieceList)
            {
                jp.GetRigidbody().velocity = Vector3.zero;
                jp.GetRigidbody().angularVelocity = Vector3.zero;
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

            jengaPieceList.Add(jengaPiece);
        }

        public void CreateJengaPieceInvisible(Vector3 setPosition, Vector3 setRotation)
        {
            GameObject newJengaPieceInvisible_obj = Instantiate(jengaPieceInvisible_prefab);
            JengaPieceInvisible jengaPieceInvisible = newJengaPieceInvisible_obj.GetComponent<JengaPieceInvisible>();
            jengaPieceInvisible.SetStoryIndicatorHandler(storyIndicatorHandler);
            jengaPieceInvisible.transform.position = setPosition;
            jengaPieceInvisible.transform.eulerAngles = setRotation;

            jengaPieceInvisibleList.Add(jengaPieceInvisible);
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
