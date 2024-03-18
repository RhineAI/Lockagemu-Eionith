using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyeksirute : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public Transform controlcurve;

    public bool drawing;
    public int dotnumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public Vector3 evaluasi(float t)
    {
        Vector3 ac = Vector3.Lerp(a.position, controlcurve.position, t);
        Vector3 cb = Vector3.Lerp(controlcurve.position, b.position, t);
        return Vector3.Lerp(ac, cb, t);
    }

    private void OnDrawGizmos()
    {
        if(a == null || b == null || controlcurve == null)
        {
            return;
        }

        for (int i = 0; i < 3; i++)
        {
            if(drawing)
            {
                Gizmos.DrawSphere(evaluasi(i / 3f), 0.1f);
            }
        }
    }
}
