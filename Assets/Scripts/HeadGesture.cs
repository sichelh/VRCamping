using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadGesture : MonoBehaviour
{
    public bool isFacingDown = false;
    // Update is called once per frame
        void Update()
        {
            isFacingDown = DetectFacingDown();
        }
        private bool DetectFacingDown()
        {
            return (CameraAngleFromGround() < 60.0f);
        }
        private float CameraAngleFromGround()
        {
            return Vector3.Angle(Vector3.down, Camera.main.transform.rotation *
            Vector3.forward);
        }


    }
