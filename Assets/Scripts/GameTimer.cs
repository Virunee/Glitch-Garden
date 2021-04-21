using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level time in seconds")]
    [SerializeField] float levelTime = 20;
    bool triggeredLevelFinished = false;
    float difficultyModifier;

    private void Start()
    {
        difficultyModifier = PlayerPrefsController.GetDifficulty();
        levelTime += (difficultyModifier * 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(triggeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);

        if(timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
