using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;
    float startScreenLoadDelaySecs = 4f;
    float gameOverScreenLoadDelaySecs = 2f;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartScreenAfterDelay());
        }
    }

    IEnumerator LoadStartScreenAfterDelay()
    {
        yield return new WaitForSeconds(startScreenLoadDelaySecs);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("Game Over");
    }

    public IEnumerator LoadGameOverScreenAfterDelay()
    {
        yield return new WaitForSeconds(gameOverScreenLoadDelaySecs);
        LoadGameOverScene();
    }
}
