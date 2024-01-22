using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipCalculator : MonoBehaviour
{
    public int bill;
    public float tipPercentage;
    private TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {   
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TipCalculating() 
    {
        tipPercentage = (tipPercentage >= 100) ? 100 : tipPercentage;
        float tip = (float)bill * (tipPercentage / 100);
        int tipTotal = bill + (int)tip;
        textMeshPro.text = $"Your Bill Total is : {tipTotal}";
    }
}
