using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LGAMES.Jenga
{
    public class JengaPiece : MonoBehaviour
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
        #endregion Variables ----------------------------------------------------------------------

        #region Cycles ----------------------------------------------------------------------------
        private void Start()
        {

        }
        #endregion End Cycles ---------------------------------------------------------------------

        #region Functions -------------------------------------------------------------------------
        public void DragPiece(Vector3 newPosition) 
        {
            this.transform.position = newPosition;
        }
        #endregion Functions ----------------------------------------------------------------------

        #region Getter and Setter -----------------------------------------------------------------
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
        #endregion End Getter and Setter ----------------------------------------------------------

        #region Debugger --------------------------------------------------------------------------
        [ContextMenu("Print Object Name")]
        public void PrintObjectName()
        {
            Debug.Log("Jenga Piece: " + transform.parent.name, this);
        }
        #endregion End Debugger -------------------------------------------------------------------

    }
}
