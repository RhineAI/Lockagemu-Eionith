using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class marker : MonoBehaviour
{
    public GameObject mark_point;
    public GameObject mark_hold;
    public GameObject instantiatedobj;
    public GameObject timeline_sync;

    public Transform point_pos;


    public float timer;
    //public float multimarkPos;
    public float scale_speed;

    public bool tap_or_hold;
    public bool multiMark;
    //public keperluan multimark
    public GameObject instantD;
    public GameObject instantF;
    public GameObject instantJ;
    public GameObject instantK;
    //end
    public bool scaling;

    //public KeyCode presskey;
    // Start is called before the first frame update
    void Start()
    {
        tap_or_hold = false;
        point_pos = gameObject.transform;
        timeline_sync = gameObject;
        scale_speed = timeline_sync.GetComponent<timeline>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        //presskey = Input.GetKeyDown;
        if (!multiMark)
        {
            if (tap_or_hold)
            {
                timer += 1;
            }
            if (Input.GetKey(KeyCode.M))
            {
                tap_or_hold = true;
                if (timer == 20)
                {
                    Debug.Log("hold mark");
                    markholdnote();
                }
            }
            if (Input.GetKeyUp(KeyCode.M))
            {
                if (timer < 20)
                {
                    Debug.Log("tap mark");
                    tap_or_hold = false;
                    timer = 0;
                    InsTapNote();
                }
                else
                {
                    scaling = false;
                    tap_or_hold = false;
                    timer = 0;
                }

            }
        }
        else if (multiMark)
        {
            if (tap_or_hold)
            {
                timer += 1;
            }
            //group DFJK
            if (Input.GetKey(KeyCode.D)) {  tap_or_hold = true; if (timer == 20) { markholdnote(); } }
            if (Input.GetKeyUp(KeyCode.D)) if (timer < 20){tap_or_hold = false;timer = 0;InsTapNote();}else{scaling = false;tap_or_hold = false;timer = 0;}
            if (Input.GetKey(KeyCode.F)) {  tap_or_hold = true; if (timer == 20) { markholdnote(); } }
            if (Input.GetKeyUp(KeyCode.F)) if (timer < 20) { tap_or_hold = false; timer = 0; InsTapNote(); } else { scaling = false; tap_or_hold = false; timer = 0; }
            if (Input.GetKey(KeyCode.J)) {  tap_or_hold = true; if (timer == 20) { markholdnote(); } }
            if (Input.GetKeyUp(KeyCode.J)) if (timer < 20) { tap_or_hold = false; timer = 0; InsTapNote(); } else { scaling = false; tap_or_hold = false; timer = 0; }
            if (Input.GetKey(KeyCode.K)) {  tap_or_hold = true; if (timer == 20) { markholdnote(); } }
            if (Input.GetKeyUp(KeyCode.K)) if (timer < 20) { tap_or_hold = false; timer = 0; InsTapNote(); } else { scaling = false; tap_or_hold = false; timer = 0; }
            //end
            

            
        }

        //for hold
        if (scaling)
        {
            if (!multiMark)
            {
                instantiatedobj.transform.localScale += new Vector3(scale_speed * Time.deltaTime, 0, 0);
            }
            else if (multiMark)
            {
                if (Input.GetKey(KeyCode.D)) { instantD.transform.localScale += new Vector3(scale_speed * Time.deltaTime, 0, 0); }
                if (Input.GetKey(KeyCode.F)) { instantF.transform.localScale += new Vector3(scale_speed * Time.deltaTime, 0, 0); }
                if (Input.GetKey(KeyCode.J)) { instantJ.transform.localScale += new Vector3(scale_speed * Time.deltaTime, 0, 0); }
                if (Input.GetKey(KeyCode.K)) { instantK.transform.localScale += new Vector3(scale_speed * Time.deltaTime, 0, 0); }

            }

        }
    }

    void InsTapNote()
    {
        if (!multiMark)
        {
            Instantiate(mark_point, mark_point.transform.position = new Vector3(point_pos.transform.position.x,
            point_pos.transform.position.y + 1, -10), Quaternion.Euler(0, 0, 60));
        }
        else if (multiMark)
        {
            if (Input.GetKeyUp(KeyCode.D)) {Instantiate(mark_point, mark_point.transform.position = new Vector3(point_pos.transform.position.x,
                point_pos.transform.position.y +4, -10), Quaternion.Euler(0, 0, 60));}
            if (Input.GetKeyUp(KeyCode.F)) {Instantiate(mark_point, mark_point.transform.position = new Vector3(point_pos.transform.position.x,
                point_pos.transform.position.y +3, -10), Quaternion.Euler(0, 0, 60));}
            if (Input.GetKeyUp(KeyCode.J)) {Instantiate(mark_point, mark_point.transform.position = new Vector3(point_pos.transform.position.x,
                point_pos.transform.position.y +2, -10), Quaternion.Euler(0, 0, 60));}
            if (Input.GetKeyUp(KeyCode.K)) {Instantiate(mark_point, mark_point.transform.position = new Vector3(point_pos.transform.position.x,
                point_pos.transform.position.y +1, -10), Quaternion.Euler(0, 0, 60));}
            
        }

    }

    void markholdnote()
    {
        if (!multiMark)
        {
            instantiatedobj = Instantiate(mark_hold, mark_hold.transform.position = new Vector3(point_pos.transform.position.x - 1,
            point_pos.transform.position.y + 1, -10), Quaternion.identity);

            instantiatedobj.transform.localScale = new Vector3(mark_hold.transform.localScale.x,
                 mark_hold.transform.localScale.y, mark_hold.transform.localScale.z);

            scaling = true;
        }
        else if (multiMark)
        {
            if(Input.GetKey(KeyCode.D)) { instantD = Instantiate(mark_hold, mark_hold.transform.position = new Vector3(point_pos.transform.position.x - 1,
            point_pos.transform.position.y + 4, -10), Quaternion.identity);instantD.transform.localScale = new Vector3(mark_hold.transform.localScale.x,
            mark_hold.transform.localScale.y, mark_hold.transform.localScale.z);scaling = true;}
            if(Input.GetKey(KeyCode.F)) { instantF = Instantiate(mark_hold, mark_hold.transform.position = new Vector3(point_pos.transform.position.x - 1,
            point_pos.transform.position.y + 3, -10), Quaternion.identity);instantF.transform.localScale = new Vector3(mark_hold.transform.localScale.x,
            mark_hold.transform.localScale.y, mark_hold.transform.localScale.z);scaling = true;}
            if(Input.GetKey(KeyCode.J)) { instantJ = Instantiate(mark_hold, mark_hold.transform.position = new Vector3(point_pos.transform.position.x - 1,
            point_pos.transform.position.y + 2, -10), Quaternion.identity);instantJ.transform.localScale = new Vector3(mark_hold.transform.localScale.x,
            mark_hold.transform.localScale.y, mark_hold.transform.localScale.z);scaling = true;}
            if(Input.GetKey(KeyCode.K)) { instantK = Instantiate(mark_hold, mark_hold.transform.position = new Vector3(point_pos.transform.position.x - 1,
            point_pos.transform.position.y + 1, -10), Quaternion.identity);instantK.transform.localScale = new Vector3(mark_hold.transform.localScale.x,
            mark_hold.transform.localScale.y, mark_hold.transform.localScale.z);scaling = true;}
            
        }

    }
}
