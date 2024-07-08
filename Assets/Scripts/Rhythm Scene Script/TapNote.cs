using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapNote : MonoBehaviour
{


    public GameObject self;
    public bool tap;
    // Start is called before the first frame update
    void Start()
    {
        
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

                        if (touch.phase == TouchPhase.Began)
                        {
                            if (hit.transform.gameObject.GetComponent<MeshRenderer>().gameObject == self)
                            {
                                gameObject.GetComponent<Renderer>().material.color = Color.green;
                                Debug.Log("on tap");
                            }

                        }

                        if (touch.phase == TouchPhase.Ended)
                        {
                            if (hit.transform.gameObject.GetComponent<MeshRenderer>().gameObject == self)
                            {
                                gameObject.GetComponent<Renderer>().material.color = Color.white;
                                Debug.Log("tap end");
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
    }
}
