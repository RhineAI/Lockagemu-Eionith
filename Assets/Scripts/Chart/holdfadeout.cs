using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdfadeout : MonoBehaviour
{
    public float fadespeed;
    public bool collide;
    public GameObject selfparent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fadespeed = gameObject.GetComponent<chartbpm>().bpm/7;
        if(collide)
        {
            Vector3 scale = selfparent.transform.localScale;
            scale.z = Mathf.Lerp(scale.z, 0, fadespeed*Time.deltaTime);
            selfparent.transform.localScale = scale;

            if(Mathf.Abs(selfparent.transform.localScale.z) < 0.01f)
            {
                Vector3 finalscale = selfparent.transform.localScale;
                finalscale.z = 0;
                selfparent.transform.localScale = finalscale;
                //selfparent.transform.localScale = Vector3.zero;
                collide = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collide = true;
    }
}
