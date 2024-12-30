using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class givelife : MonoBehaviour
{
    public bool gift;

    public bool take;

    public int jumlahnote;

    public placednote[] script;

    //public List <> scripto;

    public int allnote;

    public float myfloat;

    public string listo;

    public bool giveme;

    public Transform[] allchart;

    //public BoxCollider [] box;

    // Start is called before the first frame update
    void Start()
    {
        script = GetComponentsInChildren<placednote>();
        listo = script.ToString();
        //box = GetComponentsInChildren<BoxCollider>();
        //allnote = gameObject.GetComponentsInChildren<>
        //allnote = GetComponentsInChildren();
        //allnote.CompareTo();


        //int.Parse(listo);
        allchart = transform.GetComponentsInChildren<Transform>();
        for (allnote = 0; allnote < allchart.Length; allnote++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(giveme)
        {
            //("menyala", 5);
            if (Input.GetKeyDown(KeyCode.P))
            {
                /*gameObject.GetComponent<followrutev2>().enabled = true;*/
            }
        }
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

    /*void menyala()
    {
        gameObject.GetComponent<followrutev2>().enabled = true;
    }*/

    
}
