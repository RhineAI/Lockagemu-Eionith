using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreService : MonoBehaviour
{
    private int allCritical = 1_000_000;
    public int score = 0;
    public static Score scoreInstance;
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

    
    public int ScoringSystem(int criticalTap, int criticalJudgement, int fairTap)
    {
        int totalNotes = GameManager.instance.totalNotes;
        if(criticalTap == totalNotes) {
            score = allCritical + criticalJudgement;
        } else {
            int oneNoteScore = allCritical / totalNotes;
            score = (oneNoteScore * criticalTap) + (oneNoteScore * fairTap / 2) + criticalJudgement;
        }
        return score;  
    }

    public string GradeSystem(int score)
    {
        if (score >= 1_000_000) return "γ";
        if (score >= 980_000) return "S";
        if (score >= 960_000) return "A";
        if (score >= 930_000) return "B";
        if (score >= 900_000) return "C";
        if (score >= 860_000) return "D";

        return "Null";
    }

}