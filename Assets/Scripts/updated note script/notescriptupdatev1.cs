using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notescriptupdatev1 : MonoBehaviour
{
    //optimalization
    public 
        bool on_area, rotate_to_target, slowrotate;

    public 
        GameObject anchorpoint_script, bpmcontroller, lane;

    public float maxvalue;

    public 
        float currentfloat, percentage, timelapsed, acumulation, currentlanez, accel, targetspeed, rotaz;

    float factorial;
    float rotaspeed;

    public static notescriptupdatev1 notescr;

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
        maxvalue = 420;
        factorial = 0.5f;
        //kind = 0;
        //targetspeed = 0;
    }

    // Update is called once per frame
    void Update()
    {

        
        if (bpmcontroller.GetComponent<chartbpm>().enabled == false)
        {
            targetspeed = 0;
        }
        else
        {
            targetspeed = bpmcontroller.GetComponent<chartbpm>().bpm * 60 / 4 / 2;
        }
        
        if (on_area)
        {
            if (lane.GetComponent<lanescriptupdatev1>().targetspeed > 50)
            {
                Debug.Log("k");
                currentfloat = lane.GetComponent<lanescriptupdatev1>().targetspeed - 50;
                kind = 1;
            }
            else if(lane.GetComponent<lanescriptupdatev1>().targetspeed >= -50 && targetspeed <= 50)
            {
                currentfloat = 0;
                kind = 0;
                Debug.Log("u");
                anchorpoint_script.transform.rotation = Quaternion.Euler(0, 0, lane.transform.eulerAngles.z);
            }
            else if(lane.GetComponent<lanescriptupdatev1>().targetspeed < -50)
            {
                Debug.Log("j");
                currentfloat = lane.GetComponent<lanescriptupdatev1>().targetspeed + 50;
                kind = 1;
            }




            rotaz = anchorpoint_script.transform.eulerAngles.z;
            if (rotaz < 180)
            {
                currentlanez = rotaz;
            }
            else if (rotaz > 180)
            {
                currentlanez = rotaz - 360;
            }

            percentage = (currentfloat / maxvalue) * 105f;
            percentage = Mathf.Min(percentage, 105f);
            

            rotate_to_target = true;
            timelapsed += Time.deltaTime;
            StartCoroutine(notetowards());

            if(currentlanez > percentage)
            {
                //timelapsed = 0;
                rotate_to_target = false;
                //rotate_back = true;
                StopAllCoroutines();
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("active area"))
        {
            on_area = true;

        }
    }

    private IEnumerator notetowards()
    {
        float startangle = acumulation;
        //Debug.Log("hai");
        if (currentfloat > 0)
        {
            //Debug.Log("hay");
            if (rotate_to_target)
            {
                //Debug.Log("done");
                while (currentlanez < percentage && kind > 0)
                {
                    //Debug.Log("done");
                    //fastrotate = false;
                    //Debug.Log("orieuler");
                    //timelapsed += Time.deltaTime;
                    accel = Mathf.Lerp(0, targetspeed, timelapsed / factorial);
                    rotaspeed = accel * Time.deltaTime;
                    startangle += rotaspeed;

                    anchorpoint_script.transform.rotation = Quaternion.Euler(0, 0, startangle);
                    acumulation = anchorpoint_script.transform.eulerAngles.z;
                    //slowrotate = false;
                    //running = true;
                    yield return null;


                }
                //yield return null;


            }
            //yield return null;
        }


        if (currentfloat < 0)
        {
            if (rotate_to_target)
            {
                //Debug.Log("done");


                while (currentlanez > percentage && kind > 0)
                {

                    //fastrotate = false;
                    //Debug.Log("orieuler");
                    //timelapsed += Time.deltaTime;
                    accel = Mathf.Lerp(0, -targetspeed, timelapsed / factorial);
                    rotaspeed = accel * Time.deltaTime;
                    startangle += rotaspeed;

                    anchorpoint_script.transform.rotation = Quaternion.Euler(0, 0, startangle);
                    acumulation = anchorpoint_script.transform.eulerAngles.z;
                    //slowrotate = false;
                    //running = true;
                    yield return null;
                }
            }
        }

        




    }

    
}
