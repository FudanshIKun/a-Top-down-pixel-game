using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    public Level[] levels;
    public Gate[] gate;

    [Header("Transition setting")]
    public float transitionTime = 1f;
    public Collider2D exit_gate;

    Animator transition;
    void Start()
    {
        transition = GetComponent<Animator>();
    }
        
    void Update()
    {

    }
    
    public void checkGate(string nextScene, int gate, Vector2 player)
    {
        GameManager.Instance.currentScene = nextScene;
        GameManager.Instance.spawnGate = gate;
        GameManager.Instance.playerDirection = player;

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