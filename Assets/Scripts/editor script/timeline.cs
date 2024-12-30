using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class timeline : MonoBehaviour
{
    //Note guide koneksi ke UI, gunakan forplay untuk bool interact dan play
    //dan gunakan mytime untuk bool manual
    private Vector3 moveOffset;
    private Vector3 moveOffset2;
    private Camera mainCamera;
    public bool interact;
    public bool prevboolInteract;
    public int current_interact;
    private float moveMinimum;
    public float timing;
    public float time;
    public int mytime;
    public static timelinecharter timelinecharter;
    private Vector3 lastTiming;
    public bool playing;
    public bool prevbool_play;
    //public bool stop;
    public float forplay;
    public bool manual;
    public GameObject beatlinePos;
    public float speed;
    //public static timeline timelinee;
    public int testTime; 
    //private bool[] array;
    // Start is called before the first frame update
    void Start()
    {
        //timelinee = this;
        mainCamera = Camera.main;
        lastTiming = gameObject.transform.position;
        manual = true;
        moveMinimum = gameObject.transform.position.x;
        current_interact = 0;
        

    }

    private void OnMouseDown()
    {
        interact = true;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, 0, 0);
        //Vector3 lanePOV = new Vector3(0, 0, Input.mousePosition.x);
        //var mousePositionX = mousePosition.x;
        mousePosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
        moveOffset = transform.position - mainCamera.ScreenToWorldPoint(mousePosition);
        //moveOffset2 = beatlinePos.transform.position - mainCamera.ScreenToWorldPoint(lanePOV);
        //Vector3 LanePOV = new Vector3()
        
        //Vector3 mousePositionX = Input.mousePosition.x;
        
    }

    

    private void OnMouseUp()
    {
        interact = false;
    }

    public void resetting_noteSpeed()
    {
        timing = 0;
        time = 0;
        mytime = 0;
        forplay = 0;
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.P))
        {
            playing = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playing = false;
        }
        //timing = gameObject.transform.position.x - 205;


        /*Vector3 currentTime = gameObject.transform.position;
        if (currentTime.x > lastTiming.x)
        {
            timing++;
        }
        else if (currentTime.x < lastTiming.x) { timing -= 1; }

        if (gameObject.transform.position.x == moveMinimum)
        {
            timing--;
        }

        if (gameObject.transform.position.x == moveMinimum)
        {
            timing = 0;
        }

        lastTiming = currentTime;*/
        //mytime = (int)forplay;
        if (manual && !prevboolInteract)
        {
            timing = 0;
            time = 0;
            mytime = mytime / 10;
            forplay = 0;
            
        }
        prevboolInteract = manual;
        
        if(playing && !prevbool_play)
        {
            timing = 0;
            time = 0;
            //mytime = mytime / 10;
            //forplay = 0;
        }
        prevbool_play = playing;


        if (interact)
        {
            //resettor += 1;
            manual = false;
            //Vector3 currentMousePos = Input.mousePosition;
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, 0, 0);
            //Vector3 lanePOV = new Vector3(0, 0, Input.mousePosition.x);
            mousePosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
            Vector3 objectPos = mainCamera.ScreenToWorldPoint(mousePosition) + moveOffset;
            //Vector3 lanePOVPos = mainCamera.ScreenToWorldPoint(lanePOV) + moveOffset2;
            

            
            
            timing = gameObject.transform.position.x - moveMinimum;
            time = timing * 1000;
            mytime = (int)time / 10;
            //current_interact = mytime;
            forplay = mytime / 10;


            if (objectPos.x >= moveMinimum)
            {
                transform.position = new Vector3(objectPos.x, transform.position.y, transform.position.z);
                beatlinePos.transform.position = new Vector3(beatlinePos.transform.position.x, 0, -(objectPos.x - moveMinimum));
            }
            else
            {
                transform.position = new Vector3(moveMinimum, transform.position.y, transform.position.z);
                beatlinePos.transform.position = new Vector3(beatlinePos.transform.position.x, 0, 0);
            }

            

            
        }

        
        


        if (playing)
        {
            manual = false;
            forplay += 1;
            gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            beatlinePos.transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
            timing = gameObject.transform.position.x - moveMinimum;
            time = timing * 1000;
            mytime = (int)time / 10;
            //forplay = mytime / 10;


        }

        //if (stop)
        //{
        //    
        //}

        if (!playing && !interact)
        {
           manual = true;
        }
        else
        {

            manual = false; 
        }
        
        if (manual)
        {
            if(mytime >= 0)
            {
                forplay = (int)mytime / 10;
                time = (float)mytime * 100;
                timing = (time / 1000) + moveMinimum;
                gameObject.transform.position = new Vector3(moveMinimum + time / 1000, gameObject.transform.position.y, gameObject.transform.position.z);
                beatlinePos.transform.position = new Vector3(beatlinePos.transform.position.x, 0, -(gameObject.transform.position.x - moveMinimum));
            }
            else
            {
                mytime = 0;
                beatlinePos.transform.position = new Vector3(beatlinePos.transform.position.x, 0, 0);
            }
            
        }

        if(forplay == testTime)
        {
            playing = false;
        }

        
    }
}
