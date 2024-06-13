using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class startstopcontrol : MonoBehaviour
{
    public GameObject fx, self;

    public bool vxa, vxb, system;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vxa)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                self.GetComponent<VideoPlayer>().Play();
            }

            
        }

        if (vxb)
        {
            

            if (Input.GetKeyDown(KeyCode.R))
            {
                self.GetComponent<VideoPlayer>().Play();
            }
        }

        if(system)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
    }
}
