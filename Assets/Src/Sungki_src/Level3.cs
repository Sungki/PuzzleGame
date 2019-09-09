using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : SceneObject
{
    float playTime = 0;

    public override void UpdateScene()
    {
        playTime += Time.deltaTime;
    }

    public override float getSceneTime()
    {
        return playTime;
    }
}