using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followrute : MonoBehaviour
{
    public proyeksirute rute;
    public float speed;
    [SerializeField] public Vector3 objpos;
    public float[] targetwaktu;
    public float[] gimmickbpm;
    public float[] speedprojectorgimmick;
    public float realtime;
    //public float targettime;
    //public float detik;
    //public float dtrans;
    //public float listtime;
    //public float listimpact;
    public float floatarget;
    public float bpmgim;
    public float speedgim;

    public float samplewaktu;

    public int listgimmick;
    public int listcount;

    public bool hold;
    public float nomor;
    public static followrute fr;
    public bool awal;
    public bool gotoroute;
    public bool after;
    public bool before;
    public float bpm;
    public bool head;
    // Start is called before the first frame update
    void Start()
    {
        listcount = targetwaktu.Length -1;
        listgimmick = 0;
        bpm = bpm / 1000;
        samplewaktu = 0f;
        //targettime = timedivide / targettime;
        before = true;
        //nomor = nomor / 10;
        //Invoke("Update", nomor);
        //awal = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(targetwaktu.Length > 0)
        {
            floatarget = targetwaktu[listgimmick];
        }

        if (gimmickbpm.Length > 0)
        {
            bpmgim = gimmickbpm[listgimmick];
        }

        if(speedprojectorgimmick.Length > 0)
        {
            speedgim = speedprojectorgimmick[listgimmick];
        }

        //targetwaktu.Length

        

        
        realtime += Time.deltaTime;
        //listtime = floatarget;
        //listimpact = bpmgim;
        if(realtime >= floatarget)
        {
            if (listgimmick == listcount)
            {
                listgimmick = listcount;
            }
            else
            {
                listgimmick++;
            }
            
            bpm = bpmgim/1000;
            speed = speedgim;
        }
        
        //objpos.x = realtime;
        if(gotoroute)
        {
            /*samplewaktu += Time.deltaTime * speed;
            transform.position = rute.evaluasi(/*dengansamplewaktu);
            transform.forward = rute.evaluasi(samplewaktu + /*per koordinat0.001f) - transform.position;*/

            samplewaktu += Time.deltaTime * (bpm * 10 + speed);
            transform.position = rute.evaluasi(/*dengan*/samplewaktu);
            transform.forward = rute.evaluasi(samplewaktu + /*per koordinat*/001f) - transform.position;

            if (samplewaktu >= 1f)
            {
                //samplewaktu = Time.deltaTime;
                gotoroute = false;
                after = true;

            }
        }
        if(before)
        {
            transform.position += new Vector3(bpm, 0, 0);
        }
        if(after)
            if(head)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                transform.position += new Vector3(bpm, 0, 0);
            }

        





    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("route"))
        {
            Debug.Log("followroute");
            gotoroute = true;
            before = false;
        }

        if (collision.collider.CompareTag("Finish"))
        {
            if(head)
            {
                head = false;
                gameObject.GetComponent<holdtrial>().enabled = false;
                //transform.position += new Vector3(bpm, 0, 0);
            }
            
        }

        /*if (collision.collider.CompareTag("exitroute"))
        {
            gotoroute = true;
        }*/
    }

    void jalan()
    {
        //gameObject.GetComponent<followrute>().enabled;


    }

}
