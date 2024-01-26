using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshPro comboText;
    public TextMeshPro scoreText;
    public TextMeshPro lateEarlyText;
    public static ScoreDisplay instance;
    public int notesTapped = 0;
    public int combo = 0;
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

    public void DisplayedScore(int criticalJudgement, int fairTap) {
        int oldScore = ScoreService.instance.ScoringSystem(notesTapped, criticalJudgement, fairTap);
        notesTapped+= 1;
        combo+=1;

        // Debug.Log($"Perfect: {perfectTap}, Notes: {notesTapped}, Great : {fairTap}, Miss : {missTap}");
        int currentScore = ScoreService.instance.ScoringSystem(notesTapped, criticalJudgement, fairTap);
        Debug.Log($"Old Score: {oldScore}, Current Score: {currentScore}");
        
        StartCoroutine(CountScore(oldScore, currentScore, 0.5f));
        comboText.text = $"Combo : {combo}";
    }

    IEnumerator CountScore(int startScore, int endScore, float countingDuration) {
        float timer = 0f;
        while (timer < countingDuration)
        {
            int currentDisplayedScore = (int)Mathf.Lerp(startScore, endScore, timer / countingDuration);
            scoreText.text = $"{currentDisplayedScore}";

            timer += Time.deltaTime;
            yield return null; 
        }
    }
}