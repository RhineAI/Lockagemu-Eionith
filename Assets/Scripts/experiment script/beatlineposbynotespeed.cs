using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beatlineposbynotespeed : MonoBehaviour
{
    public float zpos;
    public float note_speed;
    public GameObject self;
    public Vector3 posobj;
    public float wakilposz;
    public bool tambah;
    public bool tambahan;
    public GameObject beatline;
    //public Transform selftrans;
    // Start is called before the first frame update
    void Start()
    {
        beatline = GameObject.Find("set note speed");
        note_speed = 1;
        self = gameObject;
        //selftrans = gameObject.transform;
        posobj = new Vector3 (self.transform.position.x, 0, self.transform.position.z);
        beatline.GetComponent<expsimplecoroutine>().Note_speed = 1;
        tambah = true;
    }

    // Update is called once per frame
    void Update()
    {
        //wakilposz = 1 - 9.9f;
        if (beatline.GetComponent<expsimplecoroutine>().Note_speed < 1)
        {
            note_speed = 1;
        }else
        {
            note_speed = beatline.GetComponent<expsimplecoroutine>().Note_speed;
        }
        
        if (tambah)
        {
            self.transform.position = new Vector3(self.transform.position.x, self.transform.position.y, posobj.z * note_speed);
            //tambah = false;
        }
        if(tambahan)
        {
            tambahan = false;
            
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            //beatline.GetComponent<expsimplecoroutine>().ex2 += wakilposz;
            //tambah = true;
            //tambahan = true;
        }
    }
}
