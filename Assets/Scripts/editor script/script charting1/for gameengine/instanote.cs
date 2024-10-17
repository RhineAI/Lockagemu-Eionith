using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanote : MonoBehaviour
{
    public KeyCode presskey;
    public GameObject note;
    public Transform notrans;
    public Transform onparent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(presskey))
        {
            Instantiate(note, notrans.position, notrans.rotation, onparent);
        }
    }
}
