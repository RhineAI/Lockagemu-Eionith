using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreService : MonoBehaviour
{
    public int criticalTap = 0;
    public static ScoreService instance;
    void Awake() 
    {
        instance = this;
    }

    void Start() 
    {
    }

    void update()
    {
    }

    
    

}