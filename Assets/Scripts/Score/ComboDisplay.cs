using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboDisplay : MonoBehaviour 
{
    public GameObject self;
    public static ComboDisplay instance;
    public int combo = 0;

    void Awake() {
        instance = this;
    }

    public void comboDisplay(bool error) {
        if(error) {
            combo = 0;
        } else {
            combo+=1;
        }
        Debug.Log("test");
        // self.GetComponent<TextMeshProUGUI>().text = $"{combo}";
    }
}