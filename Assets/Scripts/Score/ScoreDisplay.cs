using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
// using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public GameObject self;
    public static ScoreDisplay instance;

    public int criticalJudgement = 0;
    public int criticalTap = 0;
    public int fairTap = 0;
    public int errorTap = 0;

    public int score = 0;
    public int maxScore = 1_000_000;

    void Start() 
    {
        instance = this;
    }

    void update()
    {
        // criticalTap = 1; 
        // criticalJudgement = 1; 
        // fairTap = 1; 
        // DisplayedScore();
    }

    public void DisplayedScore(bool critical, bool fair, bool error) 
    {
        int oldScore = critical ? ScoringSystem(criticalTap - 1, fairTap) : ScoringSystem(criticalTap, fairTap);
        oldScore = fair ? ScoringSystem(criticalTap, fairTap - 1) : oldScore;
        ComboDisplay.instance.comboDisplay(error);
        // Debug.Log($"Perfect: {perfectTap}, Notes: {criticalTap}, Great : {fairTap}, Miss : {missTap}");
        int currentScore = ScoringSystem(criticalTap, fairTap);
        // Debug.Log($"Old Score: {oldScore}, Current Score: {currentScore}");
        StartCoroutine(CountScore(oldScore, currentScore, 0.5f));
    }

    public IEnumerator CountScore(int startScore, int endScore, float countingDuration) 
    {
        float timer = 0f;
        while (timer < countingDuration)
        {
            int currentDisplayedScore = (int)Mathf.Lerp(startScore, endScore, timer / countingDuration);
            self.GetComponent<TextMeshProUGUI>().text = $"{currentDisplayedScore}";

            timer += Time.deltaTime;
            yield return null; 
        }
    }

    public string FormattedScore(int score) 
    {
        string scoreString = score.ToString();
        int lengthScore = score.ToString().Length;
        int addAdditionalZeros = 0;
        if (lengthScore < 8) {
            addAdditionalZeros += 7 - lengthScore;
            scoreString = new string('0', addAdditionalZeros) + scoreString;
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

    public int ScoringSystem(int criticalTap, int fairTap)
    {
        int totalNotes = 3;
        if(criticalTap == totalNotes) {
            score = maxScore;
        } else {
            int oneNoteScore = maxScore / totalNotes;
            score = (oneNoteScore * criticalTap) + (oneNoteScore * fairTap / 2);
        }
        return score;  
    }

    public string GradeSystem(int score)
    {
        // IDK
        if (score >= 1_000_000) return "γ";
        if (score >= 980_000) return "S";
        if (score >= 960_000) return "A";
        if (score >= 930_000) return "B";
        if (score >= 900_000) return "C";
        if (score >= 860_000) return "D";

        return "Null";
    }
}