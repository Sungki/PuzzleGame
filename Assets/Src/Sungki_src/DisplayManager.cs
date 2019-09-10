using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    private GameObject myCanvas;
    private Text[] textArray;

    void Start()
    {
        myCanvas = GameObject.Find("Canvas");
        textArray = myCanvas.GetComponentsInChildren<Text>();
        DontDestroyOnLoad(myCanvas);
    }

    public void ShowHUD(float _playTime)
    {
        textArray[0].transform.position = new Vector2(110, Screen.height - 30);
        textArray[1].transform.position = new Vector2(Screen.width / 2, Screen.height - 30);
        textArray[2].transform.position = new Vector2(Screen.width - 130, Screen.height - 30);

        textArray[0].text = transform.parent.GetComponentInChildren<GameManager>().GetPlayerLives();
        textArray[1].text = null;
        textArray[2].text = "Time: " + string.Format("{0:N1}", _playTime);
    }

    public void ShowSummary()
    {
        textArray[0].transform.position = new Vector2(Screen.width / 2-20, Screen.height - 100);
        textArray[1].transform.position = new Vector2(Screen.width / 2, Screen.height - 250);
        textArray[2].transform.position = new Vector2(Screen.width / 2, Screen.height - 400);

        textArray[0].text = transform.parent.GetComponentInChildren<GameManager>().GetPlayerLives();
        textArray[0].text += "     " + transform.parent.GetComponentInChildren<GameManager>().GetDiedCount();
        textArray[1].text = transform.parent.GetComponentInChildren<GameManager>().TotalTime();
        textArray[2].text = transform.parent.GetComponentInChildren<GameManager>().GetScore();
        textArray[2].text += "     " + transform.parent.GetComponentInChildren<GameManager>().GetMoveCount();
    }

    public void InitText()
    {
        textArray[0].text = null;
        textArray[1].text = null;
        textArray[2].text = null;
    }
}