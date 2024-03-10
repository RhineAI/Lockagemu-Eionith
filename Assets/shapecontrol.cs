using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class shapecontrol : MonoBehaviour
{
    public GameObject splineobject;
    public float knotindex = 0;

    public SplineContainer komponen;

    //public Spline splinecomp;

    // Start is called before the first frame update
    void Start()
    {
        komponen = splineobject.GetComponent<SplineContainer>();
        //splinecomp = splineobject.GetComponent<Spline>();

        if(komponen == null)
        {
            Debug.LogError("not found");
            return;
        }

       //Vector3 knotpos = getkno

        //manipulate();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var firsknot = komponen.Spline.ToArray()[0];
            firsknot.Position = new Vector3(0, 0, 0);
            //Vector3 knotpos = getkno
            komponen.Spline.SetKnot(1, firsknot);
        }
        
    }




    /*void manipulate()
    {
        //int controlpoint = komponen.transform.childCount;

        if (knotindex < 0 || knotindex >= komponen.control  GetComponent<SplineContainer>(knotinde))
        {
            Debug.LogError("invalid count");
            return;
        }

        //Vector3 conpos = komponen.
    }*/
}