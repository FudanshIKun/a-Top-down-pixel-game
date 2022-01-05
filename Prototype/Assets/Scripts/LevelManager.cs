using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    public Level[] levels;
    public SceneGate[] gate;

    [Header("Transition setting")]
    public float transitionTime = 1f;

    Animator transition;

    private void Awake()
    {
        
    }
    void Start()
    {
        transition = GetComponent<Animator>();
    }
        
    void Update()
    {

    }
    public void checkGate(string nextScene, string gate)
    {
        GameManager.Instance.currentScene = nextScene;
        GameManager.Instance.spawnGate = gate;

        GameManager.Instance.LoadNextScene(GameManager.Instance.currentScene);
    }
    public void checkLevel(Collider2D hit, SpriteRenderer sprite)  
    {       
        for (int i = 0; i < levels.Length; i++)
        {
            if (hit.name == levels[i].name)
            {
                levels[i].toggle_collider(true);
                toggle_layer(9 + (10 * i), sprite);
            }
            else
            {
                levels[i].toggle_collider(false);
            }
        }
    }
    public void toggle_layer(int level, SpriteRenderer sprite)
    {
        sprite.sortingOrder = level;
    }

}