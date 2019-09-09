using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const int totalLevel = 4;
    private SceneState currentState= 0;
    private SceneObject scene = null;
    private float[] levelTime;
    private int killedCount = 0;
    private int score = 0;

    public void Init()
    {
        levelTime = new float[totalLevel];
        currentState = SceneState.StartScreen;
        scene = SceneFactory.Create(currentState);
    }

    public void NextScene()
    {
        if (currentState == SceneState.SummaryScreen)
        {
            Init();
            SceneManager.LoadScene(currentState.ToString());
        }
        else
        {
            currentState++;
            SceneManager.LoadScene(currentState.ToString());
            scene = SceneFactory.Create(currentState);
        }
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

    public void AddKilled()
    {
        killedCount++;
    }

    public void AddScore(int _score)
    {
        score += _score;
    }

    public string TotalTime()
    {
        float total = 0;
        string time;
        time = "Time: ";
        for (int i = 0; i < levelTime.Length; i++)
        {
            total += levelTime[i];
            time += levelTime[i].ToString() + " , ";
        }

        time += "Total: " + total.ToString();
        time += "Died: " + killedCount.ToString();
        time += "Score: " + score.ToString();
        return time;
    }

    void Update()
    {
        scene.UpdateScene();
    }
}
