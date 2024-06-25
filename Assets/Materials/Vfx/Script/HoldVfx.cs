using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldVfx : MonoBehaviour
{
    public GameObject myhold;
    public GameObject Vfx_Anchor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(myhold.GetComponent<HoldTrialScr>().endhold == true)
        {
            gameObject.GetComponent<Animator>().SetBool("end_hold", true);
        }

       Vfx_Anchor.transform.rotation = myhold.transform.rotation;
       
    }

    
}
