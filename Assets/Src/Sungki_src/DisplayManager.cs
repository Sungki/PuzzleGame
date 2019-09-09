using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    public GameObject myCanvas;
    void Start()
    {
        myCanvas = GameObject.Find("Canvas");
        DontDestroyOnLoad(myCanvas);
    }

    void Update()
    {
        
    }
}
