using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/MouseLock")]
public class CamHero : MonoBehaviour
{
    public enum RotationAxes{MouseXandY = 0, MouseX = 1, MouseY = 2 };
    public RotationAxes axes = RotationAxes.MouseXandY;
    public float sensitivityX = 2F;//чувствительность мышки Х
    public float sensitivityY = 2F;//чувствительность мышки Y
    public float min_X = -360F;
    public float min_Y = -360F;
    public float max_X = 360F;
    public float max_Y = 360F;
    //минимальные и максимальные углы по осям Х и Y
     float rotationY = 0F;
     float rotationX = 0F;

    Quaternion originalRotation;

    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        originalRotation = transform.localRotation;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F){
            angle +=360F;
        };
        if(angle>360F){
            angle -=360F;
        };
        return Mathf.Clamp(angle,min,max);
    }
    
    void Update()
    {
        if (axes == RotationAxes.MouseXandY)
        {
            rotationX+= Input.GetAxis("Mouse X") * sensitivityX;
            rotationY+= Input.GetAxis("Mouse Y") * sensitivityY;
            rotationX = ClampAngle(rotationX, min_X, max_X);
            rotationY = ClampAngle(rotationY, min_Y, max_Y);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX,Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY,Vector3.right);
            transform.localRotation =originalRotation*xQuaternion*yQuaternion;
        }
        else if(axes == RotationAxes.MouseX)
        {
            rotationX+=Input.GetAxis("Mouse X")* sensitivityX;
            rotationX = ClampAngle(rotationX,min_X,max_X);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX,Vector3.up);
            transform.localRotation =originalRotation*xQuaternion;
        }
        else if(axes == RotationAxes.MouseY)
        {
            rotationY+=Input.GetAxis("Mouse Y")* sensitivityY;
            rotationY = ClampAngle(rotationY,min_Y,max_Y);
            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY,Vector3.right);
            transform.localRotation =originalRotation*yQuaternion;
        }
    }
}
