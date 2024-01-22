using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberGuesser : MonoBehaviour
{
    public int guess = 0;
    public int randomNumber;
    private TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = "Please Provide a Number 1 to 10";
        randomNumber = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decision() 
    {
        string message;
        if(guess >= 1 && guess <= 10) {
            if(randomNumber == guess) {
                message = "Correct!"; 
            } else if(randomNumber > guess) {
                message = "Too Low!";
            } else {
                message = "Too High!";
            }
        } else {
            string stringNumber = guess.ToString();
            message = "The number "+stringNumber+" it's not in a range 1 to 10";
        }

        textMeshPro.text = $"{message}";
    }
}
