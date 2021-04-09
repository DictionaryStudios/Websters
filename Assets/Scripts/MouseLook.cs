using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensx = 10f;
    float xrotation;
    float yrotation;
    float rawyrotation;
    public float maxup = 60f, maxdown = -60f;
    public bool ylock;
    public bool xlock;
    Quaternion originalRotation;
    //  public float xrotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (xlock == false)
        {
            xrotation = Input.GetAxis("Mouse X") * sensx;
            transform.Rotate(Vector3.up, xrotation);
        }
        if (ylock == false)
        {
            float mouseY = Input.GetAxis("Mouse Y") * sensx;
            yrotation -= mouseY;
            yrotation = Mathf.Clamp(yrotation, maxdown, maxup);
            transform.localRotation = Quaternion.Euler(yrotation, 0f, 0f);
            //rawyrotation += Input.GetAxis("Mouse Y") * sensx;
            //yrotation = Cangle(rawyrotation, maxdown, maxup);
            //Quaternion yqthing = Quaternion.AngleAxis(yrotation, -Vector3.right);
            //transform.localRotation = originalRotation * yqthing;
          //  transform.Rotate(Vector3.left, yrotation);
        }
        //  xrotation += Input.GetAxis("Mouse X") * sensx;
        //transform.Rotate((Input.GetAxis("Mouse X") * sensx * Time.deltaTime));
    }
    public static float Cangle(float angle,float min,float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
