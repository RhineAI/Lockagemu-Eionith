using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spam1 : MonoBehaviour

{
    public GameObject sampel;
    public GameObject sampel2;
    public List<touchlocate> touches = new List<touchlocate>();
    public List<realsecontrol> touchesr = new List<realsecontrol>();
    public Camera realCam;
    public int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Camera.main = realCam;
        float mousey = Input.mousePosition.y;
        float mousex = Input.mousePosition.x;
        Vector2 mouseposy = realCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseposx = realCam.ScreenToWorldPoint(Input.mousePosition);
        //sampel2 = Resources.Load("cancler") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //float mousey = Input.mousePosition.y;
        //float mousex = Input.mousePosition.x;
        /*Vector2 mousey = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousex = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 6f));
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(sampel, mousepos, Quaternion.identity);
            
        }

        if(Input.GetMouseButtonUp(0))
        {
            
            Instantiate(sampel2, mousepos, Quaternion.identity);
            
        }

        /*if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchpos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 5f));

            if(touch.phase == TouchPhase.Began)
            {
                Instantiate(sampel, touchpos, Quaternion.identity);
            }
        }*/

        //int i = 0;
        while(i < Input.touchCount)
        {
            Touch touch = Input.GetTouch(i);
            Touch touch2 = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("touched" + i);
                touches.Add(new touchlocate(touch.fingerId, null));

            }

            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("release" + i);
                touchesr.Add(new realsecontrol(touch2.fingerId, null));
                //sampel2 = Resources.Load("cancler") as GameObject;
                // Debug.Log("release");
                //touchesr.Add(new realsecontrol(touch2.fingerId, create2(touch2)));
                touchlocate thistouch = touches.Find(touchlocate => touchlocate.touchid == touch.fingerId);
                //realsecontrol thistouchr = touchesr.Find(realsecontrol => realsecontrol.touchrel == touch2.fingerId);
                Destroy(thistouch.sampel);
                //Instantiate(thistouch.sampel2);
                touches.RemoveAt(touches.IndexOf(thistouch));
                //touchesr.RemoveAt(touchesr.IndexOf(thistouchr));


            }

            if (touch.phase == TouchPhase.Moved)
            {
                //Debug.Log("moving");
                touchlocate thistouch = touches.Find(touchlocate => touchlocate.touchid == touch.fingerId);
                Debug.Log("touched" + i);
                //thistouch.sampel.transform.position = gettouchposition(touch.position);
                //realsecontrol thistouchr = touchesr.Find(realsecontrol => realsecontrol.touchrel == touch2.fingerId);
                //thistouchr.sampel2.transform.position = gettouchposition2(touch2.position);
            }
            ++i;
        }

    }
    Vector3 gettouchposition(Vector3 touchposition)
    {
        return realCam.ScreenToWorldPoint(new Vector3(touchposition.x, touchposition.y, 6f));
    }

    Vector3 gettouchposition2(Vector3 touchposition2)
    {
        return realCam.ScreenToWorldPoint(new Vector3(touchposition2.x, touchposition2.y, 6f));
    }

    private GameObject create(Touch touch)
    {
        GameObject c = Instantiate(sampel) as GameObject;
        c.name = "touch" + touch.fingerId;
        c.transform.position = gettouchposition(touch.position);
        return c;
    }



    private GameObject create2(Touch touch2)
    {
        GameObject d = Instantiate(sampel2) as GameObject;
        d.name = "touch" + touch2.fingerId;
        d.transform.position = gettouchposition2(touch2.position);
        return d;
    }
}
