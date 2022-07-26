using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//2 boyutlu swerve input
public class SwerveInput : MonoBehaviour
{
    private float lastFrameFingerPosX,lastFrameFingerPosY;
    private float moveX,moveY;
    public float moveFactorX => moveX;
    public float moveFactorY => moveY;

    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPosX = Input.mousePosition.x;
            lastFrameFingerPosY = Input.mousePosition.y;
        }else if(Input.GetMouseButton(0))
        {
            moveX = Input.mousePosition.x - lastFrameFingerPosX;
            moveY = Input.mousePosition.y - lastFrameFingerPosY;
            lastFrameFingerPosX = Input.mousePosition.x;
            lastFrameFingerPosY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveX = 0;
            moveY = 0;
        }
    }

}
