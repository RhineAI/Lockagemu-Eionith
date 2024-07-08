using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneRotation : MonoBehaviour
{
    // // CONSTRUCTOR ROTATION
    public int StartTiming { get; set; }
    public int EndTiming { get; set; }
    public int ShiftAmount { get; set; }
    public float RotationSpeed { get; set; }

    public LaneRotation(int startTiming, int endTiming, int shiftAmount, float rotationSpeed)
    {
        ShiftAmount = shiftAmount;
        RotationSpeed = rotationSpeed;
    }

    public float timelapsed = 0f;
    [SerializeField]
    [Range (0, 60)]
    public float speed;
    public float currentAngle;
    public int shiftHowManyLanes;
    
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

            if (shiftHowManyLanes < 0)
            {
                if (Mathf.Abs(shiftHowManyLanes).ToString() == laneKey)
                {
                    return currentAngle - laneValue; // Adjust rotation for negative shift
                }
            }
            else
            {
                if (shiftHowManyLanes.ToString() == laneKey)
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

        // Clamp speed to maximum 60
        speed = Mathf.Min(speed, 60);

        while (!stopRotating)
        {
            timelapsed += Time.deltaTime;

            currentAngle = Mathf.Lerp(startAngle, targetAngle, timelapsed * speed / totalRotation);

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

        // Ensure final rotation matches the target angle
       
    }
}
