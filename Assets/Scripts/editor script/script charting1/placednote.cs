using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class placednote : MonoBehaviour
{
    public bool selected;

    public bool tap;

    public bool hold;

    public bool position;

    public bool longs;

    public GameObject self;

    //public static placednote placing;

    public GameObject holdopt;

    // Start is called before the first frame update
    void Start()
    {
        //placing = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                {
                    
                    selected = true;
                    
                    
                }
                else
                {
                    selected = false;
                }
            }
        }
        if (selected)
        {
            if(tap)
            {
                holdopt.SetActive(false);

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    transform.position += new Vector3(0f, 0f, 1f);
                }

                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    transform.position -= new Vector3(0f, 0f, 1f);
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.position -= new Vector3(5f, 0f, 0f);
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    transform.position += new Vector3(5f, 0f, 0f);
                }
            }

            if(hold)
            {
                holdopt.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == self)
                        {

                            selected = true;


                        }
                        
                    }
                }
                if (position)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        transform.position += new Vector3(0f, 0f, 1f);
                    }

                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        transform.position -= new Vector3(0f, 0f, 1f);
                    }

                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        transform.position -= new Vector3(5f, 0f, 0f);
                    }

                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        transform.position += new Vector3(5f, 0f, 0f);
                    }
                }
                

                if(longs)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        transform.localScale += new Vector3(0f, 0f, 1f);
                        transform.position += new Vector3(0f, 0f, 0.5f);
                    }

                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        transform.localScale -= new Vector3(0f, 0f, 1f);
                        transform.position -= new Vector3(0f, 0f, 0.5f);
                    }
                }
            }
            
        }
    }

    public void longedit()
    {
        gameObject.GetComponent<postholdedit>().enabled = false;
        gameObject.GetComponent<longholdedit>().enabled = true;
    }

    public void postedit()
    {
        gameObject.GetComponent<postholdedit>().enabled = true;
        gameObject.GetComponent<longholdedit>().enabled = false;
    }
}
