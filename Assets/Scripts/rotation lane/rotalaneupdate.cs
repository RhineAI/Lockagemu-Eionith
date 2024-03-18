using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class rotalaneupdate : MonoBehaviour
{
    //public Transform lane;
    private float rotationspeed;
    // private float durasi = 1.5f;
    // public Quaternion currentrota;
    // public Quaternion targetrota;
    // public float rotaspeed;
    
    public bool rotate;
    [SerializeField]
    private AnimationCurve curve;

    //part 2
    public float timelapsed;


    //part 4
    [SerializeField]
    [Range (0, 100)]
    private float speed;
    public float rotationTime;
    private float currentAngle = 0f;

    public bool startRotating;
    public bool stopRotating;
    public bool locked;


    [SerializeField]
    private GameObject lane;
    // Start is called before the first frame update
    void Start()
    {
        //currentrota = transform.rotation;
        //StartCoroutine(rotasi());
        timelapsed = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startRotating)
        {
            stopRotating = false;
            StartCoroutine(LerpRotateupdate());
            startRotating = false;
            Debug.Log($"Start : {currentAngle}");
        }

        if(stopRotating) {
            StopCoroutine(LerpRotateupdate());
            lane.transform.eulerAngles = new Vector3(0, 0, currentAngle);
            Debug.Log($"Stop : {currentAngle}");
        }
    }
    private IEnumerator LerpRotateupdate()
    {
        float startAngle = currentAngle;
        float rotationSpeed;
        while (timelapsed < rotationTime && !stopRotating)
        {
            timelapsed += Time.deltaTime;
            
            rotationSpeed = speed * Time.deltaTime;
            startAngle += rotationSpeed;

            lane.transform.rotation = Quaternion.Euler(0, 0, startAngle);
            
            currentAngle = lane.transform.eulerAngles.z;
            yield return null;
        }
        
        // lane.transform.rotation = Quaternion.Euler(0, 0, 360);
    }
}
