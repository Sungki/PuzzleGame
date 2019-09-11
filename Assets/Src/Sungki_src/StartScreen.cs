using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : SceneObject
{
    public override void UpdateScene()
    {
        if (Input.anyKeyDown)
        {
            Toolbox.GetInstance().GetManager<GameManager>().NextScene();
        }
    }
}
