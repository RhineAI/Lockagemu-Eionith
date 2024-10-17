using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayplacenote : MonoBehaviour
{
    public Camera cam1;
    public Camera camview;
    public GameObject prePlace;
    private float haveInstans;
    public GameObject prePlaceNote;
    public GameObject currentLane;

    public GameObject mainCommand_sync;

    private Vector3 MoveMouseOffset;

    // Start is called before the first frame update
    void Start()
    {
        haveInstans = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(prePlace != null)
        {
            Color color = prePlace.GetComponent<Renderer>().sharedMaterial.color;
            color.a = 0.5f;
            prePlace.GetComponent<Renderer>().sharedMaterial.color = color;
        }
        
        if (mainCommand_sync.GetComponent<commandcontrol>().Tap == true)
        {
            prePlace = mainCommand_sync.GetComponent<commandcontrol>().TapNote;
        }
        if (mainCommand_sync.GetComponent<commandcontrol>().Hold == true)
        {
            prePlace = mainCommand_sync.GetComponent<commandcontrol>().HoldNote;
        }
        if (mainCommand_sync.GetComponent<commandcontrol>().flick == true)
        {
            prePlace = mainCommand_sync.GetComponent<commandcontrol>().FlickNote;
        }
        if (mainCommand_sync.GetComponent<commandcontrol>().sideflick == true)
        {
            prePlace = mainCommand_sync.GetComponent<commandcontrol>().SideFlickNote;
        }
        if (mainCommand_sync.GetComponent<commandcontrol>().slide == true)
        {
            prePlace = mainCommand_sync.GetComponent<commandcontrol>().SlideNote;
        }

        Vector3 mousePos = Input.mousePosition;
        //Vector3 viewportPosition = camview.ScreenToViewportPoint(mousePos);

        if (MouseCoordinate(camview, mousePos))
        {
            
            Ray ray = camview.ScreenPointToRay(mousePos);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (currentLane != null)
                {
                    if (currentLane != hit.collider.gameObject)
                    {
                        Destroy(prePlaceNote);
                        haveInstans = 0;
                        if (haveInstans == 0)
                        {
                            //Vector3 spawnPos = camview.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, camview.nearClipPlane));
                            //prePlaceNote = Instantiate(prePlace, spawnPos, Quaternion.identity);
                            //haveInstans = 1;
                            prePlaceNote = Instantiate(prePlace, hit.transform.position, Quaternion.identity);
                            haveInstans = 1;

                        }
                        currentLane = hit.collider.gameObject;

                    }


                }
                else
                {
                    if (haveInstans == 0)
                    {
                        prePlaceNote = Instantiate(prePlace, hit.transform.position, Quaternion.identity);
                        haveInstans = 1;
                    }
                    currentLane = hit.collider.gameObject;
                }

                //Debug.Log(hit.collider.name);
                //prePlace = hit.collider.transform.parent.gameObject;



            }

            /*if (prePlaceNote != null)
            {
                Vector3 followMousePos = camview.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, camview.nearClipPlane));
                prePlaceNote.transform.position = new Vector3(followMousePos.x, hit.transform.position.y, -prePlaceNote.transform.position.z);
            }*/

            else
            {
                currentLane = null;
                Destroy(prePlaceNote);
                haveInstans = 0;
            }
        }
        else
        {
            currentLane = null;
            Destroy(prePlaceNote);
            haveInstans = 0;
        }


    }

    bool MouseCoordinate(Camera cam2, Vector3 mousePos)
    {
        Vector3 POV = cam2.ScreenToViewportPoint(mousePos);
        return POV.x >= 0 && POV.x <= 1 && POV.y >= 0 && POV.y <= 1;
    }
}
