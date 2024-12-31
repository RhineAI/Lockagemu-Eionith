using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marker : MonoBehaviour
{    
    public GameObject note;
    public GameObject bpmobj;
    //public Transform bpmobjtrs;
    public float rendering;

    public GameObject Q_current_note_tap_or_hold_or_marker;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            create();
            timer = Time.time;
            rendering = bpmobj.GetComponent<chartbpm>().bpm;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            if(Q_current_note_tap_or_hold_or_marker != null)
            {
                float longnote = (Time.time - timer) * rendering;
                Q_current_note_tap_or_hold_or_marker.transform.localScale = new Vector3(1, 1, longnote);
                Q_current_note_tap_or_hold_or_marker.transform.position += new Vector3(0, 0, gameObject.GetComponent<chartbpm>().bpm * Time.deltaTime);
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            //Q_current_note_tap_or_hold_or_marker.GetComponent<chartbpm>().bpm = 0;
            Q_current_note_tap_or_hold_or_marker = null;
        }
    }

    void create()
    {
        Q_current_note_tap_or_hold_or_marker = Instantiate(note, bpmobj.transform.position, Quaternion.identity);
    }
}
