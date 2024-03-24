using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class rotalane: MonoBehaviour
{
    //[Header("liat catatan di dalam script klau bingung")]
    [Header("Give Role")]
    public bool is_lane;
    public bool is_notetowards;
    [Header("variable pembelokan jalur note memakai variable notoward diatas 50")]
    public bool is_note;
    
    [Header("precentage")]
    public float maxvalue = 420;
    public float currentfloat;
    public float precentage;


    [Header("value & variable untuk rotanale & notetowards dengan tospeed range -50 sampai 50")]
    //BOOL
    public bool startRotating;
    public bool stopRotating;
    private bool running;
    //FLOAT
    public float speedrotation;
    public float rotationTime;
    private float currentAngle = 0f;
    public float timelapsed;
    public float fromspeed = 0f;
    public float tospeed;
    public float factorial = 0.5f;
    float rotationSpeed;
    float timelapsestop;
    float absolute;
    //float absolutepercen;

    //GAMEOBJECT
    public GameObject lane;

    [Header("var for notetowards")]
    //2 type condition
    public bool slowrotate;
    [Header("jika slowrotate maka pakai variable rotasi yg sama dengan lane")]
    public bool fastrotate;
    //BOOL
    bool orieuler;
    bool canrotate;
    [Header("nyalakan untuk memulai analisis float yg dibuat")]
    public bool play;
    bool checking;
    [Header("var notetowards yg hanya berlaku untuk tospeed diatas 50 atau -50")]
    //Float
    public float currentZ;
    public float speedrotatoward;
    float rotaspeedtowards;
    public float tospeedtowards;
    //float saverota;
    public float rotaz;

    //LIST OF COROUTINE
    IEnumerator mynotetowards;
   

    
    // Start is called before the first frame update
    void Start()
    {
        //currentrota = transform.rotation;
        //StartCoroutine(rotasi());
        timelapsed = 0f;
        //saverota = 0f;
        mynotetowards = notetowards();
        checking = true;
        running = false;
    }

    // Update is called once per frame
    void Update()
    {
        //absolute = Mathf.Abs(currentfloat);
        /*rotaz = lane.transform.eulerAngles.z;
        if (rotaz < 180)
        {
            currentZ = rotaz;
        }
        else if(rotaz > 180)
        {
            currentZ = rotaz - 360;
        }
        
        
        precentage = (currentfloat / maxvalue) * 105f;
        precentage = Mathf.Min(precentage, 105f);
        if (tospeed > 50)
        {
            fastrotate = true;
            slowrotate = false;
            currentfloat = tospeed - 50f;
        }

        if (tospeed >= -50 && tospeed <= 50)
        {
            currentfloat = 0;
            slowrotate = true;
            fastrotate = false;
        }
        else if (tospeed < -50)
        {
            fastrotate = true;
            slowrotate = false;
            currentfloat = tospeed + 50f;
        }*/
        //currentZ = lane.transform.eulerAngles.z;
        if (is_notetowards || is_note)
        {
            if (tospeed > 50)
            {
                fastrotate = true;
                slowrotate = false;
                currentfloat = tospeed - 50f;
            }

            if (tospeed >= -50 && tospeed <= 50)
            {
                currentfloat = 0;
                slowrotate = true;
                fastrotate = false;
            }
            else if (tospeed < -50)
            {
                fastrotate = true;
                slowrotate = false;
                currentfloat = tospeed + 50f;
            }
            if (play)
            {
                rotaz = lane.transform.eulerAngles.z;
                if (rotaz < 180)
                {
                    currentZ = rotaz;
                }
                else if (rotaz > 180)
                {
                    currentZ = rotaz - 360;
                }


                precentage = (currentfloat / maxvalue) * 105f;
                precentage = Mathf.Min(precentage, 105f);
                

                if (fastrotate)
                {
                    if (checking)
                    {
                        //Debug.Log("asw");
                        slowrotate = false;
                        tospeedtowards = 100;
                        orieuler = true;
                    }




                }

                if (orieuler)
                {
                    checking = false;
                    canrotate = true;
                    slowrotate = false;
                    fastrotate = false;
                    timelapsed += Time.deltaTime;
                    StartCoroutine(notetowards());

                }

                if (running)
                {
                    //timelapsed += Time.deltaTime;
                    fastrotate = false;
                    //
                    if (timelapsed > rotationTime - 0.5f)
                    {
                        //backrotate = true;
                        currentfloat = 0;
                        timelapsed += Time.deltaTime;
                        fastrotate = false;
                        canrotate = false;
                        orieuler = false;
                        //Debug.Log("time");
                        //StopCoroutine(mynotetowards);
                        StartCoroutine(rotowardsback());
                    }

                    if (timelapsed > 1 && currentZ == 0)
                    {
                        timelapsed = 0;
                        running = false;
                        checking = true;
                        play = false;
                        StopAllCoroutines();
                    }

                }



                
            }

            if (slowrotate)
            {
                if (startRotating)
                {
                    //running = true;
                    stopRotating = false;
                    StartCoroutine(LerpRotate());
                    StartCoroutine(stopping());
                    startRotating = false;
                    Debug.Log($"Start : {currentAngle}");
                }

                if (stopRotating)
                {
                    running = false;
                    StopCoroutine(LerpRotate());
                    StopCoroutine(stopping());
                    lane.transform.eulerAngles = new Vector3(0, 0, currentAngle);
                    //Debug.Log($"Stop : {currentAngle}");
                }

                if (running)
                {
                    if (speedrotation == 0)
                    {
                        stopRotating = true;
                        StopCoroutine(LerpRotate());
                        StopCoroutine(stopping());
                        lane.transform.eulerAngles = new Vector3(0, 0, currentAngle);
                        Debug.Log($"Stop : {currentAngle}");
                        timelapsed = 0;
                        play = false;
                        running = false;
                        StopAllCoroutines();
                    }
                }


            }
            //checking = true;


        }
        

        if(is_lane)
        {
            //currentZ = lane.transform.eulerAngles.z;
            if (startRotating)
            {
                //running = true;
                stopRotating = false;
                StartCoroutine(LerpRotate());
                StartCoroutine(stopping());
                startRotating = false;
                Debug.Log($"Start : {currentAngle}");
            }

            if (stopRotating)
            {
                running = false;
                //StopCoroutine(LerpRotate());
                //StopCoroutine(stopping());
                lane.transform.eulerAngles = new Vector3(0, 0, currentAngle);
                Debug.Log($"Stop : {currentAngle}");
            }

            if (running)
            {
                if (speedrotation == 0)
                {
                    stopRotating = true;
                    //StopCoroutine(LerpRotate());
                   // StopCoroutine(stopping());
                    lane.transform.eulerAngles = new Vector3(0, 0, currentAngle);
                    Debug.Log($"Stop : {currentAngle}");
                    timelapsed = 0;
                    running = false;
                }
            }
        }
        
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("target1"))
        {
            if(is_note)
            {
                play = true;
            }
            
        }
    }
    private IEnumerator LerpRotate()
    {
        float startAngle = currentAngle;
        
        //float rotationSpeed;
        while (timelapsed < rotationTime && !stopRotating)
        {
            timelapsed += Time.deltaTime;

            speedrotation = Mathf.Lerp(fromspeed, tospeed, timelapsed / factorial);
            rotationSpeed = speedrotation * Time.deltaTime;
            startAngle += rotationSpeed;

            lane.transform.rotation = Quaternion.Euler(0, 0, startAngle);

            currentAngle = lane.transform.eulerAngles.z;

            yield return null;

            while (timelapsed > rotationTime - 0.5f && !stopRotating)
            {
                timelapsed += Time.deltaTime;
                running = true;
                //speed = Mathf.Lerp(fromspeed, tospeed, timelapsed / factorial);
                rotationSpeed = speedrotation * Time.deltaTime;
                startAngle += rotationSpeed;

                lane.transform.rotation = Quaternion.Euler(0, 0, startAngle);

                currentAngle = lane.transform.eulerAngles.z;
                timelapsestop += Time.deltaTime;
                //Debug.Log("running stop22");
                speedrotation = Mathf.Lerp(tospeed, fromspeed, timelapsestop / factorial);
                yield return null;
            }

        }      // lane.transform.rotation = Quaternion.Euler(0, 0, 360);
    }

    private IEnumerator stopping()
    {
        //timelapsed += Time.deltaTime;
        //Debug.Log("running stop");
        //float rotationspeed;
        while (timelapsed > rotationTime - 0.5f && !stopRotating)
        {
            
            //Debug.Log("running stop22");
            speedrotation = Mathf.Lerp(tospeed, fromspeed, timelapsed / factorial);
            yield return null;
        }
    }

    private IEnumerator notetowards()
    {
        float startangle = currentAngle;
        //Debug.Log("hai");
        if(tospeed > 0)
        {
            if (canrotate)
            {
                //Debug.Log("done");
                while (currentZ < precentage && timelapsed < rotationTime)
                {
                    //Debug.Log("done");
                    //fastrotate = false;
                    //Debug.Log("orieuler");
                    //timelapsed += Time.deltaTime;
                    speedrotatoward = Mathf.Lerp(fromspeed, tospeedtowards, timelapsed / factorial);
                    rotaspeedtowards = speedrotatoward * Time.deltaTime;
                    startangle += rotaspeedtowards;

                    lane.transform.rotation = Quaternion.Euler(0, 0, startangle);
                    currentAngle = lane.transform.eulerAngles.z;
                    slowrotate = false;
                    running = true;
                    yield return null;


                }

                
            }
        }

        if (tospeed < 0)
        {
            if (canrotate)
            {
                //Debug.Log("done");
                

                while (currentZ > precentage && timelapsed < rotationTime)
                {

                    //fastrotate = false;
                    //Debug.Log("orieuler");
                    //timelapsed += Time.deltaTime;
                    speedrotatoward = Mathf.Lerp(fromspeed, -tospeedtowards, timelapsed / factorial);
                    rotaspeedtowards = speedrotatoward * Time.deltaTime;
                    startangle += rotaspeedtowards;

                    lane.transform.rotation = Quaternion.Euler(0, 0, startangle);
                    currentAngle = lane.transform.eulerAngles.z;
                    slowrotate = false;
                    running = true;
                    yield return null;
                }
            }
        }




    }

    private IEnumerator rotowardsback()
    {
        float startangle = currentAngle;
        //Debug.Log("hoi");
        if (tospeed > 0)
        {
            while (currentZ > precentage && timelapsed > rotationTime - 0.5f)
            {
                
                speedrotatoward = Mathf.Lerp(fromspeed, -tospeedtowards, timelapsed / factorial);
                rotaspeedtowards = speedrotatoward * Time.deltaTime;
                startangle += rotaspeedtowards;

                lane.transform.rotation = Quaternion.Euler(0, 0, startangle);
                currentAngle = lane.transform.eulerAngles.z;
                slowrotate = false;
                yield return null;
                while(currentZ < 2)
                {
                    lane.transform.rotation = Quaternion.Euler(0, 0, 0);
                    yield return null;
                }
            }
        }

        if (tospeed < 0)
        {
            while (currentZ < precentage && timelapsed > rotationTime - 0.5f)
            {

                speedrotatoward = Mathf.Lerp(fromspeed, tospeedtowards, timelapsed / factorial);
                rotaspeedtowards = speedrotatoward * Time.deltaTime;
                startangle += rotaspeedtowards;

                lane.transform.rotation = Quaternion.Euler(0, 0, startangle);
                currentAngle = lane.transform.eulerAngles.z;
                slowrotate = false;
                yield return null;
                while (currentZ > -2)
                {
                    lane.transform.rotation = Quaternion.Euler(0, 0, 0);
                    yield return null;
                }
            }
        }
    }

    
}
