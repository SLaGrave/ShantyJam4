using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBread : MonoBehaviour
{
    public int HowManyBreadsHaveYouEatenInYourLife;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bread")
        {
            Destroy(collision.gameObject);
            HowManyBreadsHaveYouEatenInYourLife++;
        }
    }

}
