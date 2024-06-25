using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{
    public MeshRenderer visibilty;
    public float GlicthInterval;
    public float GlicthInterval2;
    public float GlicthInterval3;
    public float GlitchDuration;
    public float GlitchDuration2;
    public float GlitchDuration3;
    public bool isGlitch;
    public bool stopGlitch;
    // Start is called before the first frame update
    void Start()
    {
        if(visibilty == null)
        {
            visibilty = GetComponent<MeshRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGlitch)
        {
            StartCoroutine(Glitchy());
        }

        if (stopGlitch) { StopAllCoroutines(); }

        
    }

    private IEnumerator Glitchy()
    {
        isGlitch = true;
        float elapsetime = 0;

        while (elapsetime < GlitchDuration)
        {
            visibilty.enabled = !visibilty.enabled;
            yield return new WaitForSeconds(GlicthInterval);

            elapsetime += GlicthInterval;
        }

        while (elapsetime < GlitchDuration2)
        {
            visibilty.enabled = !visibilty.enabled;
            yield return new WaitForSeconds(GlicthInterval2);

            elapsetime += GlicthInterval;
        }

        while (elapsetime < GlitchDuration3)
        {
            visibilty.enabled = !visibilty.enabled;
            yield return new WaitForSeconds(GlicthInterval3);

            elapsetime += GlicthInterval;
        }

        visibilty.enabled = false;
        isGlitch=false;
        stopGlitch = true;
    }
}
