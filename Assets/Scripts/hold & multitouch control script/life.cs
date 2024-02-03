using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    public float time;

    public bool system;

    public GameObject falser;

    public Transform selfpos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(system)
        {
            //Destroy(gameObject, time);
        }
        else
        {
            Destroy(gameObject, time);
        }
        
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if(system)
        {
            if (collision.collider.CompareTag("off area"))
            {
                Destroy(gameObject);
                Debug.Log("off");
            }

            if (collision.collider.CompareTag("touch system"))
            {
                Destroy(gameObject);
                Debug.Log("stilltouch");
            }
            else
            {
                if (collision.collider.CompareTag("hold"))
                {
                    Debug.Log("danger");
                    Instantiate(falser, selfpos.position, selfpos.rotation);
                    Destroy(gameObject);
                }
            }

            //Destroy(gameObject, time);
        }
    }*/
}
