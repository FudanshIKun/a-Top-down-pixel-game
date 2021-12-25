using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 2.0f;
    

    void Update()
    {
        if(target == null) return;
        Vector3 targetPos;

        targetPos = new Vector3(target.position.x, target.position.y, -100);
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);

        
    }
}
