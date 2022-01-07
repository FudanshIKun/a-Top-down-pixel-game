using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance;

    //GameState
    public static bool is_paused = false;

    [Header("SceneLoading")]
    public string spawnGate;
    public string currentScene;

    [Header("GameManager Setting")]
    public Player player;
    public CameraMovement mainCam;
    public LevelManager levelmanager;
    public InteractionManager interactionmanager;


    private void Awake()
    {
        //Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            setup_new_scene();
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    #region scene management
    public void setup_new_scene()
    {
        Instance.interactionmanager = interactionmanager;
        Instance.levelmanager = levelmanager;
        Instance.player.setup();
        reset_camera();
    }
    void reset_camera()
    {
        Instance.mainCam.minValues = mainCam.minValues;
        Instance.mainCam.maxValues = mainCam.maxValues;
    }
    
    public void LoadNextScene(string nextScene)
    {
        StartCoroutine(transtionLoading(nextScene)); // Load Scene
    }
    
    IEnumerator transtionLoading(string scene_to_load)
    {
        // Prepare before load scene
        

        yield return new WaitForSeconds(1);

        var asyncLoadLevel = SceneManager.LoadSceneAsync(scene_to_load, LoadSceneMode.Single);

        // Loading Scene
        while (!asyncLoadLevel.isDone)
        {
            yield return null;
        }

        // After Load scene
        checkPlayerGate(levelmanager.gate);
        
    }
    private void checkPlayerGate(SceneGate[] gate)
    {
        foreach (var item in  gate)
        {
            if (item.name == spawnGate)
            {
                player.transform.position = item.transform.position;
            }
        }
    }
    #endregion
}
