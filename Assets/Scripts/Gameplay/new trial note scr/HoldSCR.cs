using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEngine;
using UnityEngine.Video;
using System;

public class holdscr : MonoBehaviour
{
    //Keperluan Pribadi Note
    public GameObject save_parent_lane;
    public GameObject lane;
    public GameObject HoldRender;
    public GameObject MainSelf;
    //cek posisi note untuk menentukan score
    public float hitpos;
    
    //LIST BOOL
    public bool isHold;
    public bool hasHolded;
    public bool fixhitpos;
    
    //Variable untuk VFX
    public Transform selfpos;
    public Transform canvas_vfx;
    public GameObject VFX;

    //Jack or Train Pattern Detection
    public GameObject jack;

    //transisi fadeout holdNote
    public GameObject scale_manipulation;
    public GameObject Bpm_source;
    public float bpm;
    public float UpdateScale;
    Animator anim;
    public float multiply;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ambil komponen render object
        HoldRender = gameObject;

        //baris code Jack Or Train Pattern Detection
        RaycastHit[] hits = Physics.RaycastAll(transform.position, -transform.forward, Mathf.Infinity);
        float closest_distance = Mathf.Infinity;
        GameObject closest_note = null;
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("note") && hit.collider.gameObject != gameObject)
            {
                float distance = Vector3.Distance(transform.position, hit.point);
                if (distance < closest_distance)
                {
                    closest_distance = distance;
                    closest_note = hit.collider.gameObject;
                    jack = hit.collider.gameObject;
                    gameObject.GetComponent<Collider>().enabled = false;
                }
            }
        }

        //Definisi GO untuk VFX
        anim = GetComponent<Animator>();
        selfpos = gameObject.transform;
        canvas_vfx = GameObject.Find("vfxcanvas").transform;

        //FADEOUT HOLDNOTE
        UpdateScale = scale_manipulation.transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        //baris code Jack Or Train Pattern Detection
        RaycastHit[] hits = Physics.RaycastAll(transform.position, -transform.forward, Mathf.Infinity);
        float closest_distance = Mathf.Infinity;
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("note") && hit.collider.gameObject != gameObject)
            {
                //Debug.DrawRay(transform.position, transform.forward * closest_distance, Color.red, 1f);
                float distance = Vector3.Distance(transform.position, hit.point);
                if (distance < closest_distance)
                {
                    closest_distance = distance;
                    jack = hit.collider.gameObject;
                    gameObject.GetComponent<Collider>().enabled = false;

                }
            }
        }

        if (jack == null)
        { gameObject.GetComponent<Collider>().enabled = true; }
        else
        { gameObject.GetComponent<Collider>().enabled = false; }

        if (lane != null)
        {
            Vector3 thisHead = new Vector3(0, 0, gameObject.GetComponent<Collider>().bounds.min.z);
            Vector3 laneZ = new Vector3(0, 0, lane.transform.position.z);
            Vector3 thisEnded = new Vector3(0, 0, gameObject.GetComponent<Collider>().bounds.max.z);
            if (!fixhitpos)
            {
                hitpos = Vector3.Distance(thisEnded, laneZ);
            }
            if (fixhitpos) { hitpos = 0; bpm = Bpm_source.GetComponent<chartbpm>().bpm * 0.565f; UpdateScale -= bpm * Time.deltaTime ;
                if (isHold)
                {
                    multiply = 0.6f;
                    scale_manipulation.transform.localScale = new Vector3(scale_manipulation.transform.localScale.x,
                            scale_manipulation.transform.localScale.y, UpdateScale - 0.12f);
                    Instantiate(VFX, lane.transform.position, selfpos.rotation, canvas_vfx);
                    if (UpdateScale <= 0)
                    {
                        scale_manipulation.transform.localScale = new Vector3(scale_manipulation.transform.localScale.x,
                            scale_manipulation.transform.localScale.y, 0);
                        anim.SetBool("end_hold", true);
                    }
                }
                else
                {
                    multiply = 0.55f;
                }
            }
            if (EarlyLateCheck(lane))
            {
                hitpos = -Vector3.Distance(thisHead, laneZ);
            }
        }
            if (isHold ) { HoldRender.GetComponent<Renderer>().material.color = Color.magenta; }
        else if (!isHold) { HoldRender.GetComponent<Renderer>().material.color= Color.cyan; }

        if(hitpos <= -1)
        { Destroy(MainSelf.gameObject); }

    }

    //bool check posisi note didepan atau dibelakang titik judgement
    bool EarlyLateCheck(GameObject other)
    {
        Vector3 directionToTarget = other.transform.position - gameObject.GetComponent<Collider>().bounds.min;
        float dotProduct = Vector3.Dot(transform.forward, directionToTarget.normalized);
        return dotProduct > 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        //sebuah note mendeteksi berada di lane mana
        if (collision.collider.CompareTag("parent judge"))
        {
            save_parent_lane = collision.gameObject;
            if (save_parent_lane.transform.childCount > 0)
            {
                lane = save_parent_lane.transform.GetChild(0).gameObject;
            }    
        }
        if (collision.collider.CompareTag("judgement"))
        { fixhitpos = true; }
    }

    void OnCollisionStay(Collision collision)
    {
        if (lane != null)
        {
            
            if (hitpos <= 0.25)
            {
                if (lane.GetComponent<JudgementSCR>().Tap == true)
                {
                    hasHolded = true;
                    fixhitpos = true;

                }
            }

            if (lane.GetComponent<JudgementSCR>().hold == true)
            {
                if (hasHolded)
                {
                    isHold = true;
                }

            }
            else if (lane.GetComponent <JudgementSCR>().hold == false)
            {
                isHold = false;
            }
        }

        
    }

    
}
