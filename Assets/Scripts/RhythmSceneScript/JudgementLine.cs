using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgementLine : MonoBehaviour
{
    public GameObject self;
    public static JudgementLine instance;
    public float judgementZPosition;

    void Start()
    {
        instance = this;
        judgementZPosition = self.transform.position.z;
    }
}
