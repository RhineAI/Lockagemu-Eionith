using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public GameObject self;
    private Text textDisplay;
    public static ScoreDisplay instance;
    public int criticalJudgement = 0;
    public int criticalTap = 0;
    public int fairTap = 0;
    public int errorTap = 0;
    public int combo = 0;
    void Awake() 
    {
        instance = this;
    }
    void Start() 
    {
        textDisplay = self.GetComponent<Text>();
    }

    void update()
    {
        // criticalTap = 1; 
        // criticalJudgement = 1; 
        // fairTap = 1; 
        DisplayedScore();
    }

    public void DisplayedScore() {
        int oldScore = ScoreService.instance.ScoringSystem(criticalTap, fairTap);
        combo+=1;

        // Debug.Log($"Perfect: {perfectTap}, Notes: {criticalTap}, Great : {fairTap}, Miss : {missTap}");
        int currentScore = ScoreService.instance.ScoringSystem(criticalTap, fairTap);
        // Debug.Log($"Old Score: {oldScore}, Current Score: {currentScore}");
        
        StartCoroutine(CountScore(oldScore, currentScore, 0.5f));
    }

    IEnumerator CountScore(int startScore, int endScore, float countingDuration) {
        float timer = 0f;
        while (timer < countingDuration)
        {
            int currentDisplayedScore = (int)Mathf.Lerp(startScore, endScore, timer / countingDuration);
            textDisplay.text = $"{currentDisplayedScore}";

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
}