using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savegiftpos : MonoBehaviour
{
    public GameObject cube;
    public bool cubes;
    public bool block;
    public bool bring;
    public bool gift;
    // Start is called before the first frame update
    void Start()
    {
        bring = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        var type = "";
        var pos_timing = "";
        var pos_lane ="";
        if (bring)
        {
            if (cube != null)
            {
                cubes = true;
                Destroy(cube);
            }
            if (cubes)
            {
                type = cube.ToString();
                pos_timing = cube.transform.position.z.ToString();
                pos_lane = cube.transform.position.x.ToString();
                Debug.Log(type + pos_timing + pos_lane);
                Debug.Log("data saved");
                gift = true;
                cubes = false;
                bring = false;
            }
        }

        else if (gift)
        {
            if(cube != null)
            {
                float timing = float.Parse(pos_timing);
                float lane = float.Parse(pos_lane);
                //var pos_z = cube.transform.position.z;
                //var pos_x = cube.transform.position.x;
                Vector3 position = new Vector3(lane, 0, timing);
                cube.transform.position = position;
                if (type == "cube")
                {
                    GameObject newcube = Instantiate(cube, position, Quaternion.identity);
                }

                
            }
        }

    }
}
