using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HoldTrialScr : MonoBehaviour
{
    //optimalization
    [HideInInspector]
    public
        bool on_area;

    public
        GameObject anchorpoint_script, bpmcontroller, lane, VFX_Hold, vfx_hold_clone, judge2, pusat_anchor;

    public
        Transform selfpos, canvas_vfx;

    public vfx_instans vfxscr;

    [HideInInspector]
    public float maxvalue = 500;

    //[HideInInspector]
    public
        float currentfloat, percentage, timelapsed, acumulation, currentZ, accel, targetspeed, currentfloat2, speedrotapercentage, targetrota, rotaz;
    [HideInInspector]
    public float rotapercentage, bpmpercentage, penambahan;
    [HideInInspector]
    float factorial = 0.5f;
    [HideInInspector]
    float rotaspeed;

    public static noteupdatescriptv2 notescr;
    [HideInInspector]
    public
        int kind;

    public GameObject[] holdfx;

    public bool test_pc, endhold, glitchy;
    //public livefx livefx;

    /*LIST OF VALUE
    public bool on_area;

    public GameObject anchorpoint;
    public GameObject bpmcontroller;

    public bool rotate_to_target;
    //public bool rotate_back;

    public float maxvalue = 420;
    public float currentfloat;
    public float percentage;

    public float timelapsed;
    public float acumulation;
    public float factorial = 0.5f;
    float rotaspeed;

    public float currentlanez;
    public float accel;
    public float targetspeed;
    public float rotaz;*/
    // Start is called before the first frame update
    void Start()
    {
        maxvalue = 500;
        selfpos = gameObject.transform;
        judge2 = GameObject.Find("Judgement 2");
        lane = GameObject.Find("inti_lane");
        GameObject canvasfx = GameObject.Find("vfx spawn");
        if (canvasfx != null) { canvas_vfx = canvasfx.transform; }
        bpmcontroller = GameObject.Find("Note");
        pusat_anchor = GameObject.Find("Pusat_Anchor_For All_Object");
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 selfposreal = new Vector3(selfpos.transform.position.x, selfpos.transform.position.y, judge2.transform.position.z);
        rotaz = anchorpoint_script.transform.eulerAngles.z;
        if (rotaz < 180)
        {
            currentZ = rotaz;
        }
        else if (rotaz > 180)
        {
            currentZ = rotaz - 360;
        }

        currentfloat = lane.GetComponent<lanescriptupdatev1>().targetspeed;
        percentage = (currentfloat / maxvalue) * 165f;
        percentage = Mathf.Min(percentage, 165f);
        if (currentfloat < -500)
        {
            percentage = -165;
        }

        //currentfloat2 = targetspeed;
        //speedrotapercentage = (currentfloat2 / percentage) * 55f;
        //speedrotapercentage = Mathf.Min(speedrotapercentage, 55f);

        //percentage = Mathf.Max(percentage, 165f);

        if (on_area)
        {
            //float tempres;
            //targetspeed = 0.3f * targetrota;
            //targetspeed = tempres * 0.2175f;
            targetrota = percentage;
            penambahan = bpmcontroller.GetComponent<chartbpm>().fixbpm / 10;
            bpmpercentage = (20 + penambahan) / 100;
            rotapercentage = (bpmcontroller.GetComponent<chartbpm>().fixbpm * bpmpercentage) / 100;
            targetspeed = targetrota * rotapercentage;
            timelapsed += Time.deltaTime;
            StartCoroutine(toward());
        }

        if (test_pc)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                GameObject instantiatedobject = Instantiate(VFX_Hold, selfposreal, selfpos.rotation, canvas_vfx);
                HoldVfx dst = instantiatedobject.GetComponent<HoldVfx>();
                if (dst != null) { dst.myhold = gameObject; }
            }
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("active area"))
        {
            on_area = true;

        }

        if (collision.collider.CompareTag("judgeline"))
        {
            Vector3 selfposreal = new Vector3(pusat_anchor.transform.position.x, pusat_anchor.transform.position.y, judge2.transform.position.z);
            //Quaternion euler = Quaternion.Euler(selfpos.transform.rotation.x, selfpos.transform.rotation.y, selfpos.transform.rotation.z);
            //vfxscr.vfxspawn();
            //VFX.SetActive(true);
            //gameObject.SetActive(false);
            GameObject instantiatedobject = Instantiate(VFX_Hold, selfposreal, selfpos.rotation, canvas_vfx);
            Transform[] holdvx = instantiatedobject.GetComponentsInChildren<Transform>();
            holdfx = new GameObject[holdvx.Length-1];
            int index = 0;
            foreach (Transform child in holdvx)
            {
                if(child != instantiatedobject.transform)
                {
                    holdfx[index] = child.gameObject;
                    index++;
                }
            }
            HoldVfx dst = holdfx[0].GetComponent<HoldVfx>();
            if (dst != null) { dst.myhold = gameObject; }

            if (glitchy)
            {
                gameObject.GetComponent<Glitch>().enabled = true;
            }
            //active = true;
            //VFX.GetComponent<VideoPlayer>().Play();
            //Renderer rend = GetComponent<Renderer>();
            //Material material = rend.material;
            //rend
            //Invoke("vfx", 0.1f);


        }


    }

    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("exithold");
        if (collision.collider.CompareTag("judgeline"))
        {
            endhold = true;
            //Destroy(VFX_Hold(Clone).gameObject);
            //Instantiate(Vfx_end, selfpos.position, selfpos.rotation, canvas_vfx);
            //VFX_Hold.GetComponent<livefx>().holddestroy
        }
    }

    /*void vfx()
    {
        VFX.GetComponent<VideoPlayer>().playOnAwake = false;
    }*/

    IEnumerator toward()
    {
        float startangle = acumulation;
        if (percentage > 0)
        {
            while (currentZ < 360)
            {
                accel = Mathf.Lerp(0, targetspeed, timelapsed / factorial);
                rotaspeed = accel * Time.deltaTime;
                startangle += rotaspeed;

                anchorpoint_script.transform.rotation = Quaternion.Euler(0, 0, startangle);
                acumulation = anchorpoint_script.transform.eulerAngles.z;
                //slowrotate = false;
                //running = true;
                yield return null;
            }
        }

        if (percentage < 0)
        {
            while (currentZ < 360)
            {
                accel = Mathf.Lerp(0, targetspeed, timelapsed / factorial);
                rotaspeed = accel * Time.deltaTime;
                startangle += rotaspeed;

                anchorpoint_script.transform.rotation = Quaternion.Euler(0, 0, startangle);
                acumulation = anchorpoint_script.transform.eulerAngles.z;
                //slowrotate = false;
                //running = true;
                yield return null;
            }
        }

    }
}
