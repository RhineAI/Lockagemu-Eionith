using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotalane : MonoBehaviour
{
    public Transform lane;
    private float rotationspeed;
    private float durasi = 1.5f;
    public Quaternion currentrota;
    public Quaternion targetrota;
    public float rotaspeed;
    
    public bool rotate;
    [SerializeField]
    private AnimationCurve curve;

    //part 2

    public float rotasidurasi;
    public float timeelapsed;

    // Start is called before the first frame update
    void Start()
    {
        //currentrota = transform.rotation;
        //StartCoroutine(rotasi());
        timeelapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //currentrota = transform.rotation;
        if (rotate)
        {
            rotationspeed += Time.deltaTime;
            float percentagecomplete = rotationspeed / durasi;
            currentrota = gameObject.transform.rotation;
            
            if (currentrota == targetrota)
            {
                currentrota = targetrota;
                Debug.Log("rotate");
                rotate = false;
            }
            else
            {
                transform.rotation = Quaternion.Lerp(currentrota, targetrota, rotaspeed * Time.deltaTime);
            }

        }
        
        
    }

    public IEnumerator rotasi()
    {
        
        while(timeelapsed < durasi)
        {
            float t = timeelapsed / durasi;
            transform.rotation = Quaternion.Lerp(currentrota, targetrota, t);
            timeelapsed += Time.deltaTime;
            yield return null;
        }

        currentrota = targetrota;
    }
}
