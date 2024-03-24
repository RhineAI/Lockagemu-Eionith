using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chartbpm : MonoBehaviour
{
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
    public float speed;
    //public float bpmfixfloat;
    public float bpm;

    public bool ongimmick;
    //public float samplewaktu;

    public int listgimmick;
    public int listcount;

    public static chartbpm speednote;
    // Start is called before the first frame update
    void Start()
    {
        listcount = targetwaktu.Length - 1;
        listgimmick = 0;
        bpm = (bpm *4) / 60;
        
    }

    // Update is called once per frame
    void Update()
    {

        
        int childCount = transform.childCount;

        
        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            
            child.transform.position += new Vector3(0, 0, bpm * Time.deltaTime);

            if (ongimmick)
            {
                if (targetwaktu.Length > 0)
                {
                    floatarget = targetwaktu[listgimmick];
                }
                else
                {
                    listgimmick = 0;
                }

                if (gimmickbpm.Length > 0)
                {
                    bpmgim = gimmickbpm[listgimmick];
                }
                else
                {
                    listgimmick = 0;
                }

                if (speedprojectorgimmick.Length > 0)
                {
                    speedgim = speedprojectorgimmick[listgimmick];
                }
                else
                {
                    listgimmick = 0;
                }

                //targetwaktu.Length




                realtime += Time.deltaTime;
                //listtime = floatarget;
                //listimpact = bpmgim;
                if (realtime >= floatarget)
                {
                    if (listgimmick == listcount)
                    {
                        listgimmick = listcount;
                    }
                    else
                    {
                        listgimmick++;
                    }

                    bpm = bpmgim / 60;
                    speed = speedgim;
                }
            }
        }
        
        
    }
}
