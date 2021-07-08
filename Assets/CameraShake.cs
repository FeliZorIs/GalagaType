using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float power;
    public float duration;
    public bool shouldShake = false;

    Transform cameraMain;
    Vector3 startPosition;
    float initialDuration;

    void Start()
    {
        cameraMain = Camera.main.transform;
        startPosition = cameraMain.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldShake)
        {
            if (duration > 0)
            {
                cameraMain.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                cameraMain.localPosition = startPosition;
            }
        }
    }
}
