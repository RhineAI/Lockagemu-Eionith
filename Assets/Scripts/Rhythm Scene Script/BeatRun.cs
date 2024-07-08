using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatRun : MonoBehaviour
{
    public float beatTempo; 
    public bool hasStarted;
    public static BeatRun instance;
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        beatTempo = beatTempo / 60f / 100f;
        if(speed >= 1f && speed <= 6f) {
            speed = speed + beatTempo;
        } else {
            speed = 6f + beatTempo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(speed);
        if(!hasStarted) {
            // if(Input.anyKeyDown) {
            //     hasStarted = true;
            // }
        } else {
            transform.position -= new Vector3(0f, 0f, speed * Time.deltaTime);
        }
    }
}
