using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyOperators : MonoBehaviour
{
    public int strength = 1;
    private TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayMessage() {
        strength++;
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = $"Strength : {strength}";
    }
}
