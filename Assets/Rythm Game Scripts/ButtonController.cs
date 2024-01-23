using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();   
        // theSR.sprite = defaultImage;
    }

    // Update is called once per frame
    void Update()
    {
        // theSR = GetComponent<SpriteRenderer>();   

        if(Input.GetKeyDown(keyToPress)) {
            theSR.sprite = pressedImage;
        }

        if(Input.GetKeyUp(keyToPress)) {
            theSR.sprite = defaultImage;
        }
    }
}
