 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charter : MonoBehaviour
{
    public float bpm;

    public bool movecontrol;
    public bool spawnernote;

    public GameObject note;
    public Transform notetransform;
    public Transform onparent;

    public KeyCode inputkey;
    // Start is called before the first frame update
    void Start()
    {
        bpm = bpm / 60;
        notetransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log("spawn");
        if (movecontrol)
        {  
            transform.position -= new Vector3(0, 0, bpm * Time.deltaTime);
        }

        if (spawnernote)
        {
            if(Input.GetKeyDown(inputkey))
            {
                
                Instantiate(note, notetransform.position, notetransform.rotation, onparent);
            }
        }
        
    }
}
