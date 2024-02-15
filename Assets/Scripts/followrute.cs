using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followrute : MonoBehaviour
{
    public proyeksirute rute;
    public float speed;

    private float samplewaktu;

    public bool hold;
    public float nomor;
    public static followrute fr;
    public bool awal;
    // Start is called before the first frame update
    void Start()
    {
        samplewaktu = 0f;
        //nomor = nomor / 10;
        //Invoke("Update", nomor);
        //awal = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        samplewaktu += Time.deltaTime * speed;
        transform.position = rute.evaluasi(/*dengan*/samplewaktu);
        transform.forward = rute.evaluasi(samplewaktu + /*per koordinat*/0.001f) - transform.position;

        if (samplewaktu >= 1f)
        {
            samplewaktu = Time.deltaTime;
        }





    }

    void jalan()
    {
        //gameObject.GetComponent<followrute>().enabled;


    }

}
