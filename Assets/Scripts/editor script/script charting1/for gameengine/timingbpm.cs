using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timingbpm : MonoBehaviour
{
    public float realtiming;
    public float bpm;
    public bool isrunning;
    public static timingbpm timebpm;
    // Start is called before the first frame update
    void Start()
    {
        bpm = bpm / 10;
        timebpm = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.P))
        {
            isrunning = true;
            
        }

        if(isrunning)
        {
            realtiming += Time.deltaTime;
            transform.position += new Vector3(0, 0, bpm * Time.deltaTime);
        }
    }
}
