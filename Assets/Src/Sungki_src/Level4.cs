using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : SceneObject
{
    private float playTime = 0;

    public override void UpdateScene()
    {
        playTime += Time.deltaTime;

        Toolbox.GetInstance().GetDisplayManager().ShowHUD(playTime);
    }

    public override float getSceneTime()
    {
        return playTime;
    }
}
