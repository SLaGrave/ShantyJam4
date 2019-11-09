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

    void OnCollisionEnter(Collision collision)
    {
        //if hitting the floor
        if (collision.gameObject.tag == "ground")
        {
            //do not lmao
            iscol = true;
            vvel = 0f;
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

        // Movement
        forward = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
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
    }
}
