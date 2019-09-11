using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryScreen : SceneObject
{
    public SummaryScreen()
    {
        Toolbox.GetInstance().GetManager<DisplayManager>().ShowSummary();
    }

    public override void UpdateScene()
    {
        if (Input.anyKeyDown)
        {
            Toolbox.GetInstance().GetManager<GameManager>().NextScene();
            Toolbox.GetInstance().GetManager<DisplayManager>().InitText();
        }
    }
}

