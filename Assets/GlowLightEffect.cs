using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowLightEffect : MonoBehaviour
{
    // Start is called before the first frame update

    private UnityEngine.Experimental.Rendering.Universal.Light2D lightEffect;
    private float lightIntensity = 0;
    private bool isDecreasing = false;

    void Start()
    {
        lightEffect = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDecreasing)
        {
            lightIntensity -= Time.deltaTime*2;
        }
        else {
            lightIntensity += Time.deltaTime*2;
        }

        if (lightIntensity > 2f) {
            isDecreasing = true;
        }
        else if (lightIntensity < 0f) {
            isDecreasing = false;
        }


        lightEffect.intensity = lightIntensity; 
    }
}
