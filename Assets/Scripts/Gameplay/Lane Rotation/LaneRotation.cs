using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class LaneRotation : MonoBehaviour
{
    public int ShiftCount;

    public float timelapsed = 0f;
    [SerializeField]
    [Range (0, 60)]
    public float RotationSpeed;
    public float currentAngle;
    private Dictionary<string, float> lanes = new Dictionary<string, float>
    {
        { "1", 30f },
        { "2", 60f },
        { "3", 90f },
        { "4", 120f },
        { "5", 150f },
        { "6", 180f },
        { "7", 210f },
        { "8", 240f },
        { "9", 270f },
        { "10", 300f },
        { "11", 330f },
        { "12", 360f }
    };

    public bool startRotating;
    public bool stopRotating;
    [SerializeField]
    private GameObject lane;
    
    void Start()
    {
    }

    void Update()
    {
        float laneZRotation = lane.transform.rotation.eulerAngles.z;
        if(laneZRotation >= 360f) {
            currentAngle = 0f;
        } else {
            currentAngle = laneZRotation;
        }

        if (startRotating)
        {
            stopRotating = false;
            StartCoroutine(LerpRotate());
            startRotating = false;
            Debug.Log($"Start : {currentAngle}");
        }

        if (stopRotating)
        {
            StopCoroutine(LerpRotate());
            lane.transform.eulerAngles = new Vector3(0, 0, currentAngle);
            Debug.Log($"Stop : {currentAngle}");
        }
    }

    private float getTheNumberOfRotation()
    {
        foreach (KeyValuePair<string, float> laneAngle in lanes)
        {
            string laneKey = laneAngle.Key;
            float laneValue = laneAngle.Value;

            if (ShiftCount < 0)
            {
                if (Mathf.Abs(ShiftCount).ToString() == laneKey)
                {
                    return currentAngle - laneValue; // Adjust rotation for negative shift
                }
            }
            else
            {
                if (ShiftCount.ToString() == laneKey)
                {
                    return currentAngle + laneValue; // Keep positive shift as is
                }
            }
        }
        return currentAngle; 
    }

    private IEnumerator LerpRotate()
    {
        float startAngle = currentAngle;
        float targetAngle = getTheNumberOfRotation(); 
        float totalRotation = Mathf.Abs(targetAngle - startAngle);

        Debug.Log($"Start : {startAngle}, Target : {targetAngle}");

        // Clamp RotationSpeed to maximum 60
        RotationSpeed = Mathf.Min(RotationSpeed, 60);

       if (RotationSpeed == 0f)
        {
            lane.transform.eulerAngles = new Vector3(0,0,targetAngle);
            currentAngle = targetAngle;
            timelapsed = 0f;
            stopRotating = true;
        }

        while (!stopRotating)
            {
                timelapsed += Time.deltaTime;

                currentAngle = Mathf.Lerp(startAngle, targetAngle, timelapsed * RotationSpeed / totalRotation);

                lane.transform.rotation = Quaternion.Euler(0, 0, currentAngle);
                
                if(currentAngle >= 360f) {
                    lane.transform.rotation = Quaternion.Euler(0, 0, 0);
                    currentAngle = 0f;
                    timelapsed = 0f;
                    stopRotating = true;
                }
                if(currentAngle == targetAngle) {
                    lane.transform.rotation = Quaternion.Euler(0, 0, targetAngle);
                    currentAngle = targetAngle;
                    timelapsed = 0f;
                    stopRotating = true;
                }
                yield return null;
            }
    }
}
