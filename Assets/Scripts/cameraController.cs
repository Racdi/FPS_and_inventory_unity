﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerPosition;

    public float Sensitivity = 200f;
    public float visionAngle = 90f;
    [Range(0,90)]

    private float headCameraAngle = 0f;
    private int itemLayerMask = 1 << 8;

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
        RaycastHit hitObject;
        bool hitSomething;

        if(SensitivityCorrection > 0f){
            Sensitivity = Sensitivity + 25f;
        }
        else if(SensitivityCorrection < 0f){
            Sensitivity = Sensitivity - 25f;
        }

        if(Sensitivity <= 1f){
            Sensitivity = 25f;
        }

        headCameraAngle -= mouseY;
        headCameraAngle = Mathf.Clamp(headCameraAngle, -visionAngle, visionAngle);

        transform.localRotation = Quaternion.Euler(headCameraAngle, 0f, 0f);

        playerPosition.Rotate(Vector3.up * mouseX);

        hitSomething = Physics.Raycast(transform.position, transform.forward, out hitObject, 3f, itemLayerMask);

        if(hitSomething){
            hitObject.transform.GetComponent<ItemInteraction>().IsLookedAt();
            if(Input.GetAxis("Fire1") == 1){
                hitObject.transform.gameObject.SetActive(false);
                Debug.Log("Aight, I'm out");
            }
        }

    }

}
