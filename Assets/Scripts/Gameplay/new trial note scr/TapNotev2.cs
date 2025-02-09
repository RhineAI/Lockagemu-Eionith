using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.Video;
using System;
using UnityEditor.Experimental.GraphView;

public class TapNotev2 : MonoBehaviour
{
    //Keperluan Pribadi Note menentukan ada di lane mana untuk real time
    public GameObject save_parent_lane;
    public GameObject lane;
    public GameObject MainSelf;
    //cek posisi note untuk menentukan score
    public float hitpos;

    //List BOOL position
    public bool far;
    public bool perfect;
    public bool perfectplus;
    public bool early;
    public bool late;

    //Variable untuk VFX
    public Transform selfpos;
    public Transform selfup;
    public Transform canvas_vfx;
    public GameObject VFX;

    //Jack or Train Pattern Detection
    public GameObject jack;

    public float detectionRange = 10f; // Jarak maksimum deteksi
    public LayerMask detectionLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //baris code Jack Or Train Pattern Detection
        /*RaycastHit[] hits = Physics.RaycastAll(transform.position, -transform.forward, Mathf.Infinity);
        float closest_distance = Mathf.Infinity;
        GameObject closest_note = null;
        foreach (RaycastHit hit in hits){
            if (hit.collider.CompareTag("note") && hit.collider.gameObject != gameObject){
                float distance = Vector3.Distance(transform.position, hit.point);
                if (distance < closest_distance){closest_distance = distance;
                    closest_note = hit.collider.gameObject;
                    jack = hit.collider.gameObject;
                    gameObject.GetComponent<Collider>().enabled = false;
                }}}*/

        //Definisi GO untuk VFX
        selfpos = gameObject.transform;
        canvas_vfx = GameObject.Find("vfxcanvas").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //selfup.transform.position = new Vector3(selfpos.transform.position.x, selfpos.transform.position.y - 1, selfpos.transform.position.z);
        Ray ray = new Ray(selfpos.position, selfpos.forward); // Mulai ray dari posisi note, ke arah depannya
        RaycastHit hit;

        // Raycast ke depan dari posisi note
        if (Physics.Raycast(ray, out hit, detectionRange, detectionLayer))
        {
            //Debug.Log($"Objek terdekat di depan: {hit.collider.gameObject.name}");
            jack = hit.collider.gameObject;
        }
        else
        {
            jack = null;
        }

        // Debug visual dengan Gizmos
        //Debug.DrawRay(selfpos.position, selfpos.forward * detectionRange, Color.red);
        //baris code Jack Or Train Pattern Detection
        /*RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, Mathf.Infinity);
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

                }}}*/

        if (jack == null)
        { gameObject.GetComponent<Collider>().enabled = true; }
        else
        { gameObject.GetComponent<Collider>().enabled = false; }
        
        //check apakah note early atau late
        if (lane != null)
        { Vector3 thisZ = new Vector3(0, 0, transform.position.z);
            Vector3 laneZ = new Vector3(0, 0, lane.transform.position.z);
            if (EarlyLateCheck(lane))
            { early = true; late = false;
                hitpos = Vector3.Distance(thisZ, laneZ); }
            else
            { late = true; early = false;
                hitpos = -Vector3.Distance(thisZ, laneZ); }}

        //miss note
        if (hitpos <= -1)
        { Debug.Log("miss"); Destroy(MainSelf.gameObject); ; }
    }

    /*void OnDrawGizmos()
    {
        // Gambar ray untuk debugging
        Gizmos.color = Color.red;
        Gizmos.DrawRay(gameObject.transform.position, gameObject.transform.forward * detectionRange);
    }*/
    //bool check posisi note didepan atau dibelakang titik judgement
    bool EarlyLateCheck(GameObject other)
    {
        Vector3 directionToTarget = other.transform.position - transform.position;
        float dotProduct = Vector3.Dot(transform.forward, directionToTarget.normalized);
        return dotProduct > 0;
    }

    
    void OnCollisionEnter(Collision collision)
    {
        //sebuah note mendeteksi berada di lane mana
        if (collision.collider.CompareTag("lane"))
        {save_parent_lane = collision.gameObject;
            if (save_parent_lane.transform.childCount > 0)
            {lane = save_parent_lane.transform.GetChild(0).gameObject;}}
    }

    void OnCollisionStay(Collision collision)
    {
        float Far = 2f;
        float Pure = 1.25f;
        float PerfectPlus = 0.5f;
        
        //update score apa yang akan didapat (pure/far?)
        if (hitpos <= PerfectPlus && hitpos >= -PerfectPlus) { perfectplus = true;} 
        else { perfectplus = false; }
        if (hitpos <= Pure && hitpos >= -Pure){perfect = true;}
        else { perfect = false; }
        if ((hitpos <= Far && hitpos >= Pure) || hitpos <= -Pure){ far = true;}
        else { far = false; }
        if (lane != null)
        {   
            if (lane.GetComponent<JudgementSCR>().Tap == true)
            {
                //EARLY
                if (hitpos <= Far && hitpos >= Pure)
                { getscore(); Debug.Log("far early"); }

                if (hitpos <= Pure && hitpos >= PerfectPlus)
                { getscore(); Debug.Log("pure early"); }

                //+++
                if (hitpos <= PerfectPlus && hitpos >= -PerfectPlus)
                { getscore(); Debug.Log("pure+"); }

                //LATE
                if (hitpos <= -PerfectPlus && hitpos >= -Pure)
                { getscore(); Debug.Log("pure late"); }

                if (hitpos <= -Pure)
                { getscore(); Debug.Log("far late"); }}}
    }

    //instans VFX
    void getscore()
    {
        Instantiate(VFX, lane.transform.position, selfpos.rotation, canvas_vfx);
        Destroy(MainSelf.gameObject);
    }
}
