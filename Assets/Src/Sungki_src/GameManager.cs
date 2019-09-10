﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const int TOTAL_LEVEL = 4;

    private SceneState currentState= 0;
    private SceneObject scene = null;
    private float[] levelTime;
    private int moveCount = 0;
    private int score = 0;
    private int lives = 10;
    private int diedCount = 0;

    private void Start()
    {
        levelTime = new float[TOTAL_LEVEL];
    }

    public void Init()
    {
        lives = 10;
        diedCount = 0;
        score = 0;
        moveCount = 0;
        currentState = SceneState.StartScreen;
        scene = SceneFactory.Create(currentState);
    }

    public void NextScene()
    {
        if (currentState == SceneState.SummaryScreen) Init();
        else
        {
            currentState++;
            scene = SceneFactory.Create(currentState);
        }
        SceneManager.LoadScene(currentState.ToString());
    }

    public void Respawn()
    {
        SceneManager.LoadScene(currentState.ToString());
    }

    public void AddSceneTime()
    {
        if (currentState == SceneState.SummaryScreen) return;

        levelTime[(int)currentState-1] = scene.getSceneTime();
    }

    public void AddDiedCount()
    {
        diedCount++;
        lives--;

        if(lives == 0)
        {
            currentState = SceneState.SummaryScreen;
            scene = SceneFactory.Create(currentState);
            SceneManager.LoadScene(currentState.ToString());
        }
    }

    public string GetPlayerLives() { return "Lives: " + lives; }
    public string GetDiedCount() { return "Died: " + diedCount; }
    public string GetMoveCount() { return "MoveCount: " + moveCount.ToString(); }
    public string GetScore() { return "Score: " + score.ToString(); }

    public void AddMoveCount()
    {
        moveCount++;
    }

    public void AddScore(int _score)
    {
        score += _score;
    }

    public string TotalTime()
    {
        float totalTime = 0;
        string str = null;
        for (int i = 0; i < levelTime.Length; i++)
        {
            totalTime += levelTime[i];
            str += "Lv" + (i+1).ToString() + ": " + string.Format("{0:N1}", levelTime[i]) + ", ";
        }
        str += "Total: " + string.Format("{0:N1}", totalTime);
        return str;
    }

    void Update()
    {
        scene.UpdateScene();
    }
}
