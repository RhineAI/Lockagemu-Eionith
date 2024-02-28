using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioSource theMusic;
    public BeatScroller theBS;
    public GameObject noteHolder;
    public TextMeshPro comboText;
    public TextMeshPro scoreText;
    public TextMeshPro lateEarlyText;
    public bool startPlaying;
    public int totalNotes = 0;
    public int notesTapped = 0;
    public int combo = 0;
    private int perfectTap = 0;
    private int perfectJudgement = 0;
    private int earlyTap = 0;
    private int lateTap = 0;
    private int missTap = 0;
    private int goodTap = 0;

    void Awake() 
    {
        instance = this;    
        if(noteHolder != null) {
            Transform noteHolderTransform = noteHolder.transform;
            totalNotes += noteHolderTransform.childCount;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!startPlaying) {
            if(Input.anyKeyDown) {
                startPlaying = true;
                theBS.hasStarted = true;
                theMusic.Play();
            }
        }
        if(totalNotes == perfectTap + goodTap + missTap) {
            string scoreDisplay = Score.scoreInstance.FormattedScore(Score.scoreInstance.score);
            string gradeDisplay = Score.scoreInstance.GradeSystem(Score.scoreInstance.score);
            scoreText.text = $"{scoreDisplay} {gradeDisplay} \nPerfect : {perfectTap} \nGreat : {goodTap} \nMiss : {missTap}";
            lateEarlyText.gameObject.SetActive(true);
            lateEarlyText.text = $"e{earlyTap} l{lateTap}";
        }
    }

    public void ScoreDisplay() {
        int oldScore = Score.scoreInstance.ScoringSystem(notesTapped, perfectJudgement, goodTap);
        notesTapped+= 1;
        combo+=1;

        // Debug.Log($"Perfect: {perfectTap}, Notes: {notesTapped}, Great : {goodTap}, Miss : {missTap}");
        int currentScore = Score.scoreInstance.ScoringSystem(notesTapped, perfectJudgement, goodTap);
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

    public void NotePerfect() 
    {
        // Debug.Log("Perfect");
        perfectTap += 1;            
        perfectJudgement += 1;     
        ScoreDisplay();
    }
    public void NoteEarlyPerfect() 
    {
        // Debug.Log("Early");
        earlyTap += 1;
        perfectTap += 1;            
        ScoreDisplay();
    }

    public void NoteLatePerfect() 
    {
        // Debug.Log("Late");
        lateTap += 1;
        perfectTap += 1;            
        ScoreDisplay();
    }

    public void NoteGood() 
    {
        // Debug.Log("Good");
        goodTap += 1;
        perfectJudgement -= 1;
        ScoreDisplay();
    }

    public void NoteMissed() {
        missTap += 1;
        comboText.text = $"Combo : {combo = 0}";
    }
}
