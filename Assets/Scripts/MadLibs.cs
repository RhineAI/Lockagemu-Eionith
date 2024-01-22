using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MadLibs : MonoBehaviour
{
    public bool statement;
    public string verb;
    public string noun;
    public string adjective;
    public string pluralNoun;
    public int number;
    public float percent;
    private TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = $"The is statement is {statement}. i did not {verb} the {noun}. I am not Guilty. I am {adjective} person. The act was performed by {number} wandering {pluralNoun}. I am {percent}% sure of this.";

    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = $"The is statement is {statement}. i did not {verb} the {noun}. I am not Guilty. I am {adjective} person. The act was performed by {number} wandering {pluralNoun}. I am {percent}% sure of this.";
        
    }
}
