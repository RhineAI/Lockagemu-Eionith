using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Flick : MonoBehaviour
{
    public GameObject self;
    public GameObject falser;
    public GameObject create;

    public int c;

    public bool flick;
    public bool creator;
    public bool already;
    public bool canBePressed = false;
    public bool wrongtouch;
    public static Flick boolian;
   

    Vector2 startpos;
    Vector2 movepos;
    Vector2 targetup = new Vector2(0f, 100f);
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.localPosition = new Vector3();
        //case1 = true;
        //case2 = true;
        boolian = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (flick)
        {
            if (Input.touchCount > 0)
            {
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

                                if (movepos.y > startpos.y)
                                {
                                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                                    Debug.Log("haveflicked");
                                }

                                if (movepos.y < startpos.y)
                                {
                                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                                    Debug.Log("haveflicked");
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (flick)
        {
            // Debug.Log("B");
            if(collision.collider.CompareTag("JudgementLine")) {
            // Debug.Log("true");
                canBePressed = true;
            }
            if (already)
            {
                if (collision.collider.CompareTag("touch system"))
                {
                    //wrongtouch = true;
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    c += 1;
                    Debug.Log("collision ok");
                }

            }
            else
            {
                if (collision.collider.CompareTag("touch system"))
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.white;
                    Debug.Log("can't");
                }
            }

            if (collision.collider.CompareTag("falser"))
            {
                if(c > 0)
                {
                    c -= 1;
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    Debug.Log("still");

                }
                if (c < 1)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.white;
                    Debug.Log("release");
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //collisionen = false;
        if (flick)
        {
            if (already)
            {
                if (collision.collider.CompareTag("touch system"))
                {
                    if (c > 1 || c == 1)
                    {

                        c -= 1;

                    }
                    
                    if (c == 0)
                    {
                        gameObject.GetComponent<Renderer>().material.color = Color.white;
                        Debug.Log("release");
                    }
                }

            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(falser)
        {
            if (other.tag == "touch system")
            {
                Debug.Log("hi");
                Flick.boolian.booler();
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
