using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables to be used
    public float speed = 10.0f;
    public float forward;
    public float strafe;
    private float vvel = 0f;
    private bool iscol = true;
    private bool ismov = false;
    private bool isActive = true;

    [Header("Sound Stuff")]
    public AudioSource walksound;

    void OnCollisionEnter(Collision collision)
    {
        //if hitting the floor
        if (collision.gameObject.tag == "ground")
        {
            //do not lmao
            iscol = true;
            vvel = 0f;
        }
        else if(collision.gameObject.tag == "BadBoy")
        {
            isActive = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Turn off cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            bool prevmov = ismov;

            // Movement
            forward = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            ismov = forward != 0 || strafe != 0;

            transform.Translate(strafe, 0, forward);

            if (Input.GetKeyDown("escape"))
            {
                // turn on the cursor
                Cursor.lockState = CursorLockMode.None;
            }
            else if (Input.GetKeyDown("space") && vvel == 0)
            {
                vvel = 0.2f;
                iscol = false;
            }

            if (!iscol)
            {
                //decrease vertical velocity
                vvel -= 0.0075f;
                transform.Translate(0, vvel, 0);
            }

            if (prevmov != ismov && ismov)
                walksound.Play(0);
            else if (prevmov != ismov)
                walksound.Stop();
        }
    }
}
