using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expsimplecoroutine : MonoBehaviour
{
    public float ex;
    IEnumerator mykorotin;
    public bool start;
    public bool stop;
    public float ex2;

    //exp vctr x rotate
    Vector3 posisisblmnya;
    // Start is called before the first frame update
    void Start()
    {
        mykorotin = controller();
        posisisblmnya = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 perubahan = transform.position - posisisblmnya;
        float sudutrotasi = Mathf.Atan2(perubahan.x, perubahan.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, sudutrotasi);

        if(start)
        {
            start = true;
            stop = false;
            StartCoroutine(mykorotin);
        }

        if(stop)
        {
            stop = true;
            start = false;
            StopCoroutine(mykorotin);
            StartCoroutine(controller2());
        }
    }

    IEnumerator simplex()
    {
        while(ex2 > 30)
        {
            ex += Time.deltaTime;
            yield return null;
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
    }


}
