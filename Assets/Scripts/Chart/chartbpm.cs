using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chartbpm : MonoBehaviour
{
    public float[] targetwaktu;
    public float[] gimmickbpm;
    [HideInInspector]
    public float[] speedprojectorgimmick;
    [HideInInspector]
    public float realtime;
    //public float targettime;
    //public float detik;
    //public float dtrans;
    //public float listtime;
    //public float listimpact;
    [HideInInspector]
    public float floatarget;
    [HideInInspector]
    public float bpmgim;
    [HideInInspector]
    public float speedgim;
    [HideInInspector]
    public float speed;
    //[HideInInspector]
    //public float bpmfixfloat;
    public float bpm;
    [HideInInspector]
    public float fixbpm;

    public bool ongimmick;
    //public float samplewaktu;
    [HideInInspector]
    public int listgimmick;
    [HideInInspector]
    public int listcount;

    public bool opt_1;
    public bool fix_2;

    public static chartbpm speednote;
    public GameObject position_point;
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
        if(opt_1)
        {
            fixbpm = bpm * 60 / 4;
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

                        bpm = (bpmgim * 4) / 60;
                        speed = speedgim;
                    }
                }
            }
        }

        if(fix_2)
        {
            fixbpm = bpm * 60 / 4;
            transform.position += new Vector3(0, 0, bpm * Time.deltaTime);
            //position_point.transform.position += new Vector3(0, 0, bpm * Time.deltaTime);

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

                    bpm = (bpmgim * 4) / 60;
                    speed = speedgim;
                }
            }
        }

        
        
        
    }
}
