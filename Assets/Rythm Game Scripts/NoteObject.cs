using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    // private bool early = false;
    // private bool late = false;
    // private bool great = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)) {
            if(canBePressed) {
                gameObject.SetActive(false);
                GameManager.instance.NotePerfect();
            } else {
            }
        }
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     // canBePressed = true;
    //     // Debug.Log(other);
    //     if(other.tag == "Activator") {
    //         canBePressed = true;
    //     }
    // }
    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if(other.tag == "Activator") {
    //         canBePressed = false;
    //         GameManager.instance.NoteMissed();
    //     }
    // }
}
