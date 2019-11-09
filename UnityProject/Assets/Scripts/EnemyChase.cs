using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    private bool isDone = false;
    public GameObject player;
    public float speed = 2.0f;

    public RuntimeAnimatorController animWalk;
    public RuntimeAnimatorController animEat;

    // Sound stuff
    [Header("Sound Stuff")]
    //public AudioSource teleportSound;
    public AudioSource endGameSound;

    // Update is called once per frame
    void Update()
    {
        if(!isDone)
        {
            // Move our position a step closer to the target.
            float step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

            // Make birb look at the player
            transform.LookAt(player.transform);
        }

        // Layer for the line cast
        int layermask = 1 << 8;
        layermask = ~layermask;

        // Check dist between birb and player
        var dist = Vector3.Distance(transform.position, player.transform.position);

        // Draw the sightline debug
        Debug.DrawLine(transform.position, player.transform.position, Color.red, 0.0f);

        // Teleport the birb if conditions are met
        if (dist > 15f && Physics.Linecast(transform.position, player.transform.position, layermask))
        {
            int q = HSRandom.Next(10);
            if(q==0)
            {
                transform.position = player.transform.position + (player.transform.forward * 7f);
            }
            else
            {
                q = Mathf.Clamp(q, 5, 7);
                transform.position = player.transform.position - (player.transform.forward * q);
            }
        }

        if (dist < 7)
        {
            this.GetComponentInChildren<Animator>().runtimeAnimatorController = animEat as RuntimeAnimatorController;
        }
        else
        {
            this.GetComponentInChildren<Animator>().runtimeAnimatorController = animWalk as RuntimeAnimatorController;
        }

        // End Game
        if (dist < 1.5f)
        {
            if(player.GetComponent<PlayerBread>().HasEnough())
            {
                // Good end
                UnityEditor.EditorApplication.isPlaying = false;
            }
            else
            {
                // Bad end
                isDone = true;
                player.transform.LookAt(transform);
                endGameSound.Play(0);
                StartCoroutine(EndGame());
            }
        }

        IEnumerator EndGame()
        {
            yield return new WaitForSeconds(5);
            UnityEditor.EditorApplication.isPlaying = false;
        }

        
    }
}
