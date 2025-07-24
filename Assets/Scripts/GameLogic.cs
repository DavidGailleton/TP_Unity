using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameLogic: MonoBehaviour
{
    public int score = 0;
    public int scoreToWin = 3;
    public float timeToWin = 45f;
    public TMP_Text scoreText;
    public TMP_Text timeText;
    public LayerMask collectibleLayer;
    
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public GameObject gameGameObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = ("Score: " + score.ToString());
        StartCoroutine(GameCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ("Score: " + score.ToString());
        if (score >= scoreToWin)
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((collectibleLayer & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            score++;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
    }
    
    private IEnumerator GameCooldown()
    {
        bool result = false;
        float remainingTime = timeToWin;

        while (result == false && remainingTime >= 0)
        {
            if (score >= scoreToWin)
            {
                result = true;
                continue;
            }

            timeText.text = ("Time: " + remainingTime);
            remainingTime--;            

            yield return new WaitForSeconds(1f);
        }
        
        gameGameObject.SetActive(false);

        if (result)
        {
            winPanel.SetActive(true);
        }
        else
        {
            gameOverPanel.SetActive(true);
        }
        
    }
}
