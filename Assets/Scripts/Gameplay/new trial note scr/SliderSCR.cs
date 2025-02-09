using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEngine;
using UnityEngine.Video;
using System;
using System.Threading;

public class slidescr : MonoBehaviour
{
    //Keperluan Pribadi Note
    public GameObject judgement;
    public GameObject MainSelf;
    //cek posisi note untuk menentukan score
    public float hitpos;

    //List BOOL position
    public bool perfectplus;
    public bool early;
    public bool late;

    //Variable untuk VFX
    public Transform selfpos;
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
        /*RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, Mathf.Infinity);
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
        }*/

        //Definisi GO untuk VFX
        selfpos = gameObject.transform;
        canvas_vfx = GameObject.Find("vfxcanvas").transform;
    }

    // Update is called once per frame
    void Update()
    {
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

                }
            }
        }*/

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

        if (jack == null)
        { gameObject.GetComponent<Collider>().enabled = true; }
        else
        { gameObject.GetComponent<Collider>().enabled = false; }

        //check apakah note early atau late
        if (judgement != null)
        {
            Vector3 thisZ = new Vector3(0, 0, transform.position.z);
            Vector3 laneZ = new Vector3(0, 0, judgement.transform.position.z);
            if (EarlyLateCheck(judgement))
            {
                early = true; late = false;
                hitpos = Vector3.Distance(thisZ, laneZ);
            }
            else
            {
                late = true; early = false;
                hitpos = -Vector3.Distance(thisZ, laneZ);
            }
        }

        //miss note
        if (hitpos <= -1)
        { Debug.Log("miss"); Destroy(MainSelf.gameObject); ; }
    }

    bool EarlyLateCheck(GameObject other)
    {
        Vector3 directionToTarget = other.transform.position - transform.position;
        float dotProduct = Vector3.Dot(transform.forward, directionToTarget.normalized);
        return dotProduct > 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("touch system"))
        {
            getscore(); Debug.Log("pure+");
        }
        
    }

    void getscore()
    {
        Instantiate(VFX, transform.position, selfpos.rotation, canvas_vfx);
        Destroy(MainSelf.gameObject);
    }
}
