using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuSelect : MonoBehaviour
{
    public GameObject play;
    public Animator animator;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == play.name)
        {
            animator.SetTrigger("changeScene");
        }
    }
}
