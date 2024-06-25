using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vfx_instans : MonoBehaviour
{
    public GameObject vfx_image;
    public Canvas canvas;
    public Camera maincamera;
    public GameObject transform_target;
    public GameObject transform_update;
    //public Vector3 fix_position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //fix_position = transform_target.transform.position;
    }
    public void vfxspawn()
    {
        /*/float zaxis = transform_target.transform.position.z;
        //Vector3 world3dposition = transform_target.transform.position;
        //world3dposition = new Vector3(transform_target.transform.position.x, transform_target.transform.position.y, transform_target.transform.position.z - zaxis);
        //Quaternion world3drotation = transform_target.transform.rotation;
        Vector3 screen2dposition = maincamera.WorldToScreenPoint(world3dposition);
        //Quaternion screen2drotation = maincamera.worl(world3drotation);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
            screen2dposition, canvas.worldCamera, out Vector2 localPoint);*/

        GameObject vfxImage = Instantiate(vfx_image, canvas.transform);


        RectTransform rectTransform = vfxImage.GetComponent<RectTransform>();
        /*rectTransform.localPosition = localPoint;*/

        float Z_rota_update = transform_update.transform.rotation.eulerAngles.z;
        Quaternion worldrotation = transform_target.transform.rotation;
        //worldrotation = new Quaternion(transform_target.transform.rotation.x, transform_target.transform.rotation.y, transform_target.transform.rotation.z + Z_rota_update);
        rectTransform.localRotation = Quaternion.Euler(0, 0, -worldrotation.eulerAngles.z);

    }
}
