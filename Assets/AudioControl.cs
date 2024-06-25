using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;
//using UnityEngine.Windows;

public class AudioControl : MonoBehaviour
{
    //public AudioSource theMusic;
    public GameObject music, charter, renote;
    public float realtime;
    bool running;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            Invoke("playing", 3);
            running = true;
            charter.SetActive(true);
        }

        if(running)
        {
            realtime += Time.deltaTime;
            if(realtime > 63)
            {
                renote.SetActive(true);
            }
        }

    }

    public void playing()
    {
        //gameObject.GetComponent<AudioSource>().enabled = true;
        music.SetActive(true);
        
    }

    
}
