using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBread : MonoBehaviour
{
    private int HowManyBreadsHaveYouEatenInYourLife;

    public Text t;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bread")
        {
            Destroy(collision.gameObject);
            HowManyBreadsHaveYouEatenInYourLife++;
            t.text = HowManyBreadsHaveYouEatenInYourLife.ToString();
        }
    }

}
