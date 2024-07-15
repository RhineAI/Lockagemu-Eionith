using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionissue : MonoBehaviour
{
    public float timelapsed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timelapsed += Time.deltaTime;

        if(timelapsed > 32)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 17, gameObject.transform.position.z);
        }

        if (timelapsed > 54)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 17.1f, gameObject.transform.position.z);
        }

        if (timelapsed > 59)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 17.2f, gameObject.transform.position.z);
        }
    }
}
