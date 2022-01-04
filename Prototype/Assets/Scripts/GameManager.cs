using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("SceneStarter")]
    public string spawnGate;
    public string currentScene;
    public static Player player;
    public CameraMovement mainCam;
    public LevelManager levelmanager;


    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            reset_level();
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void reset_level()
    {
        Instance.levelmanager = levelmanager;
        player.levelManager = levelmanager;
        Instance.mainCam.minValues = mainCam.minValues;
        Instance.mainCam.maxValues = mainCam.maxValues;
    }
    public void LoadNextScene(string nextScene)
    {
        StartCoroutine(transtionLoading(nextScene)); // Load Scene
    }
    #region scene management
    IEnumerator transtionLoading(string scene_to_load)
    {
        // Prepare before load scene
        player.playerInStopMode = true;

        yield return new WaitForSeconds(1);

        var asyncLoadLevel = SceneManager.LoadSceneAsync(scene_to_load, LoadSceneMode.Single);

        while (!asyncLoadLevel.isDone)
        {
            Debug.Log("Scene loading");
            yield return null;
        }

        checkPlayerGate(levelmanager.gate);
        player.playerInStopMode = false;
    }
    private void checkPlayerGate(Gate[] gate)
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
