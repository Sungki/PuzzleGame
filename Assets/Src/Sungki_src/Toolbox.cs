using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    private static Toolbox _instance;

    public static Toolbox GetInstance()
    {
        if (Toolbox._instance == null)
        {
            var go = new GameObject("Toolbox");
            DontDestroyOnLoad(go);
            Toolbox._instance = go.AddComponent<Toolbox>();
        }
        return Toolbox._instance;
    }

    private GameManager game;
    private DisplayManager display;

    void Awake()
    {
        if (Toolbox._instance != null)
        {
            Destroy(this);
        }

        var go = new GameObject("GameManager");
        go.transform.parent = this.gameObject.transform;
        this.game = go.AddComponent<GameManager>();
        go = new GameObject("DisplayManager");
        go.transform.parent = this.gameObject.transform;
        this.display = go.AddComponent<DisplayManager>();
    }

    public GameManager GetManager()
    {
        return this.game;
    }

    public DisplayManager GetDisplayManager()
    {
        return this.display;
    }
}
