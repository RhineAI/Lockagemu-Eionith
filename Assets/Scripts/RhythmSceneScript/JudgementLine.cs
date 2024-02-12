using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgementLine : MonoBehaviour
{
    public GameObject self;
    public static JudgementLine instance;
    public float judgementZPosition;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        judgementZPosition = self.transform.position.z;
    }
}
