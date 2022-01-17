using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LGAMES.Jenga
{
    public class CameraControl : MonoBehaviour
    {

        [SerializeField] private Camera currentCamera;
        [SerializeField] private Transform targetObject;
        [SerializeField] private float distanceToObject;

        private Vector3 previousPosition;

        private void Update()
        {
            CameraRotateAroundTargetObj();
        }

        private void CameraRotateAroundTargetObj() 
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                previousPosition = currentCamera.ScreenToViewportPoint(Mouse.current.position.ReadValue());
            }

            if (Mouse.current.leftButton.isPressed)
            {
                Vector3 newPosition = currentCamera.ScreenToViewportPoint(Mouse.current.position.ReadValue());
                Vector3 direction = previousPosition - newPosition;

                float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
                float rotationAroundXAxis = direction.y * 180; // camera moves vertically

                currentCamera.transform.position = targetObject.position;

                currentCamera.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
                currentCamera.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!

                currentCamera.transform.Translate(new Vector3(0, 0, -distanceToObject));

                previousPosition = newPosition;
            }
        }

    }
}
