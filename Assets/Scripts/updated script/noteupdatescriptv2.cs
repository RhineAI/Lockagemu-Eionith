using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteupdatescriptv2 : MonoBehaviour
{
    //optimalization
    public
        bool on_area, rotate_to_target, slowrotate;

    public
        GameObject anchorpoint_script, bpmcontroller, lane;

    public float maxvalue = 420;

    public
        float currentfloat, percentage, timelapsed, acumulation, currentlanez, accel, targetspeed, rotaz;

    float factorial = 0.5f;
    float rotaspeed;

    public static noteupdatescriptv2 notescr;

    public
        int kind;

    /*LIST OF VALUE
    public bool on_area;

    public GameObject anchorpoint;
    public GameObject bpmcontroller;

    public bool rotate_to_target;
    //public bool rotate_back;

    public float maxvalue = 420;
    public float currentfloat;
    public float percentage;

    public float timelapsed;
    public float acumulation;
    public float factorial = 0.5f;
    float rotaspeed;

    public float currentlanez;
    public float accel;
    public float targetspeed;
    public float rotaz;*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(on_area)
        {
            if (lane.GetComponent<lanescriptupdatev1>().targetspeed > -50 && lane.GetComponent<lanescriptupdatev1>().targetspeed < 50)
            {
                slowrotate = true;
            }
            else
            {
                slowrotate = false;
            }
        }

        

        if (slowrotate)
        {
            anchorpoint_script.transform.rotation = Quaternion.Euler(0, 0, lane.transform.eulerAngles.z);
        }
    }
}
