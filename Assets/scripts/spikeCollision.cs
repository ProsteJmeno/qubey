using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeCollision : MonoBehaviour
{
    public deathEffect death;
    public AudioSource boom;
    public Animator animator;
    public int wait;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            death.restartLevel(boom, animator, wait);
        }
    }
}
