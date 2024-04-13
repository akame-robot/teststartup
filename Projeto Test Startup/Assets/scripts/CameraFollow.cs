using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraSpeed;

    public Transform playerPosition;

    // Update is called once per frame
    void Update()
    {
        Camera();
    }
    void Camera()
    {
        Vector3 follow = new Vector3(playerPosition.position.x, playerPosition.position.y, -7f);
        transform.position = Vector3.Slerp(transform.position, follow, cameraSpeed * Time.deltaTime);
    }
}
