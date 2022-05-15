using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LGAMES.Jenga
{
    public class GameManager : MonoBehaviour
    {

        #region :: Inspector Varaibles
        [SerializeField] private float gravityForce;
        #endregion

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

        private void Start()
        {
            if (gravityForce != 0f)
                Physics.gravity = new Vector3(0f, gravityForce, 0f);
        }
        #endregion 

    }
}