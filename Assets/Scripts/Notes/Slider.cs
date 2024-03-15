using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slider : MonoBehaviour
{
    public GameObject self;
    public GameObject create;

    public bool critical = false;
    public bool fair = false;
    public bool error = false;

    public bool creator;

    public bool canBePressed = false;
    public bool getTheScoreStatus = false;

    public static Slider instance;
   
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.localPosition = new Vector3();
        //case1 = true;
        //case2 = true;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.touchCount > 0)
        {
            foreach(Touch touch in Input.touches)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if(!getTheScoreStatus)
                {
                    if(canBePressed)
                    {
                        if(Physics.Raycast(ray, out hit))
                        {
                                gameObject.SetActive(false);
                                critical = true;
                                ScoreDisplay.instance.criticalTap += 1;

                                Debug.Log("Critical");
                                ScoreDisplay.instance.DisplayedScore(critical, fair, error);
                        }
                        else
                        {
                            error = true;
                            ScoreDisplay.instance.errorTap += 1;

                            Debug.Log("Error");
                            ScoreDisplay.instance.DisplayedScore(critical, fair, error);
                        }
                        getTheScoreStatus = true;
                    }
                }
            }
        }


        if(creator)
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchpos = Camera.main.ScreenToWorldPoint(touch.position);

                if(touch.phase == TouchPhase.Began)
                {
                    Instantiate(create, touchpos, Quaternion.identity);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("JudgementLineCenter")) {
            canBePressed = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.CompareTag("JudgementLineCenter")) {
            Debug.Log("Keluar");
            canBePressed = false;
            critical = false;
            fair = false;
            error = true;
            ScoreDisplay.instance.errorTap += 1;
            ScoreDisplay.instance.DisplayedScore(critical, fair, error);
        }
    }
}