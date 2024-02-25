using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slider : MonoBehaviour
{
    public GameObject self;
    public GameObject falser;
    public GameObject create;

    private bool slider = false;
    public bool critical = false;
    public bool fair = false;
    public bool error = false;


    public bool already;
    public bool creator;

    public bool noteActiveStatus;
    public bool canBePressed = false;

    public bool wrongtouch;
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
         if(slider)
        {
            if (Input.touchCount > 0)
            {
                foreach(Touch touch in Input.touches)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if(Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                        {
                            critical = true;
                            Debug.Log("Critical");
                        }
                    }
                    else
                    {
                        error = true;
                        Debug.Log("Error");
                    }

                    if(touch.phase == TouchPhase.Ended)
                    {
                        gameObject.SetActive(false);
                        noteActiveStatus = false;
                        Debug.Log("tap-release");
                    }
                }

                if(!noteActiveStatus) 
                {
                    if(critical || error) 
                    {
                        if(critical) 
                        {
                            ScoreDisplay.instance.criticalTap += 1;
                        }


                        if(error) 
                        {
                            ScoreDisplay.instance.errorTap += 1;
                        }
                        ScoreDisplay.instance.DisplayedScore(critical, fair, error);
                    }
                    // isActive = true;
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
            slider = true;
            canBePressed = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.CompareTag("JudgementLineCenter")) {
            slider = false;
            canBePressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(falser)
        {
            if (other.tag == "touch system")
            {
                Debug.Log("hi");
                Slider.instance.booler();
                Debug.Log("hi");
            }
        }
    }

    public void booler()
    {
        wrongtouch = true;
    }

    public void debooler()
    {
        wrongtouch = false;
    }
}
