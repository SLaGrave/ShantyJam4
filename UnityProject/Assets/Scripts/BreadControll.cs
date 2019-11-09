using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadControll : MonoBehaviour
{
    public GameObject p;

    // Start is called before the first frame update
    void Start()
    {
        for(int j = 0; j < 7; j++)
        {
            int i = HSRandom.Next(20-j);
            var c = transform.GetChild(i);
            Instantiate(p, c.position, c.rotation);
            Destroy(c.gameObject);
        }
    }
}
