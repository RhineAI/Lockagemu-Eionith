using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class judgementSCR : MonoBehaviour
{
    //OBJ
    //public GameObject Lane_Type; //masukkan collider untuk dideteksi ray apakah Lane 1,2,3,4?
    //public GameObject touch_control;
    
    //BOOL
    public bool Tap;
    public bool hold;

    //float
    public float timer = 0;
    public float touch_detect;
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
            Debug.Log("Tap");
            timer = 1;
        }
        

        if (timer == 1) { Tap = false; }

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
            touch_detect += 1;
            if (timer == 0)
            {
                Tap = true;
            }
            
            hold = true;
            
        }
        else if (collision.collider.CompareTag("falser"))
        {
            touch_detect-=1;
            timer = 0;
            if(touch_detect < 1)
            {
                hold = false;
            }
            

        }
    }

    
}
