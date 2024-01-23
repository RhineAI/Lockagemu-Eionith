using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    public int pureMemory = 10_000_000;
    public int score = 0;
    public static Score scoreInstance;
    private string grade;
    public int perfectTap = 0;
    void Awake() 
    {
        scoreInstance = this;
    }
    void Start() 
    {
    }

    void update()
    {
    }

    public string FormattedScore(int score) 
    {
        string scoreString = score.ToString();
        int lengthScore = score.ToString().Length;
        int addAdditionalZeros;
        if (lengthScore < 8) {
            addAdditionalZeros = 7 - lengthScore;
            scoreString = new string('0', addAdditionalZeros) + scoreString;
        } 
        else {
            addAdditionalZeros = 0;
        }   

        if (lengthScore > 3) {
            int numberOfQuotes = (lengthScore - 1) / 3;

            for (int i = 0; i < numberOfQuotes; i++) {
                int index = lengthScore - 3 * (i + 1);
                scoreString = scoreString.Insert(index, "'");
            }
        }
        return scoreString;
    }
    
    public int ScoringSystem(int notesTapped, int perfectJudgement, int goodTap)
    {
        int totalNotes = GameManager.instance.totalNotes;
        perfectTap = notesTapped - goodTap;
        if(perfectTap == totalNotes) {
            score = pureMemory + perfectJudgement;
        } else {
            int oneNoteScore = pureMemory / totalNotes;
            score = (oneNoteScore * perfectTap) + (oneNoteScore * goodTap / 2) + perfectJudgement;
        }
        return score;  
    }

    public string GradeSystem(int score)
    {
        if (score >= 9_900_000) return "EX+";
        if (score >= 9_800_000) return "EX";
        if (score >= 9_700_000) return "S";
        if (score >= 9_500_000) return "AA";
        if (score >= 9_200_000) return "A";
        if (score >= 9_000_000) return "B";
        if (score >= 8_700_000) return "C";
        
        return "D";
    }

}