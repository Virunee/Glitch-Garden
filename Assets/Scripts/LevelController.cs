using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] int winLabelDelaySecs = 3;
    [SerializeField] AudioClip winSFX;
    float gameOverScreenLoadDelaySecs = 1f;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        AudioSource.PlayClipAtPoint(winSFX, Camera.main.transform.position, 50f);
        yield return new WaitForSeconds(winLabelDelaySecs);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    public void HandleLoseScreen()
    {
        StartCoroutine(LoadGameOverScreenAfterDelay());
    }

    IEnumerator LoadGameOverScreenAfterDelay()
    {
        yield return new WaitForSeconds(gameOverScreenLoadDelaySecs);
        loseLabel.SetActive(true);
        Time.timeScale = 0;

    }
}
