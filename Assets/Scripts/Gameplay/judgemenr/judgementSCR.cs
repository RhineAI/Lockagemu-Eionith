using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class judgementSCR : MonoBehaviour
{
    //OBJ
    //public GameObject Lane_Type; //masukkan collider untuk dideteksi ray apakah Lane 1,2,3,4?
    //public GameObject touch_control;
    public GameObject LaneLightTrigger;
    public spam Spam;
    public HashSet<GameObject> hasTap = new HashSet<GameObject>();
    //BOOL
    public bool Tap;
    public bool hold;
    

    //float
    public float timer = 0;
    public float touch_detect;

    //LIST
    
    // Start is called before the first frame update
    void Start()
    {
        
        //touch_control = GameObject.Find("touch_control");
    }

    // Update is called once per frame
    void Update()
    {
        if(Tap)
        {
            Debug.Log("tap");
            timer++;
        }

        if(timer > 3)
            {
            Tap = false;
            timer = 0;
        }

        if(touch_detect < 0)
        {
            touch_detect = 0;
        }

        if(hold)
        {
            LaneLightTrigger.GetComponent<Renderer>().material.color = Color.cyan;
        }
        else if (!hold)
        {
            LaneLightTrigger.GetComponent<Renderer>().material.color = Color.gray;
        }
        /*Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(touch_control.GetComponent<spam1>().i).position);
        RaycastHit hit;
        RaycastHit[] hits = Physics.RaycastAll(ray); 
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject == Lane_Type)
            {
                if (timer == 0)
                {
                    Tap = true;
                }
                else if (timer == 1) { Tap = false; }
                hold = true;
                foreach (RaycastHit hitz in hits)
                {
                    touch_detect++;
                }
            }
        }*/

    }

    

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("touch system"))
        {
            //spam Spam = GetComponent<spam>();
            touch_detect += 1;
            hold = true;
            if (timer < 2 && !Spam.hasTap.Contains(collision.gameObject))
            {
                Tap = true;
            }
            Spam.hasTap.Add(collision.gameObject);



        }
        else if (collision.collider.CompareTag("falser"))
        {
            
            
            if(touch_detect == 1)
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
