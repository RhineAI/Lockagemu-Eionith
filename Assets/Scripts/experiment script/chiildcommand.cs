using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chiildcommand : MonoBehaviour
{
    GameObject parent;
    float bpm = 5;
    // Start is called before the first frame update
    void Start()
    {
        // Panggil metode yang memberi perintah kepada semua child GameObject
        //CommandChildren();
        //bpm = bpm / 60f;
    }

    void Update()
    {
        // Dapatkan jumlah child GameObject dari parent
        int childCount = transform.childCount;

        // Untuk setiap child GameObject, berikan perintah ke mereka
        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i); // Dapatkan child secara langsung
            child.transform.position += new Vector3(0, 0, bpm);
            // Lakukan sesuatu kepada child GameObject di sini
            //Debug.Log("Mengerjakan sesuatu kepada " + child.name);
        }

    }
    
}
