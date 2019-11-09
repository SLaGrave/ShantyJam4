using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLight : MonoBehaviour
{
    private bool on = false;

    // Update is called once per frame
    void Update()
    {
        var q = HSRandom.Next(10);
        if(q==0)
        {
            on = !on;
        }

        if(on)
        {
            GetComponent<Light>().intensity = 7;
        }
        else
        {
            GetComponent<Light>().intensity = 0;
        }
    }
}
