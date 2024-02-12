using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hold : MonoBehaviour
{
    // public LayerMask touchinputmask;
    //private List<GameObject> touchlist = new List<GameObject>();
    //private GameObject[] touchesold;

    public GameObject self;
    public GameObject falser;
    public GameObject create;

    // private MeshRenderer meshRenderer;
    private Material[] meshMaterials;
    public Material beforeTap;
    public Material afterTap;

    private bool hold;
    public bool critical = false;
    public bool fair = false;
    public bool error = false;

    public int c;
    public bool already;
    public bool creator;
    private bool canBePressed = false;

    public bool wrongtouch;
    public static Hold boolian;

    // Start is called before the first frame update
    void Start()
    {
        boolian = this;
        meshMaterials = gameObject.GetComponent<MeshRenderer>().materials;
    }

    // Update is called once per frame
    void Update()
    { 
        Vector3 scale = self.transform.localScale;
        float endHold = scale.z;
        bool alreadyCritical = false;
        if (hold)
        {
            if(canBePressed && Input.touchCount > 0) {
                foreach (Touch touch in Input.touches)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (touch.phase == TouchPhase.Began)
                        {
                            // if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                            // {
                                meshMaterials[1] = afterTap;

                                gameObject.GetComponent<MeshRenderer>().materials = meshMaterials;

                                Debug.Log("hold touch");
                                already = true;
                                critical = true;
                            // }   
                        }

                    }
                }

                if(critical && !alreadyCritical) 
                {
                    float bpm = BeatRun.instance.beatTempo;
                    // while (self.transform.position.z <= endHold) {
                        // while (bpm <= bpm * 4) {
                            ScoreDisplay.instance.criticalTap += 1;
                            ScoreDisplay.instance.DisplayedScore(critical, fair, error);
                            
                        // }
                    // }
                    alreadyCritical = true;
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
        
        if(collision.collider.CompareTag("JudgementLineCenter")) {
            hold = true;
            canBePressed = true;
        }

        if (hold)
        {
            if (already)
            {
                if (collision.collider.CompareTag("touch system"))
                {
                    meshMaterials[1] = afterTap;
                    gameObject.GetComponent<MeshRenderer>().materials = meshMaterials;

                    // gameObject.GetComponent<Renderer>().material.color = Color.green;
                    c += 1;
                    Debug.Log("collision ok");
                }
            }
            else
            {
                if (collision.collider.CompareTag("touch system"))
                {
                    meshMaterials[1] = beforeTap;
                    gameObject.GetComponent<MeshRenderer>().materials = meshMaterials;

                    // gameObject.GetComponent<Renderer>().material.color = Color.white;
                    Debug.Log("can't");
                }
            }

            if (collision.collider.CompareTag("falser"))
            {
                if(c > 0)
                {
                    c -= 1;
                    meshMaterials[1] = afterTap;
                    gameObject.GetComponent<MeshRenderer>().materials = meshMaterials;
                    Debug.Log("still");
                }
                if (c < 1)
                {
                    meshMaterials[1] = beforeTap;
                    gameObject.GetComponent<MeshRenderer>().materials = meshMaterials;
                    Debug.Log("hold release");
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        bool alreadyError = false;
        if(collision.collider.CompareTag("JudgementLineCenter")) {
            hold = false;
            canBePressed = false;
            error = true;
            if(error && !alreadyError) {
                ScoreDisplay.instance.errorTap += 1;
                ScoreDisplay.instance.DisplayedScore(critical, fair, error);
                alreadyError = true;
            }

        }
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
                        meshMaterials[1] = beforeTap;
                        gameObject.GetComponent<MeshRenderer>().materials = meshMaterials;
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
                Hold.boolian.booler();
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
