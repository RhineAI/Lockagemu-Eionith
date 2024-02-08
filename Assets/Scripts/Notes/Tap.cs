using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tap : MonoBehaviour
{
    // public LayerMask touchinputmask;
    //private List<GameObject> touchlist = new List<GameObject>();
    //private GameObject[] touchesold;

    public GameObject self;
    public GameObject falser;
    public GameObject create;

    public int c;

    private bool tap = false;
    public bool already;
    public bool creator;
    public bool falsers;
    public bool canBePressed = false;

    public GameObject judgementLine;

    public bool wrongtouch;
    public static Tap boolian;
   
    // Start is called before the first frame update
    void Start()
    {

        boolian = this;
    }

    // Update is called once per frame
    void Update()
    { 
        if(tap)
        {
            if (canBePressed && Input.touchCount > 0)
            {
                foreach (Touch touch in Input.touches)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        float hitPosition = Mathf.Abs(judgementLine.transform.position.z - hit.point.z);
                        // Debug.Log($"JudgementLine : {judgementLine.transform.position.z}, HitPoint : {hit.point.z}");
                        // Debug.Log($"HitPosition : {hitPosition/2}");
                        if (touch.phase == TouchPhase.Began)
                        {
                            Debug.Log("tap");
                            if (hitPosition/2 <= 0.2)
                            {
                                ScoreDisplay.instance.criticalTap += 1;
                                Debug.Log("Critical");
                            }
                            else if (hitPosition/2 <= 0.4)
                            {
                                ScoreDisplay.instance.fairTap += 1;
                                Debug.Log("Fair");
                            } 
                            else {
                                ScoreDisplay.instance.errorTap += 1;
                                Debug.Log("Error");
                            }
                            ScoreDisplay.instance.DisplayedScore();
                        }

                        if (touch.phase == TouchPhase.Ended)
                        {
                            gameObject.SetActive(false);
                            Debug.Log("tap-release");
                        }
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
        //collisionen = true;
        //int c = 0;
        
        if(collision.collider.CompareTag("JudgementLine")) {
            tap = true;
            canBePressed = true;
        }
        if (tap)
        {
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
        if(collision.collider.CompareTag("JudgementLine")) {
            tap = false;
            canBePressed = false;
        }
        if (tap)
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
                Tap.boolian.booler();
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
