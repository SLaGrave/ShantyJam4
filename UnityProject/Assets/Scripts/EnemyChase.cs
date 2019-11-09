using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public GameObject player;
    public float speed = 1.0f;

    // Update is called once per frame
    void Update()
    {

        // Move our position a step closer to the target.
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

        if (Vector3.Distance(transform.position, player.transform.position) < 0.001f)
        {
            // TODO: Call the player's death function
        }

        
    }
}
