using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LGAMES.Jenga
{
    public class JengaPiece : MonoBehaviour, IGameState
    {

        #region Attributes ------------------------------------------------------------------------
        [Header("Properties")]
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Rigidbody _rigidbody;
        [Header("Material Skin")]
        [SerializeField] private Material defaultSkin;
        [SerializeField] private Material hoverSkin;
        [SerializeField] private Material selectedSkin;
        #endregion End Attributes -----------------------------------------------------------------

        #region Variables -------------------------------------------------------------------------
        private Vector3 savedVelocity = Vector3.zero;
        private Vector3 savedAngularVelocity = Vector3.zero;
        #endregion Variables ----------------------------------------------------------------------

        #region Cycles ----------------------------------------------------------------------------
        private void OnEnable()
        {
            GameStateManager.EventGameStateUpdate += OnGameStateUpdate;
        }

        private void OnDisable()
        {
            GameStateManager.EventGameStateUpdate -= OnGameStateUpdate;
        }
        #endregion End Cycles ---------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------
        
        public Rigidbody GetRigidbody()
        {
            return _rigidbody;
        }

        public void SetDefaultSkin()
        {
            _meshRenderer.material = defaultSkin;
        }

        public void SetHoverSkin()
        {
            _meshRenderer.material = hoverSkin;
        }

        public void SetSelectedSkin()
        {
            _meshRenderer.material = selectedSkin;
        }

        #endregion End Properties -----------------------------------------------------------------

        #region Actions ---------------------------------------------------------------------------
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
        #endregion End Actions --------------------------------------------------------------------

        #region Functions -------------------------------------------------------------------------
        public void DragPiece(Vector3 newPosition) 
        {
            transform.position = newPosition;
        }
        #endregion Functions ----------------------------------------------------------------------

        #region Debugger --------------------------------------------------------------------------
        [ContextMenu("Print Object Name")]
        public void PrintObjectName()
        {
            Debug.Log("Jenga Piece: " + transform.name, this);
        }
        #endregion End Debugger -------------------------------------------------------------------

    }
}
