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
    public float yRotOffset;

    private float theta;
    private float radius;
    private float yPosOffset;

    private void Awake()
    {
        Vector3 offset;

        if (cameraMode == CameraMode.FirstPerson)
        {
            offset = FirstPersonOffset;
            
        }
        else
        {
            offset = ThirdPersonOffset;
        }

        Debug.Log($"Start: {transform.position}\nOffset: {offset}\nResult: {transform.position + offset}");

        CameraOffsetTransform.position = transform.position + offset;
        theta = Mathf.Atan(offset.x / offset.z);

        if(offset.x * offset.z < 0)
        {
            theta += Mathf.PI;
        }

        radius = -Mathf.Sqrt(Mathf.Pow(offset.x, 2) + Mathf.Pow(offset.z, 2));
        yPosOffset = offset.y;

    }

    // Update is called once per frame
    void Update()
    {
        float camRot = CameraOffsetTransform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, camRot + yRotOffset, 0);
        transform.position = CameraOffsetTransform.position - new Vector3(radius * Mathf.Sin(Mathf.Deg2Rad * camRot + theta), yPosOffset, radius * Mathf.Cos(Mathf.Deg2Rad * camRot + theta));
    }

    /*private void FirstPersonUpdate()
    {
        float camRot = CameraOffsetTransform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, CameraOffsetTransform.rotation.eulerAngles.y + yRotOffset, 0);
        //transform.position = CameraOffsetTransform.position + Quaternion.Euler(0, CameraOffsetTransform.rotation.eulerAngles.y + yOffset, 0) * FirstPersonOffset - 2 * new Vector3(0, FirstPersonOffset.y, 0);
        transform.position = CameraOffsetTransform.position - new Vector3(radius * Mathf.Sin(Mathf.Deg2Rad * camRot - theta), yPosOffset, radius * Mathf.Cos(Mathf.Deg2Rad * camRot - theta));
    }

    private void ThirdPersonUpdate()
    {
        float camRot = CameraOffsetTransform.rotation.eulerAngles.y;

        transform.rotation = Quaternion.Euler(0, camRot + yOffset, 0);
        //transform.position = CameraOffsetTransform.position + Quaternion.Euler(0, CameraOffsetTransform.rotation.eulerAngles.y + yOffset, 0) * ThirdPersonOffset - 2 * new Vector3(0, ThirdPersonOffset.y, 0);       
        transform.position = CameraOffsetTransform.position - new Vector3(radius * Mathf.Sin(Mathf.Deg2Rad * camRot - theta), ThirdPersonOffset.y, radius * Mathf.Cos(Mathf.Deg2Rad * camRot - theta));
    }*/
}
