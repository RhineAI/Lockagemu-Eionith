using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timelinecharter : MonoBehaviour
{
    public float timing;
    public float tr1, tr2, tr3, tr4, tr5;
    public bool start;
    // Start is called before the first frame update
    void Start()
    {
        timing = 0;
        tr1 = Random.Range(1, 100);
        tr2 = Random.Range(200, 500);
        tr3 = Random.Range(500, 1000);
        tr4 = Random.Range(1000, 2000);
        start = false;
        //tr5 = Random.Range(200, 500);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            start = true;
            //timing += 1;
        }

        if(start)
        {
            timing += 1;
        }
        

        if( timing == tr1)
        {
            Debug.Log(timing);
        }

        if (timing == tr2)
        {
            Debug.Log(timing);
        }

        if (timing == tr3)
        {
            Debug.Log(timing);
        }

        if (timing == tr4)
        {
            Debug.Log(timing);
            start = false;
        }

        //if (timing == 1150)
        //{
        //    Debug.Log(timing);
        //}

        
    }
}
