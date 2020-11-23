using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.scripts
{
class effectToggle : MonoBehaviour
{
        public lvl3 lvl;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            lvl.efct = true;
        }
    }
}
}

