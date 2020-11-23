using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class onLevelComplete : MonoBehaviour
{
    public deathEffect death;
    public Animator animator;
    public int wait;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            levelComplete();
        }
    }

    void levelComplete()
    {
        int level = PlayerPrefs.GetInt("level");
        level++;
        PlayerPrefs.SetInt("level", level);
        death.nextLevel(animator, wait);
    }
}
