
using UnityEngine;
using UnityEngine.UI;

public class cameraControl : MonoBehaviour
{
    public Transform target;

    public deathEffect death;
    public Image black;
    public AudioSource boom;
    public Animator animator;
    public int wait;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector3 deathPos;

    private void Update()
    {
        if(target.transform.position.y <= deathPos.y)
        {
            death.restartLevel(boom, animator, wait);
            this.enabled = false;
        }
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }

    

    public void resetOffset(Vector3 newOffset)
    {
        offset = newOffset;
    }
}

