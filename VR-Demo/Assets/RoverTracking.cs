using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverTracking : MonoBehaviour
{
    public enum CameraMode
    {
        FirstPerson,
        ThirdPerson
    }

    public Transform CameraOffsetTransform;
    public CameraMode cameraMode;
    public Vector3 FirstPersonOffset;
    public Vector3 ThirdPersonOffset;
    public float turnSpeed = 10f;
    public float yOffset;

    private Vector3 lastPos = Vector3.zero;
    private Vector3 curPos = Vector3.zero;

    private void Awake()
    {
        if (cameraMode == CameraMode.FirstPerson)
        {
            CameraOffsetTransform.position = transform.position + FirstPersonOffset;
        }
        else
        {
            CameraOffsetTransform.position = transform.position + ThirdPersonOffset;
        }
        
    }

    private void Start()
    {
        curPos = transform.position;
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraMode == CameraMode.FirstPerson)
        {
            FirstPersonUpdate();
        }
        else
        {
            ThirdPersonUpdate();
        }
    }

    private void FirstPersonUpdate()
    {
        transform.rotation = Quaternion.Euler(0, CameraOffsetTransform.rotation.eulerAngles.y + yOffset, 0);
        transform.position = CameraOffsetTransform.position - FirstPersonOffset;
    }

    private void ThirdPersonUpdate()
    {
        /*lastPos = curPos;
        curPos = transform.position;

        if(curPos != lastPos)
        {
            //transform.LookAt(curPos + (curPos - lastPos));
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(curPos - lastPos), Time.deltaTime * turnSpeed);
        }*/

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, CameraOffsetTransform.rotation.eulerAngles.y + yOffset, transform.rotation.eulerAngles.z);
        transform.position = CameraOffsetTransform.position - ThirdPersonOffset;
    }
}
