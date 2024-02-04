using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgementLine : MonoBehaviour
{
    public GameObject self;
    private bool canBePressed = false;
    private string type;
    private BoxCollider boxCollider;

    void Start()
    {
        boxCollider = self.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // float transformZAxis = Mathf.Abs(self.transform.position.z);
        // float colliderSize = boxCollider.size.z;
        // float halfColliderSize = colliderSize / 2f;

        // if(type == "Hold" && canBePressed) {
        //     if(halfColliderSize >= 1f && halfColliderSize <= 2f) {
        //         Debug.Log("Critical");
        //     } else if(halfColliderSize >= 0f && halfColliderSize <= 3f) {
        //         Debug.Log("Fair");
        //     } else {
        //         Debug.Log("Error");
        //     }
        // }
        if(canBePressed && type == "Hold") {
            Debug.Log("1");
        }
        
    }

    

}
