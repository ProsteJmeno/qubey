using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadeOut : MonoBehaviour
{
    string sceneToLoad;

    void onAnimationComplete()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            sceneToLoad = "level" + PlayerPrefs.GetInt("level");
        }
        else
        {
            sceneToLoad = "level1";
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}
