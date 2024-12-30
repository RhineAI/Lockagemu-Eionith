using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class raycaster : MonoBehaviour
{
    public GameObject deact;
    public int ok;
    public int t;
    public static raycaster ry;
    public bool attacker;
    public float bpm;
    public bool can;
    public bool inter;
    // Start is called before the first frame update
    void Start()
    {
      //t = 0;
        ry = this;
        bpm = bpm / 120f;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += new Vector3(0f, 0f, bpm * Time.deltaTime);
        
        /*if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == deact)
                {
                    Debug.Log("deactive area");
                }
            }
        }*/
    }


    private void OnTriggerEnter(Collider other)
    {
        if(attacker)
        {
            if (other.tag == "noteject")
            {
                //an = true;
                /*anjing.jg.tambah();*/
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(attacker)
        {
            if (other.tag == "noteject")
            {
                //n = false;
                //anjing.jg.reset();
            }
        }
        
    }  
    public void tambahin()
    {
        if (inter)
        {
            ok = raycaster.ry.t;
        }
        
    }

    public void kurangin()
    {
        if (inter)
        {
            ok = 0;
        }

    }

}
