using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryScreen : SceneObject
{
    GameObject myCanvas;

    public SummaryScreen()
    {
        myCanvas = Toolbox.GetInstance().GetDisplayManager().myCanvas;
        Text mytext = myCanvas.GetComponentInChildren<Text>();
        mytext.text = Toolbox.GetInstance().GetManager().TotalTime();
    }

    public override void UpdateScene()
    {
        if (Input.anyKeyDown)
        {
            Toolbox.GetInstance().GetManager().NextScene();
        }
    }
}

