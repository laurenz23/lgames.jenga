using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LGAMES.Jenga
{
    public class GameManager : MonoBehaviour
    {

        #region :: Class Reference
        private static GameManager instance;

        public static GameManager Instance()
        {
            return instance;
        }
        #endregion 

        #region :: Lifecycles 
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
        #endregion 

    }
}