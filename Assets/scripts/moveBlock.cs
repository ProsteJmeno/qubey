using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBlock : MonoBehaviour
{
    bool go;
    public Vector3[] points;
    Vector3 finish;
    public float speed;
    public int wait;
    public int disableWait;
    public GameObject portalToDisable;

    private void Start()
    {
        finish = gameObject.transform.position;
        portalToDisable.SetActive(false);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            finish = points[0];
            go = true;
        }
    }

    private void Update()
    {
        if (go)
        {
            var moveDistance = speed * Time.deltaTime;
            var distance = finish - gameObject.transform.position;
            if (distance.magnitude <= moveDistance)
            {
                if(finish == points[0])
                {
                    go = false;
                    StartCoroutine(waitUntilMove(wait));
                }
                if (finish == points[1])
                {
                    go = false;
                    StartCoroutine(waitThenDisable(disableWait));
                }
            }
            else
            {
                gameObject.transform.position +=  distance.normalized * moveDistance;
            }
            

        }

        IEnumerator waitUntilMove(int wait)
        {
            yield return new WaitForSeconds(wait);
            finish = points[1];
            go = true;
        }

        IEnumerator waitThenDisable(int waitDisable)
        {
            yield return new WaitForSeconds(waitDisable);
            portalToDisable.SetActive(true);
            gameObject.SetActive(false);
        }
            
    }

    private void LateUpdate()
    {
        if(gameObject.transform.position == finish)
        {
            go = false;
        }
    }
}
