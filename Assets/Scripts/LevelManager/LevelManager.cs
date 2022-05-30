using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public bool cinematicMode;

    public static LevelManager GetInstance ()
    {
        return main;
    }

    public void Awake()
    {
        main = this;
    }
}
