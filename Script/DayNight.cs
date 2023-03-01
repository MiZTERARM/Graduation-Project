using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNight : MonoBehaviour
{
    public Light2D sun;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Sunset());
    }

    IEnumerator Sunset()
    {
        while(sun.intensity > 0.4f)
        {
            sun.intensity -= 0.00001f;
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(Sunrise());
        StopCoroutine(Sunset());
    }

    IEnumerator Sunrise()
    {
        while(sun.intensity < 1f)
        {
            sun.intensity += 0.00001f;
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(Sunset());
        StopCoroutine(Sunrise());
    }

}
