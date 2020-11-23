using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public Image[] keys;

    GameObject cam;

    intro intro;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("cam");

        intro = cam.GetComponent<intro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (keys.Length == intro.keysDown.Length)
        {
            for (int i = 0; i < intro.keysDown.Length; i++) {                     
                        if (intro.keysDown[i])
                        {
                            keys[i].color = new Color32(128, 128, 128, 255);
                        }
            }
        }
        else
        {
            Debug.Log("ERROR: Key.keys.Length != intro.keysDown.Length!! ");
        }

        int keysDown = 0;

        for (int i = 0; i < intro.keysDown.Length; i++)
        {
            if (intro.keysDown[i])
            {
                keysDown++;
            }
        }

        if (keysDown == intro.keysDown.Length)
        {
            intro.disableControls();
        }

    }
}
