using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expsimplecoroutine : MonoBehaviour
{
    //public float 
    //IEnumerator mykorotin;

    //public bool start;
    //public bool stop;
    public float Note_speed;
    public static expsimplecoroutine exs;

    public float penambahan;
    public float bpm;
    public float percentage;
    public static expsimplecoroutine exp;
    //exp vctr x rotate
    Vector3 posisisblmnya;
    // Start is called before the first frame update
    void Start()
    {
       //mykorotin = controller();
        posisisblmnya = transform.position;
        //percentage = 20;
    }

    // Update is called once per frame
    void Update()
    {
        /*penambahan = (bpm / 10);

        percentage = (20 + penambahan);

        if (start)
        {
            start = true;
            stop = false;
            //StartCoroutine(mykorotin);
            //StartCoroutine(simplex());

        }

        if(stop)
        {
            stop = true;
            start = false;
            //StopCoroutine(mykorotin);
            //StartCoroutine(controller2());
        }

        /*if (sebuah kondisi) {
            perintah;
            perintah;
        perintah; }*/
    }

    /*IEnumerator simplex()
    {
        while(ex < 10)
        {
            ex += Time.deltaTime;
            yield return new WaitForSeconds(2f);
            Debug.Log("Coroutine selesai.");
        }
    }

    IEnumerator controller()
    {
        StartCoroutine(simplex());
        yield return null;
    }

    IEnumerator controller2()
    {
        StopCoroutine(simplex());
        yield return null;
    }*/


}
