using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraOffset;
    public float playerHeight = 2f;
    public float cameraZoomSpeed = 4f;
    public float minCameraZoom = 2f;
    public float maxCameraZoom = 15f;
    public float yawSpeed = 100f;

    private float currentCameraZoom = 10f;
    private float currentYaw = 0f;

    void Update()
    {
        currentCameraZoom -= Input.GetAxis("Mouse ScrollWheel") * cameraZoomSpeed;
        currentCameraZoom = Mathf.Clamp(currentCameraZoom, minCameraZoom, maxCameraZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        transform.position = target.position - cameraOffset * currentCameraZoom;
        transform.LookAt(target.position + Vector3.up * playerHeight);
        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
