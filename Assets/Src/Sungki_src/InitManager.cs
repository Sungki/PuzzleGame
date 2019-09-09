using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManager : MonoBehaviour
{
    void Start()
    {
        Toolbox.GetInstance().GetManager().Init();
    }
}
