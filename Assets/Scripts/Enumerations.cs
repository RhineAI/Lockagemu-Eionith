using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum MovementAxis
{
    Down = 2,
    Up,
}

public enum ResultScore
{
    Perfect = 2,
    Great = 1,
    Miss = 0,
}

public enum EarlyLate
{
    Early = -1,
    Late = -1,
}

public class Enumerations : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    public MovementAxis playerMovement;
    public ResultScore scoreType;
    public int totalNotes = 1094;
    public int totalClickedNotes;
    public int score;
    private int pureMemory = 10_000_000;
    
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    private int perfectCount;
    private int greatCount;
    private int missCount;

    string FormattedScore(int score) 
    {
        string scoreString = score.ToString();
        int addAdditionalZeros = 8 - score.ToString().Length;
        scoreString = new string('0', addAdditionalZeros) + scoreString;
        int lengthScore = score.ToString().Length;
        if (lengthScore > 3) {
            int numberOfQuotes = (lengthScore - 1) / 3;

            for (int i = 0; i < numberOfQuotes; i++) {
                int index = lengthScore - 3 * (i + 1);
                scoreString = scoreString.Insert(index, "'");
            }
        }
        return scoreString;
    }

    public void showMessage() 
    {
        totalClickedNotes++;
        if (score != pureMemory && totalClickedNotes <= totalNotes) {
            if (scoreType == ResultScore.Perfect) {
                perfectCount++;
            } else if (scoreType == ResultScore.Great) {
                greatCount++;
            } else {
                missCount++;
            }
            int perfectScore = pureMemory / totalNotes;
            score = (perfectScore * perfectCount) + (perfectScore * greatCount / 2);
            textMeshPro.text = $"You Get {FormattedScore(score)} \n Perfect = {perfectCount} \n Great = {greatCount} \n Miss = {missCount}";
        } else {
            textMeshPro.text = $"Max PM {FormattedScore(score)} \n Perfect = {perfectCount} \n Great = {greatCount} \n Miss = {missCount}";
        }
    }
}
