using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenecontrol : MonoBehaviour
{
    public float waktu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("how");
        //waktu += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("how");
            //Time.timeScale = 1;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
