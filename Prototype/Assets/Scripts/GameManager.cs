using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("SceneStarter")]
    public int spawnGate;
    public string currentScene;
    public Vector2 playerDirection;



    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            assign_new_value();
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void assign_new_value()
    {
        
    }
    public void LoadNextScene(string nextScene)
    {
        StartCoroutine(transtionLoading(nextScene));
    }
    #region scene management
    IEnumerator transtionLoading(string scene_to_load)
    {

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(scene_to_load);
    }
    #endregion
}
