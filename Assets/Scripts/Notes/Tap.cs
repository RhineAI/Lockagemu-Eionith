using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tap : MonoBehaviour
{
    public GameObject self;
    public GameObject falser;
    public GameObject create;

    public bool critical = false;
    public bool fair = false;
    public bool error = false;
    
    public bool already;
    public bool creator;
    public bool canBePressed = false;
    public bool getTheScoreStatus = false;

    public static Tap boolian;

    private double judgementZPosition;
   
    // Start is called before the first frame update
    void Start()
    {
        boolian = this;
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (canBePressed && Input.touchCount > 0)
        {
            judgementZPosition = JudgementLine.instance.judgementZPosition;
            // foreach (Touch touch in Input.touches)
            // {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    float objectPosition = self.transform.position.z;
                    // Debug.Log($"Judgement : {Math.Abs(judgementZPosition)} ObjectPosition : {Math.Abs(objectPosition)}");
                    if(!getTheScoreStatus)
                    {
                        if (Input.GetTouch(0).phase == TouchPhase.Ended)
                        {
                            // Debug.Log("tap");
                            // Debug.Log(Math.Abs(Math.Abs(judgementZPosition) - Math.Abs(objectPosition)));
                            if (Math.Abs(Math.Abs(judgementZPosition) - Math.Abs(objectPosition)) <= 0.3)
                            {
                                critical = true;
                                ScoreDisplay.instance.criticalTap += 1;

                                Debug.Log("Critical");
                            }
                            else if (Math.Abs(Math.Abs(judgementZPosition) - Math.Abs(objectPosition)) <= 1.5)
                            {
                                fair = true;
                                ScoreDisplay.instance.fairTap += 1;

                                Debug.Log("Fair");
                            } 
                            else {
                                error = true;
                                ScoreDisplay.instance.errorTap += 1;

                                Debug.Log("Error");
                            }
                            getTheScoreStatus = true;
                            ScoreDisplay.instance.DisplayedScore(critical, fair, error);
                            gameObject.SetActive(false);
                        }
                    }
                }
            // }
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
        if(collision.collider.CompareTag("JudgementLine")) {
            canBePressed = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(gameObject.activeSelf)
        {
            if(collision.collider.CompareTag("JudgementLine")) {
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
}
