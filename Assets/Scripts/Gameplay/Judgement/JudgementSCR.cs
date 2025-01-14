using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class JudgementSCR : MonoBehaviour
{
    //OBJ
    //public GameObject Lane_Type; //masukkan collider untuk dideteksi ray apakah Lane 1,2,3,4?
    //public GameObject touch_control;
    public GameObject mytouch;
    public GameObject LaneLightTrigger;
    public spam Spam;
    public HashSet<GameObject> hasTap = new HashSet<GameObject>();
    //BOOL
    public bool Tap;
    public bool hold;
    public bool flick;
    public bool sideflick;

    //float
    //public float timer = 0;
    //public float timerF = 0;
    //public float timerSF = 0;
    public float touch_detect;

    //INT
    public int PointCollision;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Tap)
        { Tap = false; Debug.Log("tap"); }
        

        if (flick)
        { flick = false; Debug.Log("flicked"); }
        

        if (sideflick)
        { sideflick = false; Debug.Log("sideflicked"); }
        

        if (touch_detect < 0)
        {
            touch_detect = 0;
        }

        if(touch_detect == 0)
        {
            hold = false;
        }
        
        if(hold)
        {
            LaneLightTrigger.GetComponent<Renderer>().material.color = Color.cyan;
        }
        else if (!hold)
        {
            LaneLightTrigger.GetComponent<Renderer>().material.color = Color.gray;
        }
        
    }

    public void flicker()
    {
        flick = true;
    }

    public void sideflicker()
    {
        sideflick = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("touch system"))
        {
            Tap = true;
            hold = true;
            touch_detect += 1;
        }
        if (collision.collider.CompareTag("falser"))
        {
            if (touch_detect == 1)
            {
                hold = false;
                touch_detect = 0;
            }
            else
            {
                touch_detect -= 1;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        /*if (!collision.collider.CompareTag("touch system"))
        {
            hold = false;
            touch_detect = 0;
        }*/
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("touch system"))
        {
            if (touch_detect == 1)
            {
                hold = false;
                touch_detect = 0;
            }
            else
            {
                touch_detect -= 1;
            }
        }
    }
}
