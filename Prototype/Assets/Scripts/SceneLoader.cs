using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Transition setting")]
    public string nextscene;
    public float transitionTime = 1f;
    public Collider2D exit_gate;

    Animator transition;

    private void Start()
    {
        transition = GetComponent<Animator>();
    }

    void Update()
    {
        OnTriggerEnter2D(exit_gate);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            Debug.Log("Scene loading...");
            LoadNextScene();
        }
    }
    public void LoadNextScene()
    {
        StartCoroutine(transtionLoading(nextscene));
    }
    IEnumerator transtionLoading(string scene_to_load)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(scene_to_load);
    }
}
