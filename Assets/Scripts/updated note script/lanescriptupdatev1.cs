using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanescriptupdatev1 : MonoBehaviour
{
    //optimimalization
    [HideInInspector]
    public
       bool startRotating, hasrunning, optimising, is_rotating, optimizing, checking, optimizing_minus, optimizing_plus, finishless, finishmore;

    //optimze rotation condition
    [HideInInspector]
    public
       bool RM180, RM150, RM120, RM90, RM60, RM30, R0, R30, R60, R90, R120, R150, R180, lessrota, morerota, more, less;
    //nah ini tambahan buat value meresahkan yg gmw ditambah karena di void :v
    [HideInInspector]
    public
       bool xplus, xplus180optmin, xplus180optplus, xminus, xminus180optmin, xminus180optplus;
    [HideInInspector]
    public
          float X_optimize, rotaz, currentZ;

    public
        GameObject lane;

    [HideInInspector]
    public
        float timelapsed, timelapsestop, rotationTime, speedrotation, targetspeed, currentspeed;
    float factorial;
    float rotationSpeed;
    float currentAngle;

    public static lanescriptupdatev1 lanescr;

    [HideInInspector]
    public
        int step; 
    
    IEnumerator lerpcoro;
    IEnumerator analisoff;

    /*LIST OF VALUE
    public
        bool startRotating;
        bool hasr unning;
    public 
        GameObject lane;

    public 
        float timelapsed;
        float timelapsestop; 
        float rotationTime; 
        float speedrotation; 
        float targetspeed; 
        float factorial = 0.5f;
    float rotationSpeed;
    float currentAngle;*/

    // Start is called before the first frame update
    void Start()
    {
        //analisoff = analis();
        lerpcoro = LerpRotate();
        factorial = 0.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //#Optimization rotalane
        rotaz = lane.transform.eulerAngles.z;
        if (rotaz < 180)
        {
            currentZ = rotaz;
        }
        else if (rotaz > 180)
        {
            currentZ = rotaz - 360;
        }

        

        currentspeed = speedrotation;
        //targetspeed = gameObject.GetComponent<changetarget>().receiver_impact;
        //rotationTime = gameObject.GetComponent<changetarget>().receiver_duration;

        if(rotationTime > 0)
        {
            startRotating = true;
        }
        if(startRotating)
        {
            //targetspeed = gameObject.GetComponent<changetarget>().receiver_impact;
            timelapsed += Time.deltaTime;
            StartCoroutine(LerpRotate());
        }

        if(targetspeed <= 0)
        {
            optimizing_minus = true;
            optimizing_plus = false;
        }
        else
        {
            optimizing_plus = true;
            optimizing_minus = false;
        }

        if(checking)
        {
            //kind of condition
            if (currentZ >= -180 && currentZ <= -165) { RM180 = true; X_optimize = 0; } else { RM180 = false; }
            if (currentZ >= -165 && currentZ <= -135) { RM150 = true; X_optimize = -150; } else { RM150 = false; }
            if (currentZ >= -135 && currentZ <= -105) { RM120 = true; X_optimize = -120; } else { RM120 = false; }
            if (currentZ >= -105 && currentZ <= -75) { RM90 = true; X_optimize = -90; } else { RM90 = false; }
            if (currentZ >= -75 && currentZ <= -45) { RM60 = true; X_optimize = -60; } else { RM60 = false; }
            if (currentZ >= -45 && currentZ <= -15) { RM30 = true; X_optimize = -30; } else { RM30 = false; }
            if (currentZ >= -15 && currentZ <= 15) { R0 = true; X_optimize = 0; } else { R0 = false; }
            if (currentZ >= 15 && currentZ <= 45) { R30 = true; X_optimize = 30; } else { R30 = false; }
            if (currentZ >= 45 && currentZ <= 75) { R60 = true; X_optimize = 60; } else { R60 = false; }
            if (currentZ >= 75 && currentZ <= 105) { R90 = true; X_optimize = 90; } else { R90 = false; }
            if (currentZ >= 105 && currentZ <= 135) { R120 = true; X_optimize = 120; } else { R120 = false; }
            if (currentZ >= 135 && currentZ <= 165) { R150 = true; X_optimize = 150; } else { R150 = false; }
            if (currentZ >= 165 && currentZ <= 180) { R180 = true; X_optimize = 0; } else { R180 = false; }
        }
        if(hasrunning)
        {
            
            //targetspeed = 0;
            timelapsestop += Time.deltaTime;
            /*if (speedrotation == targetspeed/5)
            {
                //optimizing = true;
                //checking = true;
                //optimising = true;
                Invoke("Opt", 0.1f);
                timelapsed = 0;
                timelapsestop = 0;
                //targetspeed = 0;
                rotationTime = 0;
                StopAllCoroutines();
                hasrunning = false;
            }*/

            float hasil = targetspeed/5;
            float tolerance = 1f;
            if (Mathf.Abs(speedrotation - hasil) < tolerance)
            {
                //Debug.Log("j");
                step = 1;
                //optimizing = true;
                //checking = true;
                //optimising = true;
                Invoke("analis", 0);
                optimizing = true;
                //Invoke("Opt", 0);
                timelapsed = 0;
                timelapsestop = 0;
                //targetspeed = 0;
                rotationTime = 0;
                //StopAllCoroutines();
                hasrunning = false;
                
            }
        }
        checking = true;
        if (optimising)
        {
            StartCoroutine(analystic());
        }
        if (optimizing)
        {
            is_rotating = false;
            if(xplus)
            {
                checking = false;
                xplus = false;
                X_optimize = X_optimize + 30;
                /*if(X_optimize == X_optimize +30)
                {
                    xplus = false;
                }*/
            }
            if(xminus)
            {
                checking = false;
                X_optimize = X_optimize - 30;
                xminus = false;
            }

            if(xplus180optplus)
            {
                checking = false;
                X_optimize = 0;
            }

            if(xplus180optmin)
            {
                checking = false;
                X_optimize = 150;
            }
            
            if (xminus180optplus)
            {
                checking = false;
                X_optimize = -150;
                //xminus180optplus = false;
            }

            if (xminus180optmin)
            {
                checking = false;
                X_optimize = 0;
            }
            //X_optimize = 0;
            if (morerota) { StartCoroutine(optimizer_rotate_more()); }
            if (lessrota) { StartCoroutine(optimizer_rotate_less()); }
            //Invoke("analis", 0.1f);
            //StopCoroutine(analisoff);
            timelapsed += Time.deltaTime;
            //StartCoroutine(optimizer_rotate());
            checking = false;
        }

        if(finishless)
        {
            if(currentZ <= X_optimize)
            {              
                StopAllCoroutines();
                startRotating = false;
                is_rotating = false;
                optimizing = false;
                checking = true;
                finishmore = false;
                finishless = false;
                lessrota = false;
                morerota = false;
                more = false;
                less = false;
                xplus = false; xplus180optmin = false; xplus180optplus = false; xminus = false; xminus180optmin = false; xminus180optplus = false;
                timelapsed = 0;
                timelapsestop = 0;
                rotationTime = 0;
                speedrotation = 0;
                targetspeed = 0;
                currentspeed = 0;
                step = 0;
                lane.transform.rotation = Quaternion.Euler(0, 0, X_optimize);
            }
        }
        if(finishmore)
        {
            if (currentZ >= X_optimize)
            {
                StopAllCoroutines();
                startRotating = false;
                is_rotating = false;
                optimizing = false;
                checking = true;
                finishmore = false;
                finishless = false;
                lessrota = false;
                morerota = false;
                more = false;
                less = false;
                xplus = false; xplus180optmin = false; xplus180optplus = false; xminus = false; xminus180optmin = false; xminus180optplus = false;
                timelapsed = 0;
                timelapsestop = 0;
                rotationTime = 0;
                speedrotation = 0;
                targetspeed = 0;
                currentspeed = 0;
                step = 0;
                lane.transform.rotation = Quaternion.Euler(0, 0, X_optimize);
            }
        }

        //if (RM180 || R180) { if (Input.GetKey(KeyCode.Space)) { Debug.Log("yo"); } }
    }

    void Opt()
    {
        optimising = true;
    }

    IEnumerator analystic()
    {
        if (currentZ < X_optimize)
        {
            if (optimizing_plus)
            {
                morerota = true;
                optimizing = true;
                //checking = false;

            }
            else if (optimizing_minus)
            {
                //X_optimize = X_optimize - 30;
                lessrota = true;
                optimizing = true;
                xminus = true;
            }
        }
        if (currentZ > X_optimize)
        {

            if (optimizing_plus)
            {
                //Debug.Log("j");
                xplus = true;
                morerota = true;
                optimizing = true;
                //checking = false;

            }
            else if (optimizing_minus)
            {
                lessrota = true;
                optimizing = true;
            }
            yield return null;

        }
    }
    void analis()
    {
        //Debug.Log("korotin");
        
        //yield return new WaitForSeconds(0.1f);
        /*if (RM180 || R180)
        { if(currentZ < X_optimize) { lessrota = true; less = true; } 
          if(currentZ > X_optimize) { morerota = true; more = true; optimizing = true;
          checking = false;}
        }*/
        
        if(RM180)
        {
            optimizing = true;
            if (optimizing_minus)
            {
                
                xminus180optmin = true;
                lessrota = true; less = true; 
                //checking = false; optimising = false;
            }
            if(optimizing_plus)
            {
                //Debug.Log("anjeng");
                xminus180optplus = true;
                morerota = true; optimizing = true;
                //checking = false; optimising = false;
            }
            
        }
        if(R180)
        {
            optimizing = true;
            if (optimizing_minus)
            {
                optimizing = true;
                xplus180optmin = true;
                lessrota = true; 
                //checking = false; optimising = false;
            }
             
            if (optimizing_plus)
            {
                xplus180optplus = true;
                morerota = true; more = true; optimizing = true;
                //checking = false; optimising = false;
            }
            
        }else
        {
            if (currentZ < X_optimize)
            {
                optimizing = true;
                if (optimizing_plus)
                {

                    morerota = true;
                    optimizing = true;
                    //checking = false;

                }
                else if (optimizing_minus)
                {
                    if (RM150)
                    {
                        xminus180optmin = true;
                        lessrota = true; less = true;
                    }
                    else
                    {
                        lessrota = true;
                        optimizing = true;
                        xminus = true;
                    }
                    //X_optimize = X_optimize - 30;
                    
                }
            }
            if (currentZ > X_optimize)
            {
                optimizing = true;

                if (optimizing_plus)
                {
                    if(R150)
                    {
                        xplus180optplus = true;
                        morerota = true; more = true; optimizing = true;
                    }
                    else
                    {
                        xplus = true;
                        morerota = true;
                        optimizing = true;
                    }
                    //Debug.Log("jk");
                    
                    //checking = false;

                }
                else if (optimizing_minus)
                {
                    lessrota = true;
                    optimizing = true;
                }

            }

        }
        

    }

    private IEnumerator LerpRotate()
    {
        float startAngle = currentAngle;

        //float rotationSpeed;
        while (timelapsed < rotationTime && step < 1)
        {
            //timelapsed += Time.deltaTime;
            is_rotating = true;
            speedrotation = Mathf.Lerp(speedrotation, targetspeed, timelapsed / factorial);
            rotationSpeed = speedrotation * Time.deltaTime;
            startAngle += rotationSpeed;

            lane.transform.rotation = Quaternion.Euler(0, 0, startAngle);

            currentAngle = lane.transform.eulerAngles.z;

            yield return null;

            while (timelapsed > rotationTime - 1f && step < 1)
            {
                startRotating = false;
                //timelapsed += Time.deltaTime;
                hasrunning = true;
                //checking = true;
                //speed = Mathf.Lerp(fromspeed, tospeed, timelapsed / factorial);
                rotationSpeed = speedrotation * Time.deltaTime;
                startAngle += rotationSpeed;

                lane.transform.rotation = Quaternion.Euler(0, 0, startAngle);

                currentAngle = lane.transform.eulerAngles.z;
                //timelapsestop += Time.deltaTime;
                //Debug.Log("running stop22");
                if(targetspeed < 0)
                {
                    speedrotation = Mathf.Lerp(targetspeed, targetspeed/5, timelapsestop / (factorial * 2));
                }
                else if(targetspeed > 0)
                {
                    speedrotation = Mathf.Lerp(targetspeed, targetspeed/5, timelapsestop / (factorial * 2));
                }
                
                yield return null;
            }

        }      // lane.transform.rotation = Quaternion.Euler(0, 0, 360);
    }

    private IEnumerator optimizer_rotate_more()
    {
        //finishing = true;
        //Debug.Log("hadir");
        float fixangle = currentAngle;
        if(more)
        {
            while (currentZ >= X_optimize && step > 0)
            {
                
                rotationSpeed = speedrotation * Time.deltaTime;
                fixangle += rotationSpeed;
                lane.transform.rotation = Quaternion.Euler(0, 0, fixangle);
                currentAngle = lane.transform.eulerAngles.z;
                finishless = true;
                yield return null;
                
            }
        }
        else
        {
            while (currentZ <= X_optimize && step > 0)
            {
                rotationSpeed = speedrotation * Time.deltaTime;
                fixangle += rotationSpeed;
                lane.transform.rotation = Quaternion.Euler(0, 0, fixangle);
                currentAngle = lane.transform.eulerAngles.z;
                finishmore = true;
                yield return null;
                
            }
        }
        

    }

    private IEnumerator optimizer_rotate_less()
    {
        //finishing = true;
        float fixangle = currentAngle;
        if(less)
        {
            while (currentZ <= X_optimize && step > 0)
            {
                rotationSpeed = speedrotation * Time.deltaTime;
                fixangle += rotationSpeed;
                lane.transform.rotation = Quaternion.Euler(0, 0, fixangle);
                currentAngle = lane.transform.eulerAngles.z;
                finishmore = true;
                yield return null;
                
            }
        }
        else
        {
            while (currentZ >= X_optimize && step > 0)
            {

                rotationSpeed = speedrotation * Time.deltaTime;
                fixangle += rotationSpeed;
                lane.transform.rotation = Quaternion.Euler(0, 0, fixangle);
                currentAngle = lane.transform.eulerAngles.z;
                finishless = true;
                yield return null;
                
            }
        }
        

    }
}
