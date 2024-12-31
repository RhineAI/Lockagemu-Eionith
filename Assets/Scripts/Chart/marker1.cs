using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marker1 : MonoBehaviour
{    
    public GameObject note;
    public GameObject bpmobj;
    //public Transform bpmobjtrs;
    public float rendering;

    public GameObject Q_current_note_tap_or_hold;
    public float timer;
    public float view;

    public bool fading;
    public GameObject judgement; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            //create();
            timer = Time.time;
            rendering = bpmobj.GetComponent<chartbpm>().bpm * -1;
        }
        else if (fading)
        {
            
            if (Q_current_note_tap_or_hold != null)
            {
                float currentlong = Q_current_note_tap_or_hold.transform.localScale.z;
                float longnote = (Time.time - timer) * rendering;
                Q_current_note_tap_or_hold.transform.localScale -= new Vector3(0, 0, rendering);
                view = longnote;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject == judgement)
        {
            fading = true;
        }
    }

    void create()
    {
        Q_current_note_tap_or_hold = Instantiate(note, Vector3.zero, Quaternion.identity);
    }
}
