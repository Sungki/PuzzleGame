using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : SceneObject
{
    float playTime = 0;

    public Level1()
    {
        GameObject myCanvas = Toolbox.GetInstance().GetDisplayManager().myCanvas;
        Text[] mytext = myCanvas.GetComponentsInChildren<Text>();
        mytext[0].text = "";
        mytext[1].text = "";
        mytext[2].text = "";
    }

    public override void UpdateScene()
    {
        playTime += Time.deltaTime;
    }

    public override float getSceneTime()
    {
        return playTime;
    }
}
