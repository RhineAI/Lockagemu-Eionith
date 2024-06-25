using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class livefx : MonoBehaviour
{
    public bool parent;
    public bool child;
    public bool lastframe;
    [HideInInspector]
    public GameObject firstframe, nextframe, thisframe;

    
    public bool holdfx;
    //public static livefx instance;
    // Start is called before the first frame update
    void Start()
    {
        
        thisframe = gameObject;
        Debug.Log("Pure");
    }

    // Update is called once per frame
    void Update()
    {
        if (parent)
        {
            firstframe.SetActive(true);
        }

        if (child)
        {
            Invoke("change", 0.03f);
        }

        if (lastframe)
        {

        }

        if (holdfx)
        {
            gameObject.GetComponent<Animator>().SetBool("end_hold", true);
        }

        }

    void change()
    {
        nextframe.SetActive(true);
        thisframe.SetActive(false);
    }

    public void destroyvfx()
    {
        Destroy(gameObject);



    }

    public void holddestroy()
    {
        gameObject.GetComponent<Animator>().SetBool("end_hold", true);
    }
}