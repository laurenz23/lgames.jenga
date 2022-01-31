using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LGAMES.Jenga
{
    public class CameraManager : MonoBehaviour
    {

        #region :: Inspector Variables
        [SerializeField] private Camera currentCamera;
        [SerializeField] private Transform targetObject;
        //[SerializeField] private float distanceToObject;
        #endregion

        #region :: Variables
        private Vector3 previousPosition;
        #endregion

        #region :: Lifecycles
        private void Start()
        {
            transform.position = targetObject.position;
        }
        #endregion 

        #region :: Properties
        public Camera GetCurrentCamera()
        {
            return currentCamera;
        }
        #endregion 

        #region :: Functions 
        public void OnInputBegin()
        {
            previousPosition = currentCamera.ScreenToViewportPoint(Mouse.current.position.ReadValue());
        }

        public void OnInputPerforming()
        {
            Vector3 newPosition = currentCamera.ScreenToViewportPoint(Mouse.current.position.ReadValue());
            Vector3 direction = previousPosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = direction.y * 180; // camera moves vertically

            transform.position = targetObject.position;

            transform.Rotate(new Vector3(1, 0, 0),
                rotationAroundXAxis);
            transform.Rotate(new Vector3(0, 1, 0),
                rotationAroundYAxis,
                Space.World); // <— This is what makes it work!

            // only works when you apply distanceToObject functionality
            //transform.Translate(new Vector3(
            //    transform.position.x, 
            //    transform.position.y, 
            //    -distanceToObject));

            previousPosition = newPosition;
        }
        #endregion 

    }
}
