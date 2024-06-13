using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livefx : MonoBehaviour
{
    public bool parent;
    public bool child;
    public GameObject firstframe, nextframe, thisframe;
    // Start is called before the first frame update
    void Start()
    {
        thisframe = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(parent)
        {
            firstframe.SetActive(true);
        }

        if (child)
        {
            Invoke("change", 0.03f);
        }

    }

    void change()
    {
        nextframe.SetActive(true);
        thisframe.SetActive(false);
    }

    

}
