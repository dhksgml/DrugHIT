using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private static ShakeCamera instance;
    public static ShakeCamera Instance => instance;

    private float shakeTime;
    private float shakeIntensity;

    public ShakeCamera()
    {
        instance = this;
    }

    public void OnShakeCamera(float shakeTime = 1.0f, float shakeIntensity = 0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("ShakeByRotation");
        StartCoroutine("ShakeByRotation");

        StopCoroutine("ShakeByPosition");
        StartCoroutine("ShakeByPosition");
    }
    
    private IEnumerator ShakeByPosition()
    {
        Vector3 startPosition = transform.position;

        while(shakeTime > 0.0f)
        {
            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;

            shakeTime -= Time.deltaTime;

            yield return null;
        }

        transform.position = startPosition;
    }

    private IEnumerator ShakeByRotation()
    {
        Vector3 startRotation = transform.eulerAngles;
        float power = 3f;

        while(shakeTime > 0.0f)
        {
            float x = 0;
            float y = 0;
            float z = Random.RandomRange(-1f, 1f);
            transform.rotation = Quaternion.Euler(startRotation + new Vector3(x, y, z) * shakeIntensity * power);

            shakeTime -= Time.deltaTime;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(startRotation);
    }
}
