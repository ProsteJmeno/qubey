using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class intro : MonoBehaviour
{
    GameObject varGO;
    public cameraControl control;
    public Vector3 newOffset;
    public PostProcessProfile newProfile;
    public PostProcessVolume volume;
    public GameObject[] moveControls;
    public KeyCode[] codes;
    bool controlsEnabled = false;

    public bool[] keysDown;

    private void Awake()
    {
        if (!(PlayerPrefs.HasKey("hintComplete")))
        {
            varGO = GameObject.Find("player");
            varGO.GetComponent<playerMove>().enabled = false;
            disableControls();
        }
        
    }

    public void introStart()
    {
        varGO.GetComponent<playerMove>().enabled = true;
        control.resetOffset(newOffset);
        volume.profile = newProfile;
        enableControls();
    }

    public void introStartFixed()
    {
        control.resetOffset(newOffset);
        volume.profile = newProfile;
    }

    void enableControls()
    {
        foreach(GameObject ob in moveControls)
        {
            ob.SetActive(true);
        }
        controlsEnabled = true;
    }

    public void disableControls()
    {
        foreach (GameObject ob in moveControls)
        {
            ob.SetActive(false);
        }
        controlsEnabled = false;
    }

    private void Update()
    {
        if (controlsEnabled)
        {
            for (int i = 0; i < codes.Length; i++)
            {
                if (Input.GetKeyDown(codes[i]))
                {
                    keysDown[i] = true;
                }
            }
        }
        
    }
}
