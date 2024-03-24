using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changetarget : MonoBehaviour
{
    public GameObject[] target;
    public GameObject currenttarget;
    public GameObject parenttarget;
    public 
        int listtarget;
    //public float receiver_impact;
    //public float receiver_duration;
    public 
        bool aktive;
    public static changetarget targetchanger;
    // Start is called before the first frame update
    void Start()
    {
        //target.Length = parenttarget.childCount;
        flickchildrenarray(parenttarget);
        Invoke("analystic", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(aktive)
        {
            //Debug.Log("analisis");
            currenttarget = target[listtarget];
            //receiver = currenttarget.GetComponent<expsimplecoroutine>().ex2;
            if (listtarget > target.Length)
            {
                listtarget = 0;
            }
            else
            {
                
            }
        }
        //receiver = currenttarget.GetComponent<expsimplecoroutine>().ex2;
        
        //currenttarget = target[listtarget];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == currenttarget)
        {
            if(gameObject.GetComponent<lanescriptupdatev1>().is_rotating == true)
            {
                gameObject.GetComponent<lanescriptupdatev1>().targetspeed = gameObject.GetComponent<lanescriptupdatev1>().targetspeed
                    +currenttarget.GetComponent<sideflicknote>().speed_rotation_impact;
                gameObject.GetComponent<lanescriptupdatev1>().rotationTime = gameObject.GetComponent<lanescriptupdatev1>().rotationTime
                    + currenttarget.GetComponent<sideflicknote>().duration_impact;
                gameObject.GetComponent<lanescriptupdatev1>().timelapsed = 0;

            }
            if(gameObject.GetComponent<lanescriptupdatev1>().optimizing == true)
            {
                gameObject.GetComponent<lanescriptupdatev1>().finishmore = false;
                gameObject.GetComponent<lanescriptupdatev1>().finishless = false;
                gameObject.GetComponent<lanescriptupdatev1>().lessrota = false;
                gameObject.GetComponent<lanescriptupdatev1>().morerota = false;
                gameObject.GetComponent<lanescriptupdatev1>().more = false;
                gameObject.GetComponent<lanescriptupdatev1>().less = false;
                //xplus = false; xplus180optmin = false; xplus180optplus = false; xminus = false; xminus180optmin = false; xminus180optplus = false;
                gameObject.GetComponent<lanescriptupdatev1>().timelapsed = 0;
                gameObject.GetComponent<lanescriptupdatev1>().timelapsestop = 0;
                gameObject.GetComponent<lanescriptupdatev1>().optimizing = false;
                gameObject.GetComponent<lanescriptupdatev1>().checking = true;
                gameObject.GetComponent<lanescriptupdatev1>().step = 0;
                gameObject.GetComponent<lanescriptupdatev1>().targetspeed = currenttarget.GetComponent<sideflicknote>().speed_rotation_impact;
                gameObject.GetComponent<lanescriptupdatev1>().rotationTime = currenttarget.GetComponent<sideflicknote>().duration_impact;
            }
            else
            {
                gameObject.GetComponent<lanescriptupdatev1>().targetspeed = currenttarget.GetComponent<sideflicknote>().speed_rotation_impact;
                gameObject.GetComponent<lanescriptupdatev1>().rotationTime = currenttarget.GetComponent<sideflicknote>().duration_impact;
            }
            //Debug.Log("ok");
            
            if (listtarget >= target.Length - 1)
            {
                //Debug.Log("wis pak");
                listtarget = 0;
            }
            else
            {
                listtarget++;
            }
            
        }
    }

    void analystic()
    {
        aktive = true;
    }

    void flickchildrenarray(GameObject parent)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        target = new GameObject[children.Length - 1];
        int index = 0;        
        foreach (Transform child in children)
        {
            if (child.gameObject != parent) 
            {
                target[index] = child.gameObject;
                index++;
            }
        }
        //currenttarget = target[listtarget];
    }
}
