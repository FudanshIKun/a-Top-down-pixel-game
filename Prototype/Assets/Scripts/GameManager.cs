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

    [Header("SceneStarter")]
    public string spawnGate;
    public string currentScene;
    public Player player;
    public CameraMovement mainCam;
    public LevelManager levelmanager;

    [Header("Interact System")]
    public bool interacting = false;
    public string objectType;
    public Transform forAnimate;


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
        interactSystem(objectType);
    }
    #region scene management
    public void setup_new_scene()
    {
        forAnimate = null;
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
        player.playerInStopMode = true;

        yield return new WaitForSeconds(1);

        var asyncLoadLevel = SceneManager.LoadSceneAsync(scene_to_load, LoadSceneMode.Single);

        while (!asyncLoadLevel.isDone)
        {
            yield return null;
        }

        if (interacting && objectType == "enterBuilding") { reset_interactSystem();  }
        checkPlayerGate(levelmanager.gate);
        player.playerInStopMode = false;
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

    #region interaction Management

    bool interactInput(KeyCode key)
    {
        return Input.GetKeyDown(key);
    }

    void reset_interactSystem()
    {
        objectType = null; interacting = false;
    }
    void interactSystem(string objectType)
    {
        if (interacting)
        {
            if (objectType == null) { return; }

            // sorting interaction effect
            if (objectType == "enterBuilding") { enterBuilding(); }
            Debug.Log("Interacted");
        }
    }
    public void enterBuilding()
    {
        if (interactInput(KeyCode.E))
        {
            interacting = true;
            objectType = "enterBuilding";
        }
    }
    public void enterNewMap(Transform exitPoint)
    {
        forAnimate = exitPoint;
        interacting = true;
        objectType = "enterMap";
    }


    #endregion
}
