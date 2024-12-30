using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longholdedit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.localScale += new Vector3(0f, 0f, 1f);
            transform.position += new Vector3(0f, 0f, 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localScale -= new Vector3(0f, 0f, 1f);
            transform.position -= new Vector3(0f, 0f, 0.5f);
        }
    }
}
