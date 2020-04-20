using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    public static float score = 0;

    [SerializeField]
    float timeScoreDelay = 0.1f, timeScoreValue = 10f; 
    
    
    float timePassed = 0f;

    static public string highscoreString;

    private TextMeshProUGUI scoreBoard;

    float timeScale;

    GameObject deathScreenUI;
    TextMeshProUGUI highestScore;


    void Start()
    {
        deathScreenUI = GameObject.FindGameObjectWithTag("DeathScreen");
        highestScore = GameObject.FindGameObjectWithTag("Highestscore").GetComponent<TextMeshProUGUI>();

        scoreBoard = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
        deathScreenUI.SetActive(false);

        ChildBehaviour.health = 100f;
        score = 0f;
        ChildBehaviour.dead = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (timePassed <= 0 && ChildBehaviour.dead == false) {

            score += timeScoreValue;

            timePassed = timeScoreDelay;
        }
        timePassed = timePassed - Time.deltaTime;
        scoreBoard.text = score.ToString();
        

    }


    public void end() {
        

        
        if(PlayerPrefs.GetFloat("highscore") == null || PlayerPrefs.GetFloat("highscore") < score) {
            PlayerPrefs.SetFloat("highscore", score);
        }

        deathScreenUI.SetActive(true);
        highestScore.text = PlayerPrefs.GetFloat("highscore").ToString();
    }

    static public string GetHighscore() {
        return (highscoreString= PlayerPrefs.GetFloat("highscore").ToString());
    }

    static public string GetScore() {
        return score.ToString();
    }


}
