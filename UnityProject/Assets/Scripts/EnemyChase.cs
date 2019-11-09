using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public GameObject player;
    public float speed = 2.0f;

    public RuntimeAnimatorController animWalk;
    public RuntimeAnimatorController animEat;

    // Update is called once per frame
    void Update()
    {

        // Move our position a step closer to the target.
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

        transform.LookAt(player.transform);

        int layermask = 1 << 8;
        layermask = ~layermask;

        var dist = Vector3.Distance(transform.position, player.transform.position);

        if (dist > 15f && Physics.Linecast(transform.position, player.transform.position, layermask))
        {
            transform.position = player.transform.position - (player.transform.forward * 7f);
            AudioSource audioData;
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
        }

        if (dist < 7)
        {
            this.GetComponentInChildren<Animator>().runtimeAnimatorController = animEat as RuntimeAnimatorController;
        }
        else
        {
            this.GetComponentInChildren<Animator>().runtimeAnimatorController = animWalk as RuntimeAnimatorController;
        }

        if (dist < 1.5f)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }

        
    }
}
