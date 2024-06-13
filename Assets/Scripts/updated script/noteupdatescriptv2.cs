using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class noteupdatescriptv2 : MonoBehaviour
{
    //optimalization
    [HideInInspector]
    public
        bool on_area;

    public
        GameObject anchorpoint_script, bpmcontroller, lane, VFX;

    public
        Transform selfpos;

    [HideInInspector]
    public float maxvalue = 500;

    [HideInInspector]
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
    }

    // Update is called once per frame
    void Update()
    {
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
        if(currentfloat < -500)
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

        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("active area"))
        {
            on_area = true;

        }

        if (collision.collider.CompareTag("judgeline"))
        {
            //VFX.SetActive(true);
            //gameObject.SetActive(false);
            Instantiate(VFX, selfpos.position, selfpos.rotation);
            //VFX.GetComponent<VideoPlayer>().Play();
            //Renderer rend = GetComponent<Renderer>();
            //Material material = rend.material;
            //rend
            //Invoke("vfx", 0.1f);
            

        }

        
    }

    void vfx()
    {
        VFX.GetComponent<VideoPlayer>().playOnAwake = false;
    }

    IEnumerator toward()
    {
        float startangle = acumulation;
        if(percentage > 0)
        {
            while (currentZ < targetrota)
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
            while (currentZ > targetrota)
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
