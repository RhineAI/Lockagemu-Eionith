using System.Collections.Generic;
using UnityEngine;

public class JudgementSCR : MonoBehaviour
{
    //OBJ
    //public GameObject Lane_Type; //masukkan collider untuk dideteksi ray apakah Lane 1,2,3,4?
    //public GameObject touch_control;
    //public GameObject mytouch;
    public GameObject LaneLightTrigger;
    public spam Spam; //script "spam" dr touch controller
    //BOOL
    public bool Tap;
    public bool hold;
    public bool flick;
    public bool sideflick;

    //float
    public float timerT = 0;
    //public float timerF = 0;
    //public float timerSF = 0;
    public float touch_detect;

    //INT
    public int PointCollision;

    public Material material;

    private HashSet<Collider> touchSystemColliders = new HashSet<Collider>(); // Set untuk menyimpan collider yang bertabrakan
    private float resetTimer = 0.2f; // Waktu untuk menunggu validasi (dalam detik)
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Smaterial = LaneLightTrigger.GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Tap)
        {
            timerT++;
                if (timerT == 3)
            {
                Tap = false; Debug.Log("tap"); timerT = 0; } }
        

        if (flick)
        { flick = false; Debug.Log("flicked"); }
        

        if (sideflick)
        { sideflick = false; Debug.Log("sideflicked"); }
        

        if (touch_detect < 0)
        {
            touch_detect = 0;
        }

        if(touch_detect == 0)
        {
            hold = false;
        }
        
        if(hold)
        {
            Color color = material.color;
            color.a = 0.5f;
            material.color = color;
            //LaneLightTrigger.GetComponent<Renderer>().material.color = Color.cyan;
        }
        else if (!hold)
        {
            Color color = material.color; 
            color.a = 0; 
            material.color = color;
            //LaneLightTrigger.GetComponent<Material>().color.a = 0;
        }

        if (touchSystemColliders.Count == 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                hold = false;
                touch_detect = 0;
            }
        }
        else
        {
            // Reset timer jika ada collision
            timer = resetTimer;
        }

    }

    public void flicker()
    {
        flick = true;
    }

    public void sideflicker()
    {
        sideflick = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        /*if (collision.collider.CompareTag("touch system"))
        {
            if(!Spam.hasTap.Contains(collision.gameObject))
            {
                Tap = true;
            }
            Spam.hasTap.Add(collision.gameObject);
            hold = true;
            touch_detect += 1;
        }*/
        if (collision.collider.CompareTag("falser"))
        {
            if (touch_detect == 1)
            {
                hold = false;
                touch_detect = 0;
            }
            else
            {
                touch_detect -= 1;
            }
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("touch system"))
        {
            if (!touchSystemColliders.Contains(collision.collider))
            {
                /*if (!Spam.hasTap.Contains(collision.gameObject))
                {
                    Tap = true;
                }
                Spam.hasTap.Add(collision.gameObject);*/
                Tap = true;
                hold = true;
                touchSystemColliders.Add(collision.collider);
                touch_detect++;
            }
        }
        
        hold = touchSystemColliders.Count > 0; // Tetap true jika ada collision
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("touch system"))
        {
            if (touchSystemColliders.Contains(collision.collider))
            {
                touchSystemColliders.Remove(collision.collider);
                touch_detect--;
            }
        }

        // Tidak langsung mereset `hold`, karena validasi terjadi di Update
    }
}
