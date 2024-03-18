using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.hea

public class movetoward : MonoBehaviour
{
    public Transform target_toward;
    public Transform target_gravity;
    public float speed;
    public float gravity;
    public bool jalan;
    public bool target_1;
    public bool target_2;
    public float axiz;
    public float gravityfrom;
    public float togravity;
    public float speedfrom;
    public float tospeed;
    public float factorial;
    public float timelapse; 
    public bool ayo;
    public float bpm;

    

    [SerializeField]
    private AnimationCurve speedcurve;
    
    [SerializeField]
    private AnimationCurve gravitycurve;

    
    //bool target_1;
    //bool target_2;
    // Start is called before the first frame update
    void Start()
    {
        //target_1 = true;
        timelapse = 0f;
        //speed = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotaz = transform.position.z;
        transform.Rotate(0, 0, rotaz);
        //speed = bpm;
        //gravity = bpm;
        //speedfrom = bpm;
        gravityfrom = bpm;
        tospeed = bpm;
        axiz = gameObject.transform.position.z;
        if(Input.GetKey(KeyCode.S))
        {
            jalan = true;
            
        }
        if(jalan)
        {
            //ayo = true;
            transform.position = Vector3.MoveTowards(transform.position, target_toward.position, speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, target_gravity.position, gravity * Time.deltaTime);
            /*if(target_1)
            {
                //Debug.Log("mulaibool");
                transform.position = Vector3.MoveTowards(transform.position, target1.position, speed * Time.deltaTime);
            }

            if (target_2)
            {
                
                //Debug.Log("mulaibool");
                transform.position = Vector3.MoveTowards(transform.position, target2.position, speed * Time.deltaTime);
            }*/


        }

        if(ayo)
        {
            StartCoroutine(gravitychange());
            timelapse += Time.deltaTime;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("target1"))
        {
            Debug.Log("boom");
            ayo = true;
        }

    }

    private IEnumerator gravitychange()
    {
        //loat timelapse;
        while(timelapse > 0f)
        {
            speed = Mathf.Lerp(speedfrom, tospeed, timelapse / (factorial));
            gravity = Mathf.Lerp(gravityfrom, togravity, timelapse / (factorial));
            yield return null;
        }
    }
}
