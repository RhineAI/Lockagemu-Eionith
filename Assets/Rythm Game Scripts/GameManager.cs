using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System;

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
    public int greatTap = 0;

    void Awake() 
    {
        instance = this;    
        if(noteHolder != null) {
            Transform noteHolderTransform = noteHolder.transform;
            totalNotes += noteHolderTransform.childCount;
        }
        perfectTap = totalNotes;
        perfectJudgement = totalNotes;
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
    }

    float elapsedTime = 0f;
    public void ScoreDisplay() {
        // int oldScore = Score.scoreInstance.ScoringSystem(notesTapped, perfectJudgement, greatTap, missTap);
        // elapsedTime += Time.deltaTime;

        notesTapped++;
        combo+=1;
        
        int currentScore = Score.scoreInstance.ScoringSystem(notesTapped, perfectJudgement, greatTap, missTap);

        string scoreDisplay = Score.scoreInstance.FormattedScore(currentScore);
        if(totalNotes == notesTapped) {
            string gradeDisplay = Score.scoreInstance.GradeSystem(Score.scoreInstance.score);
            scoreText.text = $"{scoreDisplay} {gradeDisplay} \nPerfect : {perfectTap} \nGreat : {greatTap} \nMiss : {missTap}";
            lateEarlyText.gameObject.SetActive(true);
            lateEarlyText.text = $"e{earlyTap} l{lateTap}";
        } else {
            // scoreText.text = $"{(float)Mathf.Lerp(oldScore, currentScore, elapsedTime / 2f)}";
            scoreText.text = scoreDisplay;
        }
        comboText.text = $"Combo : {combo}";

    }

    public void NotePerfect() 
    {
                    // Debug.Log("Perfect");
        ScoreDisplay();
    }
    public void NoteEarlyPerfect() 
    {
                    // Debug.Log("Early");
        earlyTap += 1;
        perfectJudgement -= 1;
        ScoreDisplay();
    }

    public void NoteLatePerfect() 
    {
                    // Debug.Log("Late");
        lateTap += 1;
        perfectJudgement -= 1;
        ScoreDisplay();
    }

    public void NoteGood() 
    {
                    // Debug.Log("Good");
        greatTap += 1;
        perfectTap -= 1;
        perfectJudgement -= 1;
        ScoreDisplay();
    }

    public void NoteMissed() {
        missTap += 1;
        perfectTap -= 1;
        comboText.text = $"Combo : {combo = 0}";
    }
}
