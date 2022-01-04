using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float lerpSpeed = 2.0f;
    public Vector3 minValues, maxValues;
    public Vector3 boundPosition;

    private void Start()
    {
        player = GameManager.player.transform;
    }
    void Update()
    {
        if(player == null) return;

        minValues.z = -100; maxValues.z = -100;
        boundPosition = new Vector3(
            Mathf.Clamp(player.position.x, minValues.x, maxValues.x),
            Mathf.Clamp(player.position.y, minValues.y, maxValues.y),
            Mathf.Clamp(player.position.z, minValues.z, maxValues.z));

        transform.position = Vector3.Lerp(transform.position, boundPosition, lerpSpeed * Time.deltaTime);

        
    }
}
