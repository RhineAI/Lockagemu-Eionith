using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beatlineplaytester : MonoBehaviour
{
    public float realtime;
    public float NoteSpeed;
    public GameObject self;
    public bool start;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject;
        NoteSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            realtime += Time.deltaTime * (NoteSpeed * 10);
            transform.position = new Vector3(0, 0, realtime);
        }
        

    }
}
