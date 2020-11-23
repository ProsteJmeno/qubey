using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float xOffset;
    public float jump;
    public int col;


    // Update is called once per frame
    void Update()
    {
        Rigidbody player = gameObject.GetComponent<Rigidbody>();
        player.velocity = new Vector3(Input.GetAxis("horizontal") * xOffset, player.velocity.y, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (col == 1)
            {
                player.velocity = new Vector3(player.velocity.x, jump, 0);

                
            }
            
        }
        col = 0;
    }
    private void OnCollisionStay(Collision collision)
    {
        col = 1;
    }

    //bool isGrounded()
    //{
    //    return Physics.Linecast(transform.position, transform.position + Vector3.down * 1.01f);
    //}
}
