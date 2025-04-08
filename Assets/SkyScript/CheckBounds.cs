using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBounds : MonoBehaviour
{   public Transform target;
    public float minX, maxX;
    public float minY, maxY;

    private float camHalfHeight;
    private float camHalfWidth;

    void Start()
    {
        Camera cam = Camera.main;
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = camHalfHeight * cam.aspect;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z);

        newPos.x = Mathf.Clamp(newPos.x, minX + camHalfWidth, maxX - camHalfWidth);
        newPos.y = Mathf.Clamp(newPos.y, minY + camHalfHeight, maxY - camHalfHeight);

        transform.position = newPos;
    }
}
