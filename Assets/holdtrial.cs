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
    public int fixpure;
    public int fixingpure;
    

    public bool run;
    public bool holding;
    public bool release;
    public float nomor;
    public static holdtrial hd;
    //public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        fixingpure = fixpure;
        pure = 0;
        nomor = nomor / 10;
        release = true;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("move", nomor);
        waktu = realtime / bpm;
        if (Input.GetKey(KeyCode.D))
        {
            holding = true;
            
            
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            holding = false;
        }

        if(run)
        {
            puretimer += Time.deltaTime;
            if (puretimer >= waktu)
            {
                puretimer -= waktu;
                if (holding)
                {
                    //release = false;
                    release = false;
                    pure++;
                    fixpure--;

                }
                else if(release)
                {
                    holding = false;
                    //holding = false;
                    lost++;
                    fixpure--;
                }
                //pure++;
            }

            if(pure == fixingpure)
            {
                holding = false;
            }else if(lost == fixingpure)
            {
                release = false;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("exitroute"))
        {
            run = true;
        }

        if (collision.collider.CompareTag("Finish"))
        {
            run = false;
            if(holding)
            { if(pure < fixingpure)
                {
                    pure += fixpure;
                }
                
                
            }
            else if(release)
            {
                if(lost < fixingpure)
                {
                    lost += fixpure;
                }
                
            }
        }
    }

    void move()
    {
        gameObject.GetComponent<followrute>().enabled = true;
    }

    public void runpro()
    {
        run = true;
    }


}
