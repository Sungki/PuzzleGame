using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryScreen : SceneObject
{
    public SummaryScreen()
    {
        Toolbox.GetInstance().GetDisplayManager().ShowSummary();
    }

    public override void UpdateScene()
    {
        if (Input.anyKeyDown)
        {
            Toolbox.GetInstance().GetManager().NextScene();
            Toolbox.GetInstance().GetDisplayManager().InitText();
        }
    }
}

