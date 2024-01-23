using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRight : MonoBehaviour
{
    public bool canBePressed = false;
    public GameObject perfectEffect, goodEffect, missEffect;
    // private bool earlyPerfect = false;
    // private bool latePerfect = false;
    // private bool great = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)) {
            if(canBePressed) {
                gameObject.SetActive(false);
                float transformYAxis = Mathf.Abs(transform.position.y);
                if (transformYAxis < 0.2f) {
                    GameManager.instance.NotePerfect();
                    // Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                } else if (transformYAxis > 0.2 && transformYAxis < 0.3) {
                    GameManager.instance.NoteEarlyPerfect();
                    // Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }  else if (transformYAxis > -0.3 && transformYAxis < -0.2) {
                    GameManager.instance.NoteLatePerfect();
                    // Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                } else {
                    GameManager.instance.NoteGood();
                    // Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                } 
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator") {
            canBePressed = true;
        }
        // if(other.tag == "Early Perfect") {
        //     earlyPerfect = true;
        //     canBePressed = true;
        // }
        // if(other.tag == "Late Perfect") {
        //     latePerfect = true;
        //     canBePressed = true;
        // }
        // if(other.tag == "Great") {
        //     great = true;
        //     canBePressed = true;
        // }

        // if(other.tag == "Miss") {
        //     GameManager.instance.combo = 0;
        //     canBePressed = false;
        // }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
    //    if(other.tag == "Late Perfect") {
    //         earlyPerfect = false;
    //         latePerfect = false;
    //         canBePressed = false;     
    //     }

        if(other.CompareTag("Activator") && gameObject.activeSelf) {
            canBePressed = false;
            GameManager.instance.NoteMissed();
            // Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
        
           
        // if(!gameObject.activeSelf) {
        //     GameManager.instance.combo = 0;
        //     GameManager.instance.NoteMissed();
        //     // Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        // }
  
        // if(gameObject.activeSelf) {
        //     GameManager.instance.NoteMissed();
        // }
    }
}
