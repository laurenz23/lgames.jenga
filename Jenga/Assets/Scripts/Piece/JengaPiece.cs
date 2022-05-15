using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LGAMES.Jenga
{
    public class JengaPiece : MonoBehaviour, IGameState
    {

        #region :: Inspector Variables
        [Header("Properties")]
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Rigidbody _rigidbody;
        #endregion 

        #region :: Variables 
        private bool isSelected = false;

        private Material defaultSkin;
        private Material hoverSkin;
        private Material selectedSkin;

        private Vector3 defaultPos;
        private Vector3 savedVelocity = Vector3.zero;
        private Vector3 savedAngularVelocity = Vector3.zero;
        #endregion

        #region :: Class Reference
        [Header("Class Reference")]
        public JengaPieceCollider jengaPieceCollider;
        [HideInInspector] public JengaPieceIndicator jengaPieceIndicator;

        private JengaManager jengaManager;
        private StoryIndicatorHandler storyIndicatorHandler;
        #endregion

        #region :: Lifecycles 
        private void OnEnable()
        {
            GameStateManager.EventGameStateUpdate += OnGameStateUpdate;
        }

        private void OnDisable()
        {
            GameStateManager.EventGameStateUpdate -= OnGameStateUpdate;
        }

        private void Start()
        {
            jengaManager = JengaManager.GetInstance();
            storyIndicatorHandler = jengaManager.GetStoryIndicatorHandler();
        }
        #endregion

        #region :: Properties 
        public Rigidbody GetRigidbody()
        {
            return _rigidbody;
        }

        public void SetSkinProperties(
            Material defaultSkin,
            Material hoverSkin,
            Material selectedSkin)
        {
            this.defaultSkin = defaultSkin;
            this.hoverSkin = hoverSkin;
            this.selectedSkin = selectedSkin;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
            defaultPos = position;
        }

        public JengaPieceCollider GetJengaPieceCollider()
        {
            return jengaPieceCollider;
        }

        public bool IsSelected()
        {
            return isSelected;
        }

        public bool IsRemoveFromStack()
        {
            Vector3 computePos = new Vector3(0f, defaultPos.y, 0f) - transform.position;

            if (computePos.magnitude >= 3.5f)
                return true;
            return false;
        }
        #endregion 

        #region :: Events 
        public void OnGameStateUpdate(GameState newGameState)
        {
            switch (newGameState)
            {
                case GameState.GAMESTART:
                    _rigidbody.isKinematic = false;
                    _rigidbody.AddForce(savedVelocity, ForceMode.VelocityChange);
                    _rigidbody.AddTorque(savedAngularVelocity, ForceMode.VelocityChange);
                    break;
                case GameState.GAMEPAUSE:
                    savedVelocity = _rigidbody.velocity;
                    savedAngularVelocity = _rigidbody.angularVelocity;
                    _rigidbody.isKinematic = true;
                    break;
            }
        }
        #endregion 

        #region :: Functions
        public void PieceSelected()
        {
            isSelected = true;
            jengaPieceCollider.enabled = true;
            IsRemoveFromStack();
            UseSelectedSkin();
            jengaManager.SetActionPhase(ActionPhase.REMOVING);
        }

        public void PieceUnselected()
        {
            isSelected = false;
            jengaPieceCollider.enabled = false;
            UseDefaultSkin();
        }

        public void DragPiece(Vector3 newPosition)
        {
            transform.position = newPosition;
        }

        public void UseDefaultSkin()
        {
            _meshRenderer.material = defaultSkin;
        }

        public void UseHoverSkin()
        {
            _meshRenderer.material = hoverSkin;
        }

        public void UseSelectedSkin()
        {
            _meshRenderer.material = selectedSkin;
        }

        public void MoveToPieceIndicator() 
        {
            jengaManager.SetActionPhase(ActionPhase.STACKING);
            transform.position = new Vector3(
                0f, 
                jengaManager.GetJengaNextStory() + jengaManager.GetJengaPieceHeight(), 
                0f);
            transform.eulerAngles = storyIndicatorHandler.GetIndicatorRotationEulerAngles();
        }
        #endregion 

        #region :: Testing
        [ContextMenu("Print Object Name")]
        public void PrintObjectName()
        {
            Debug.Log("Jenga Piece: " + transform.name, this);
        }
        #endregion 

    }
}
