using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class touch1 : MonoBehaviour
{
    // public LayerMask touchinputmask;

    //private List<GameObject> touchlist = new List<GameObject>();

    //private GameObject[] touchesold;


    public GameObject self;

    public GameObject falser;

    public GameObject create;

    public Transform cr;

    public GameObject starthit;

    public GameObject endhit;
    

    public int c;

    public bool tap;

    public bool hold;

    public bool flick;

    public bool flickrotate;

    public bool already;

    public bool slide;

    public bool hold2;

    public bool creator;

    public bool falsers;

    public bool startfl;

    public bool startassist;

    public bool endassist;

    public bool endfl;

    public bool flickers;

    public bool wrongway;


    public bool collisionen;

    public bool wrongtouch;


    public static touch1 boolian;

    public float bpm;
    public float jumlahholdnote;
    public float duration;
    private float elapsedtime;

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
        bpm = bpm / 4;
        jumlahholdnote = 0;
        elapsedtime += Time.deltaTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tap)
        {
            if (Input.touchCount > 0)
            {
                //touchesold = new GameObject[touchlist.Count];
                //touchlist.CopyTo(touchesold);
                //touchlist.Clear();

                foreach (Touch touch in Input.touches)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        //GameObject recipient = hit.transform.gameObject;
                        //touchlist.Add(recipient);

                        
                        if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                        {
                            if (touch.phase == TouchPhase.Began)
                            {
                                gameObject.GetComponent<Renderer>().material.color = Color.green;
                                Debug.Log("ontouch");
                                gameObject.SetActive(false);
                            }
                            else
                            {
                                //gameObject.GetComponent<Renderer>().material.color = Color.white;
                            }

                            if (touch.phase == TouchPhase.Ended)
                            {
                                gameObject.GetComponent<Renderer>().material.color = Color.white;
                                Debug.Log("untouch");
                                /*if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                                {
                                    gameObject.GetComponent<Renderer>().material.color = Color.white;
                                    Debug.Log("");
                                }*/

                            }

                        }


                        

                        /*GameObject recipient = hit.transform.gameObject;
                        if(touch.phase == TouchPhase.Began)
                        {
                            gameObject.GetComponent<Renderer>().material.color = Color.green;
                        }*/
                    }
                    

                    
                }

            }
        }

        if (hold && Input.touchCount > 0)
        {
            float totaldurasi = elapsedtime / duration;
            foreach (Touch touch in Input.touches)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    //GameObject recipient = hit.transform.gameObject;
                    //touchlist.Add(recipient);

                    if (touch.phase == TouchPhase.Began)
                    {
                        if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                        {
                            gameObject.GetComponent<Renderer>().material.color = Color.green;
                            Debug.Log("ontouch");
                            already = true;

                            


                        }
                        


                        
                    }

                    /*if(c == 0)
                    {
                        gameObject.GetComponent<Renderer>().material.color = Color.white;
                        Debug.Log("rilis");
                    }

                    /*if(touch.phase == TouchPhase.Ended)
                    {
                        wrongtouch = false;
                    }

                    /*if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == falser)
                    {
                        if (touch.phase == TouchPhase.Began)
                        {
                            //gameObject.GetComponent<Renderer>().material.color = Color.green;
                            Debug.Log("falsetouch");
                            //already = true;
                            //wrongtouch = true;
                            


                        }

                        if (touch.phase == TouchPhase.Ended)
                        {
                            //gameObject.GetComponent<Renderer>().material.color = Color.green;
                            Debug.Log("lol");
                            //already = true;
                            //wrongtouch = true;



                        }




                    }

                    /*if(wrongtouch)
                    {
                        

                        if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == falser)
                        {
                            //gameObject.GetComponent<Renderer>().material.color = Color.green;
                            Debug.Log("falsetouch");
                            //already = true;
                            wrongtouch = true;



                        }
                        else
                        {
                            if (touch.phase == TouchPhase.Ended)
                            {
                                Debug.Log("LOL");
                                //gameObject.GetComponent<Renderer>().material.color = Color.white;
                                wrongtouch = false;
                            }
                        }
                        
                    }
                    else
                    {
                        if (touch.phase == TouchPhase.Ended)
                        {
                            //Debug.Log("LOL");
                            gameObject.GetComponent<Renderer>().material.color = Color.white;
                        }
                    }

                    /*if(collisionen)
                    {
                        if (touch.phase == TouchPhase.Ended)
                        {
                            //gameObject.GetComponent<Renderer>().material.color = Color.white;
                            Debug.Log("still");
                        }

                    }
                    else
                    {
                        if (touch.phase == TouchPhase.Ended)
                        {
                            gameObject.GetComponent<Renderer>().material.color = Color.white;
                            Debug.Log("release");
                        }
                    }

                    /*if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                    {
                        //locked = true;
                        if (touch.phase == TouchPhase.Began)
                        {
                            if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                            {
                                gameObject.GetComponent<Renderer>().material.color = Color.green;
                                Debug.Log("ontouch");
                            }
                            else
                            {
                                if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == falser)
                                {
                                    gameObject.GetComponent<Renderer>().material.color = Color.white;
                                    Debug.Log("ontouch");
                                }
                            }
                                //already = true;
                                //locked = true;
                                //unlock = false;
                               


                        }


                    }

                    if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self && falser)
                    {
                        if (touch.phase == TouchPhase.Began)
                        {
                            gameObject.GetComponent<Renderer>().material.color = Color.green;
                            Debug.Log("gerbangNN1");
                        }



                    }

                    if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == falser)
                    {
                        if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                        {
                            if (touch.phase == TouchPhase.Began)
                            {
                                gameObject.GetComponent<Renderer>().material.color = Color.green;
                                Debug.Log("gerbangNN1");
                            }
                        }



                    }

                    if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == falser)
                    {
                        gameObject.GetComponent<Renderer>().material.color = Color.white;
                        Debug.Log("ontouch");


                    }

                    if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                    {
                        //locked = true;
                        if (touch.phase == TouchPhase.Began)
                        {
                            already = true;
                            locked = true;
                            unlock = false;
                            gameObject.GetComponent<Renderer>().material.color = Color.green;
                            Debug.Log("ontouch");





                        }


                    }
                    if (already)
                    {
                        if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                        {
                            locked = true;
                            unlock = false;
                        }

                        if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == falser)
                        {

                            if(agree)
                            {
                                dissagree = false;
                                locked = false;
                                unlock = true;
                            }
                            
                            if(dissagree)
                            {
                                agree = false;
                                locked = true;
                                unlock = false;
                            }
                            if(case1)
                            {
                                if (touch.phase == TouchPhase.Moved)
                                {
                                    //already = true;
                                    //locked = false;
                                    //unlock = true;
                                    agree = true;
                                    Debug.Log("movedect");
                                    //gameObject.GetComponent<Renderer>().material.color = Color.green;
                                    //Debug.Log("ontouch");


                                }
                            }
                            

                            if(case2)
                            {
                                if (touch.phase == TouchPhase.Stationary)
                                {
                                    case1 = false;
                                    Debug.Log("detected");
                                    //already = true;
                                    //locked = true;
                                    //unlock = false;
                                    dissagree = true;
                                    //gameObject.GetComponent<Renderer>().material.color = Color.green;
                                    //Debug.Log("ontouch");



                                }
                            }
                            


                            if (touch.phase == TouchPhase.Began)
                            {
                                already = true;
                                locked = false;
                                unlock = true;
                                gameObject.GetComponent<Renderer>().material.color = Color.green;
                                Debug.Log("ontouch");


                            }
                        }
                            
                    }

                    


                   

                    

                    /*if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                    {
                        if (touch.phase == TouchPhase.Began)
                        {
                            gameObject.GetComponent<Renderer>().material.color = Color.green;
                            Debug.Log("ontouch");
                        }
                        else
                        {
                            //gameObject.GetComponent<Renderer>().material.color = Color.white;
                        }

                        if (touch.phase == TouchPhase.Ended)
                        {
                            gameObject.GetComponent<Renderer>().material.color = Color.white;
                            Debug.Log("untouch");
                            /*if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                            {
                                gameObject.GetComponent<Renderer>().material.color = Color.white;
                                Debug.Log("");
                            }*/

                    /*}

                }
                else
                {
                    if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == falser)
                    {
                        gameObject.GetComponent<Renderer>().material.color = Color.white;
                    }

                    if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                    {
                        gameObject.GetComponent<Renderer>().material.color = Color.green;
                    }

                }*/






                    /*GameObject recipient = hit.transform.gameObject;
                    if(touch.phase == TouchPhase.Began)
                    {
                        gameObject.GetComponent<Renderer>().material.color = Color.green;
                    }*/
                }



            }
        }

        if (flick)
        {
            if (Input.touchCount > 0)
            {
                //touchesold = new GameObject[touchlist.Count];
                //touchlist.CopyTo(touchesold);
                //touchlist.Clear();

                foreach (Touch touch in Input.touches)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        //GameObject recipient = hit.transform.gameObject;
                        //touchlist.Add(recipient);

                        /*if (touch.phase == TouchPhase.Began)
                        {
                            if (hit.transform.gameObject.GetComponent<MeshRenderer>().gameObject == self)
                            {
                                startpos = Input.GetTouch(0).position;

                                
                                
                                Debug.Log("");

                                
                            }
                            
                            

                        }*/

                        if (touch.phase == TouchPhase.Moved)
                        {
                            if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                            {

                                movepos = Input.GetTouch(0).position;

                                if (movepos.y > startpos.y)
                                {
                                    //gameObject.GetComponent<Renderer>().material.color = Color.green;
                                    //Debug.Log("haveflicked");
                                }

                                if (movepos.y < startpos.y)
                                {
                                    //gameObject.GetComponent<Renderer>().material.color = Color.green;
                                    //Debug.Log("haveflicked");
                                }

                            }
                           
                        }



                        /*GameObject recipient = hit.transform.gameObject;
                        if(touch.phase == TouchPhase.Began)
                        {
                            gameObject.GetComponent<Renderer>().material.color = Color.green;
                        }*/
                    }

                    if (touch.phase == TouchPhase.Ended)
                    {
                        gameObject.GetComponent<Renderer>().material.color = Color.white;
                        /*if (hit.transform.gameObject.GetComponent<MeshRenderer>().gameObject == self)
                        {

                            Debug.Log("");
                        }*/

                    }
                }

            }
        }

        
        if(flickers)
        {
            //int f;

            if (flickrotate)
            {

                //int f;

                if (Input.touchCount > 0)
                {
                    //touchesold = new GameObject[touchlist.Count];
                    //touchlist.CopyTo(touchesold);
                    //touchlist.Clear();

                    foreach (Touch touch in Input.touches)
                    {
                        Ray ray = Camera.main.ScreenPointToRay(touch.position);
                        RaycastHit hit;

                        if (Physics.Raycast(ray, out hit))
                        {
                            if (startfl)
                            {
                                if (touch.phase == TouchPhase.Ended)
                                {

                                }
                                if (touch.phase == TouchPhase.Began)
                                {
                                    if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                                    {
                                        self.GetComponent<BoxCollider>().enabled = false;
                                        gameObject.GetComponent<BoxCollider>().enabled = false;
                                        startfl = false;
                                        Debug.Log("lol");
                                    }
                                }
                            }
                            //GameObject recipient = hit.transform.gameObject;
                            //touchlist.Add(recipient);

                            /*if (touch.phase == TouchPhase.Began)
                            {
                                if (hit.transform.gameObject.GetComponent<MeshRenderer>().gameObject == self)
                                {
                                    startpos = Input.GetTouch(0).position;



                                    Debug.Log("");


                                }



                            }

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

                            }*/



                            /*GameObject recipient = hit.transform.gameObject;
                            if(touch.phase == TouchPhase.Began)
                            {
                                gameObject.GetComponent<Renderer>().material.color = Color.green;
                            }
                        }

                        if (touch.phase == TouchPhase.Ended)
                        {
                            gameObject.GetComponent<Renderer>().material.color = Color.white;
                            /*if (hit.transform.gameObject.GetComponent<MeshRenderer>().gameObject == self)
                            {

                                Debug.Log("");
                            }*/

                        }
                    }

                }
            }
        }
        

        if(slide)
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
                            gameObject.GetComponent<Renderer>().material.color = Color.green;
                        }
                    }
                    else
                    {
                        gameObject.GetComponent<Renderer>().material.color = Color.white;
                    }
                    if(touch.phase == TouchPhase.Ended)
                    {
                        gameObject.GetComponent<Renderer>().material.color = Color.white;
                    }
                }
            }
        }

        if(hold2)
        {
            if (hold2 && Input.touchCount > 0)
            {
                foreach (Touch touch in Input.touches)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);

                    RaycastHit[] hits = Physics.RaycastAll(ray);
                    foreach (RaycastHit hit in hits)
                    {
                        // Debug.Log(hit.collider == self.GetComponent<BoxCollider>());
                        float hitPointY = hit.transform.position.y;
                        float hitPointX = hit.transform.position.x;
                        float yCoordinate = self.transform.position.y;
                        float xCoordinate = self.transform.position.x;
                        if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                        {
                            // Debug.Log($"Y : {yCoordinate}, HitDistance = {hitPoint}");
                            if (already)
                            {
                                if (touch.phase == TouchPhase.Ended)
                                {
                                    Debug.Log("untouch");
                                    self.GetComponent<Renderer>().material.color = Color.white;
                                    already = false;
                                }
                                if (hitPointY > yCoordinate && hitPointX > xCoordinate)
                                {
                                    Debug.Log("Far away");
                                    self.GetComponent<Renderer>().material.color = Color.white;
                                    already = false;
                                }
                            }
                            else
                            {
                                if (touch.phase == TouchPhase.Began)
                                {
                                    Debug.Log("touching");
                                    self.GetComponent<Renderer>().material.color = Color.green;
                                    already = true;
                                }
                            }
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

        if(falsers)
        {

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //collisionen = true;
        //int c = 0;
        
        if (hold)
        {
            if (already)
            {
                if (collision.collider.CompareTag("touch system"))
                {
                    float totaldurasi = elapsedtime / duration;
                    //wrongtouch = true;
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    c += 1;
                    Debug.Log("collision ok");
                    jumlahholdnote += bpm * totaldurasi;
                    

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

        if (flickers)
        {
            if (startassist)
            {
                //int f;
                if (collision.collider.CompareTag("touch system"))
                {
                 
                    self.GetComponent<BoxCollider>().enabled = true;
                    Debug.Log("startfl");
                }
            }

            if (flickrotate)
            {
                //int f;
                if (collision.collider.CompareTag("touch system"))
                {
                    //f += 1;
                    //c += 1;
                    startfl = true;
                    Debug.Log("continue");
                    self.GetComponent<BoxCollider>().enabled = true;

                }

                



                
            }
            if (wrongway)
            {
                if (collision.collider.CompareTag("touch system"))
                {
                    //startfl = true;
                    Debug.Log("nah bro");
                    falser.GetComponent<BoxCollider>().enabled = false;
                    self.GetComponent<BoxCollider>().enabled = false;
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    endfl = false;

                }
            }
        }

        

        



    }

    private void OnCollisionExit(Collision collision)
    {
        //collisionen = false;
        if (hold)
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

        if(flick)
        {
            if(collision.collider.CompareTag("touch system"))
            {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                Debug.Log("flicked");
            }
        }

        if(flickers)
        {
            if (flickrotate)
            {
                if (collision.collider.CompareTag("touch system"))
                {
                    falser.GetComponent<BoxCollider>().enabled = true;
                    Debug.Log("dont go up");
                    //self.GetComponent<BoxCollider>().enabled = true;

                }
            }



            if (endassist)
            {
                if (collision.collider.CompareTag("touch system"))
                {
                    //gameObject.GetComponent<Renderer>().material.color = Color.green;
                    Debug.Log("flicked");
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
                touch.boolian.booler();
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
