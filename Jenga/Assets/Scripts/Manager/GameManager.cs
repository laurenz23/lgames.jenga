using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LGAMES.Jenga
{
    public class GameManager : MonoBehaviour
    {

        #region Class Instance --------------------------------------------------------------------
        private static GameManager instance;

        public static GameManager Instance()
        {
            return instance;
        }
        #endregion End Class Instance -------------------------------------------------------------

        #region Cycles ----------------------------------------------------------------------------
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
        #endregion End Cycles ---------------------------------------------------------------------

    }
}