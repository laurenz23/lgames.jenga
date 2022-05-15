using UnityEngine;

namespace LGAMES.Jenga
{
    public enum ActionPhase
    {
        SELECTING, // player selecting jenga piece
        REMOVING, // player removing the jenga piece from stack
        STACKING, // player move the jenga piece to the highest stack
        ARRANGING // player arrange the piece to stack 
    }

    public class PlayerHandler : MonoBehaviour
    {

        #region :: Inspector Variables
        // add inspector variable here... 
        // add headers for multiple inspector variables 
        // public variables 
        // private variables 
        #endregion

        #region :: Variables
        // add class variable here...
        // public variables must hide in inspector
        // private variables 
        #endregion

        #region :: Class Reference
        // add class reference here...
        // [Header("Class Reference")]
        #endregion

        #region :: Listeners
        // add listeners here...
        #endregion

        #region :: Lifecycle
        // add class lifecycle here...
        #endregion

        #region :: Properties
        // add class properties here...
        // setter first
        // getter second
        #endregion

        #region :: Events
        // add event listener here...
        #endregion

        #region :: Functions
        #endregion

        #region :: Enumerator 
        // add IEnumerator here...
        #endregion

    }
}
