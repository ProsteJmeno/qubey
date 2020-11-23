using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue : MonoBehaviour
{
    public Text[] texts;
    int index = 0;
    public intro intro;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("hintComplete"))
        {
            foreach(Text text in texts)
            {
                text.enabled = false;
                intro.introStartFixed();
            }
        }
    }

    void Start()
    {

        if (!(PlayerPrefs.HasKey("hintComplete")))
        {
            texts[index].enabled = true;
            for (int i = 1; i < texts.Length; i++)
            {
                texts[i].enabled = false;
            }
        }
        
    }

    void Update()
    {
        if (!(PlayerPrefs.HasKey("hintComplete")))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {                     
                if(!(index >= texts.Length - 1)) {  
                    texts[index].enabled = false;
                    index++;
                    texts[index].enabled = true;
                }
                else
                {
                    texts[index].enabled = false;
                    intro.introStart();
                }
            }
        }
        
    }
}
