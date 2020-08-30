using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VSX.CameraSystem
{
    /// <summary>
    /// This is a simple example of a camera controller that follows the position and rotation of a camera view target on the camera target.
    /// </summary>
    public class ExampleCameraController : CameraController
    {

        protected override void CameraControllerFixedUpdate()
        {
            if (cameraEntity.CurrentViewTarget == null) return;

            // Calculate the target position for the camera
            Vector3 targetPosition = cameraEntity.CurrentViewTarget.transform.position;

            // Update position
            cameraEntity.transform.position = (1 - cameraEntity.CurrentViewTarget.PositionFollowStrength) * cameraEntity.transform.position +
                                        cameraEntity.CurrentViewTarget.PositionFollowStrength * targetPosition;

            // Update rotation
            cameraEntity.transform.rotation = Quaternion.Slerp(cameraEntity.transform.rotation, cameraEntity.CurrentViewTarget.transform.rotation,
                                                    cameraEntity.CurrentViewTarget.RotationFollowStrength);

        }
    }
}

