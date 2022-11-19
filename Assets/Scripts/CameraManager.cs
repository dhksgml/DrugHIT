using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Transform[] playerTransforms = new Transform[2];

    public float yOffset = 1.5f;
    public float zOffset = 0.55f;

    //¿Ã ∫Øºˆ∑Œ ¡‹¿Œ, ¡‹ æ∆øÙ ∞°¥…
    public float minDistance = 5.0f;

    private float xMin, xMax, yMin, yMax;

    private void Start()
    {
        playerTransforms[0] = GameObject.FindWithTag("p1").GetComponent<Transform>();
        playerTransforms[1] = GameObject.FindWithTag("p2").GetComponent<Transform>();
    }
    private void LateUpdate()
    {
        xMin = xMax = playerTransforms[0].position.x;
        yMin = yMax = playerTransforms[0].position.y;

        for(int i = 1; i < playerTransforms.Length; i++)
        {
            if (playerTransforms[i].position.x < xMin)
                xMin = playerTransforms[i].position.x;
            if (playerTransforms[i].position.x > xMax)
                xMax = playerTransforms[i].position.x;
            if (playerTransforms[i].position.x < yMin)
                yMin = playerTransforms[i].position.y;
            if (playerTransforms[i].position.x > yMax)
                yMax = playerTransforms[i].position.y;
        }

        float xMiddle = (xMin + xMax) / 2;
        float yMiddle = (yMin + yMax) / 2;
        float distance = xMax - xMin;
        if (distance < minDistance)
            distance = minDistance;

        transform.position = new Vector3(xMiddle, yMiddle + yOffset, -distance * zOffset);
    }
}