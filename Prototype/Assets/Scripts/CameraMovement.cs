using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 2.0f;
    public Vector3 minValues, maxValues;

    void Update()
    {
        if(target == null) return;
        Vector3 targetPos;

        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(target.position.x, minValues.x, maxValues.x),
            Mathf.Clamp(target.position.y, minValues.y, maxValues.y),
            Mathf.Clamp(target.position.z, minValues.z, maxValues.z));

        targetPos = new Vector3(target.position.x, target.position.y, -100);
        transform.position = Vector3.Lerp(transform.position, boundPosition, lerpSpeed * Time.deltaTime);

        
    }
}
