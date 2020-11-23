using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class provizorniPPdelete : MonoBehaviour
{
#if UNITY_EDITOR
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();

    }
#endif
}
