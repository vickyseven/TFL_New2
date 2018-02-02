using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowFox : MonoBehaviour {

    public Transform target2; //what camera follows
    public float smoothing; //dampening effect

    Vector3 offset;

    float lowY; //lowest point the camera can go

    // Use this for initialization
    void Start()
    {
        offset = transform.position - target2.position;

        lowY = transform.position.y;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target2.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        if (transform.position.y < lowY) transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
    }
}

