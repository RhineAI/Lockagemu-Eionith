using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DirectionalFlick : MonoBehaviour
{
    public GameObject self;
    public GameObject falser;
    public GameObject create;

    public bool tap;
    public bool directionalFlick;
    public bool already;
    public bool creator;
    public bool falsers;
    public bool canBePressed = false;
    public bool wrongtouch;
    public static DirectionalFlick instance;
   
    private double judgementZPosition;

    Vector2 startpos;
    Vector2 movepos;
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
        if (directionalFlick)
        {
            if (canBePressed && Input.touchCount > 0)
            {
                judgementZPosition = JudgementLine.instance.judgementZPosition;
                foreach (Touch touch in Input.touches)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (touch.phase == TouchPhase.Moved)
                        {
                            if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                            {

                                movepos = Input.GetTouch(0).position;

                                if (movepos.x > startpos.x)
                                {
                                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                                    Debug.Log("haveflicked");
                                }

                                if (movepos.x < startpos.x)
                                {
                                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                                    Debug.Log("haveflicked");
                                }

                            }
                            else
                            {
                                movepos = Input.GetTouch(0).position;

                                if (movepos.x > startpos.x)
                                {
                                    gameObject.GetComponent<Renderer>().material.color = Color.white;
                                    Debug.Log("cancelflicked");
                                }

                                if (movepos.x < startpos.x)
                                {
                                    gameObject.GetComponent<Renderer>().material.color = Color.white;
                                    Debug.Log("cancellicked");
                                }
                            }

                        }

                    }

                    if (touch.phase == TouchPhase.Ended)
                    {
                        gameObject.GetComponent<Renderer>().material.color = Color.white;
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

        if(falsers)
        {

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
        if(collision.collider.CompareTag("JudgementLine")) {
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
                DirectionalFlick.instance.booler();
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