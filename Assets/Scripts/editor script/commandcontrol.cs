using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class commandcontrol : MonoBehaviour
{
    public bool Tap;
    public bool Hold;
    public bool slide;
    public bool flick;
    public bool sideflick;

    public GameObject TapNote;
    public GameObject HoldNote;
    public GameObject SlideNote;
    public GameObject FlickNote;
    public GameObject SideFlickNote;

    public GameObject Ray_sync;

    public Transform ParentChart;
    // Start is called before the first frame update
    void Start()
    {
        Tap = true;
        Hold = false;
        slide = false;
        flick = false;
        sideflick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Ray_sync.GetComponent<rayplacenote>().currentLane != null)
        {
            if (Tap)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(TapNote, Ray_sync.GetComponent<rayplacenote>().currentLane.transform.position, Quaternion.identity);
                }

            }

            if (Hold)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(HoldNote, Ray_sync.GetComponent<rayplacenote>().currentLane.transform.position, Quaternion.identity);
                }

            }

            if (slide)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(SlideNote, Ray_sync.GetComponent<rayplacenote>().prePlaceNote.transform.position, Quaternion.identity);
                }

            }

            if (flick)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(FlickNote, Ray_sync.GetComponent<rayplacenote>().currentLane.transform.position, Quaternion.identity);
                }

            }

            if (sideflick)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(SideFlickNote, Ray_sync.GetComponent<rayplacenote>().currentLane.transform.position, Quaternion.identity);
                }

            }
        }
        
    }

    public void TapCreate()
    {
         Tap = true;
     Hold = false;
        slide = false;
     flick = false;
     sideflick = false;
    }

    public void HoldCreate()
    {
        Tap = false;
        Hold = true;
        slide = false;
        flick = false;
        sideflick = false;
    }

    public void SlideCreate()
    {
        Tap = false;
        Hold = false;
        slide = true;
        flick = false;
        sideflick = false;
    }

    public void FlickCreate()
    {
        Tap = false;
        Hold = false;
        slide = false;
        flick = true;
        sideflick = false;
    }

    public void SideflickCreate()
    {
        Tap = false;
        Hold = false;
        slide = false;
        flick = false;
        sideflick = true;
    }
}
