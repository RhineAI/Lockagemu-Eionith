using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincommand : MonoBehaviour
{
    public GameObject creattap;
    public GameObject creathold;
    public GameObject selectmode;
    public GameObject parrend;
    public bool tapcreat;
    public bool holdcreat;
    public bool selectmods;
    public bool parentnote;
    public GameObject tapnote;
    public GameObject holdnote;
    public static maincommand command;
    public GameObject deact;
    public GameObject act;
    public Transform parentdata;
    //public bool cancreate;
    //public bool cantcreate;

    // Start is called before the first frame update
    void Start()
    {
        //command = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(parentnote)
        {
            gameObject.GetComponentInChildren<placednote>().enabled = false;
        }
        if(tapcreat)
        {
            parrend.GetComponent<takelive>().enabled = true;
            parrend.GetComponent<givelife>().enabled = false;
            //maincommand.command.parentt();
            //gameObject.GetComponent<placednote>().gameObject.CompareTag("noteject").
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f));
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == deact)
                    {
                        Debug.Log("deactive area");
                    }
                    else if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == act)
                    {
                        Debug.Log("active area");
                        Instantiate(tapnote, mousepos, Quaternion.identity, parentdata);
                    }
                }


            }


        }

        if(holdcreat)
        {
            parrend.GetComponent<takelive>().enabled = true;
            parrend.GetComponent<givelife>().enabled = false;
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f));
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == deact)
                    {
                        Debug.Log("deactive area");
                    }
                    else if (hit.transform.gameObject.GetComponent<BoxCollider>().gameObject == act)
                    {
                        Debug.Log("active area");
                        Instantiate(holdnote, mousepos, Quaternion.identity, parentdata);
                    }
                }
            }
        }

        if(selectmods)
        {
            tapcreat = false;
            holdcreat = false;
            parrend.GetComponent<takelive>().enabled = false;
            parrend.GetComponent<givelife>().enabled = true;
        }

        
    }

    

    public void tapcreator()
    {
        creattap.SetActive(true);
        creathold.SetActive(false);
        selectmode.SetActive(false);
    }

    public void holdcreator()
    {
        creattap.SetActive(false);
        creathold.SetActive(true);
        selectmode.SetActive(false);
    }

    public void selectmod()
    {
        creattap.SetActive(false);
        creathold.SetActive(false);
        selectmode.SetActive(true);
    }

    void Anti_Adashi()
    {
        //
    }

    /*public void parentt()
    {
        if(parentnote)
        {
            gameObject.GetComponentInChildren<placednote>().enabled = false;
        }
    }*/
}
