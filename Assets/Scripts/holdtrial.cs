using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdtrial : MonoBehaviour
{
    public float waktu;
    public int pure;
    public int lost;
    public float puretimer;
    public float bpm;
    public float realtime = 60;

    public bool run;
    public bool holding;
    public bool release;
    public float nomor;
    //public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        pure = 0;
        nomor = nomor / 10;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("move", nomor);
        waktu = realtime / bpm;
        if (run)
        {
            puretimer += Time.deltaTime;
            if(puretimer >= waktu)
            {
                puretimer -= waktu;
                if(holding)
                {
                    //release = false;
                    pure++;
                    
                }
                else
                {
                    //holding = false;
                    lost++;
                }
                //pure++;
            }
        }
    }

    void move()
    {
        gameObject.GetComponent<followrute>().enabled = true;
    }

    
}
