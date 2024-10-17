using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takelive : MonoBehaviour
{
    public bool gift;

    public bool take;

    public placednote[] script;

    //public BoxCollider [] box;

    // Start is called before the first frame update
    void Start()
    {
        script = GetComponentsInChildren<placednote>();
        //box = GetComponentsInChildren<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gift)
        {
            foreach (placednote scr in script)
            {
                scr.enabled = true;
            }



        }

        if (take)
        {
            foreach (placednote scr in script)
            {
                scr.enabled = false;
            }



        }
        //gameObject.GetComponentInChildren<placednote>().enabled = true;
    }


}
