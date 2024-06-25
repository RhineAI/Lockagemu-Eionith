using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideflicknote : MonoBehaviour
{
    public float speed_rotation_impact;
    public float duration_impact;
    public static sideflicknote flickscr;

    public GameObject
        VFX, judge2;

    public Transform selfpos, canvas_vfx;

    // Start is called before the first frame update
    void Start()
    {
        selfpos = transform;
        judge2 = GameObject.Find("Judgement 2");
        GameObject canvasfx = GameObject.Find("vfx spawn");
        if (canvasfx != null) { canvas_vfx = canvasfx.transform; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("judgeline"))
        {
            gameObject.SetActive(false);
            float poz = selfpos.transform.position.z;
            Vector3 selfposreal = new Vector3(selfpos.transform.position.x, selfpos.transform.position.y, judge2.transform.position.z);
            //vfxscr.vfxspawn();
            //VFX.SetActive(true);
            //gameObject.SetActive(false);
            Instantiate(VFX, selfposreal, selfpos.rotation, canvas_vfx);
            //VFX.GetComponent<VideoPlayer>().Play();
            //Renderer rend = GetComponent<Renderer>();
            //Material material = rend.material;
            //rend
            //Invoke("vfx", 0.1f);


        }
    }
}
