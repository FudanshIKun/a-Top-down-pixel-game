using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileLayerSorting : MonoBehaviour
{
    public bool player_is_on;
    public GameObject graphicLayer;
    public GameObject colliderLayer;
    TilemapRenderer tilemapRenderer;
    // Start is called before the first frame update
    void Start()
    {
        tilemapRenderer = GetComponent<TilemapRenderer>();
        Debug.Log(tilemapRenderer.sortingOrder);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
