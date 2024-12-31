using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdnotefadeout : MonoBehaviour
{
    public GameObject judgement;
    public bool fading_out;
    public float timer;
    public float outrender;
    public float view;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fading_out)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                float currentsize = gameObject.transform.localScale.z;
                timer = Time.time;
                outrender = gameObject.GetComponent<chartbpm>().bpm * -1;
                float outro = (Time.time - timer) * outrender;
                transform.localScale = new Vector3(1, 1, currentsize - outro);
                view = outro;
            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject ==  judgement)
        {
            fading_out = true;
        }
    }
}
