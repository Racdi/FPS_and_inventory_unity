using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform playerPosition;

    public float Sensitivity = 200f;
    public float visionAngle = 90f;
    [Range(0,90)]

    private float headCameraAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        float SensitivityCorrection = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime;

        if(SensitivityCorrection > 0f){
            Sensitivity = Sensitivity + 50f;
        }
        else if(SensitivityCorrection < 0f){
            Sensitivity = Sensitivity - 50f;
        }

        if(Sensitivity <= 1f){
            Sensitivity = 25f;
        }

        headCameraAngle -= mouseY;
        headCameraAngle = Mathf.Clamp(headCameraAngle, -visionAngle, visionAngle);

        transform.localRotation = Quaternion.Euler(headCameraAngle, 0f, 0f);

        playerPosition.Rotate(Vector3.up * mouseX);

    }

}
