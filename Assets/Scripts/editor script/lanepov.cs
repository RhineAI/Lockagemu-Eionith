using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class lanepov : MonoBehaviour
{
    public bool main_parent;
    public GameObject notespeed_setting;
    //public GameObject;
    public bool enable_speed_setting;
    
    //public bool disable_speed_setting;
    public GameObject timeline;
    // Start is called before the first frame update
    void Start()
    {
        //enable_speed_setting = true;
        enable_speed_setting = false;
        //disable_speed_setting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(main_parent)
        {
            if(enable_speed_setting)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, 0);
                timeline.GetComponent<timeline>().resetting_noteSpeed();
                timeline. GetComponent<timeline>().enabled = false;
                foreach (Transform child in transform)
                {
                    MonoBehaviour[] childscr = child.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour scr in childscr)
                    {
                        scr.GetComponent<lanepov>().enable_noteSpeed_setting();
                    }
                }
            }
            else
            {
                
                foreach (Transform child in transform)
                {
                    MonoBehaviour[] childscr = child.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour scr in childscr)
                    {
                        scr.GetComponent<lanepov>().disable_noteSpeed_setting();
                    }
                }
                
                timeline.GetComponent<timeline>().enabled = true;
            }
        }
        /*if(timeline.GetComponent<timeline>().manual == true)
        {
            enable_noteSpeed_setting();
            enable_speed_setting = true;
        }
        else
        {
            disable_noteSpeed_setting();
            enable_speed_setting=false;
        }*/
        /*if(enable_speed_setting)
        {
            enable_noteSpeed_setting();
        }
        else
        {
            disable_noteSpeed_setting();
        }*/
    }

    void enable_noteSpeed_setting()
    {
        notespeed_setting.SetActive(true);
        foreach(Transform child in transform)
        {
            MonoBehaviour[] scriptofchild = child.GetComponents<MonoBehaviour>();

            foreach (MonoBehaviour script in scriptofchild)
            {
                script.enabled = true;
            }
        }
    }

    void disable_noteSpeed_setting()
    {
        notespeed_setting.SetActive(false);
        foreach (Transform child in transform)
        {
            MonoBehaviour[] scriptofchild = child.GetComponents<MonoBehaviour>();

            foreach(MonoBehaviour script in scriptofchild)
            {
                script.enabled = false;
            }
        }
    }
}
