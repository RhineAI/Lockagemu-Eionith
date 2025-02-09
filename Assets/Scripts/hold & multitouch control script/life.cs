using UnityEngine;

public class life : MonoBehaviour
{
    public float time;

    public bool system, thefalser, touchsys;

    public GameObject falser, lane;

    public Transform selfpos;

    //public spam Spam;
    // Start is called before the first frame update
    void Start()
    {
        //falser.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //falser.transform.position = transform.position;
        if(system)
        {
            //Destroy(gameObject, time);
        }
        if(thefalser)
        {
            Destroy(gameObject, time);
        }
        
    }

    public void flick()
    {
        if(lane!=null)
        {
            lane.GetComponent<JudgementSCR>().flicker();
        }
        
    }
    public void ended()
    {
        spam.Spam.hasTap.Remove(gameObject);
        if(lane!=null)
        {
            Instantiate(falser, lane.transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(touchsys)
        {
            if(collision.collider.CompareTag("judgement"))
            {
                lane = collision.gameObject;
            }
        }
    }
}
