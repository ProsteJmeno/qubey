using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class deathEffect : MonoBehaviour
{

    public void restartLevel(AudioSource boom, Animator animator, int wait)
    {
        animator.SetTrigger("animationFinished");
        boom.Play();
        StartCoroutine(RestartScene(wait));
    }

    public void nextLevel(Animator animator, int wait)
    {
        animator.SetTrigger("changeScene");
        StartCoroutine(nextScene(wait));
    }

    public GameObject[] levelPrefabs;

    private void StartLevel()
    {
        var levelId = PlayerPrefs.GetInt("CurrentLevelId"); // levelId = 5
        var level = Instantiate(levelPrefabs[id]);
        level.GetComponentInChildren
    }

    private IEnumerator RestartScene(int wait)
    {
        yield return new WaitForSeconds(wait);

        var gameObjectName = gameObject.transform.parent.name;

        var id = PlayerPrefs.GetInt("CurrentLevel");
        var level = Instantiate(levels[id]);
        gameObject.transform.root
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "level1")
        {
            PlayerPrefs.SetInt("hintComplete", 1);
        }
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    private IEnumerator nextScene(int wait)
    {
        yield return new WaitForSeconds(wait);

        if (PlayerPrefs.HasKey("level"))
        {
            SceneManager.LoadScene("level" + PlayerPrefs.GetInt("level"));
        }
        else
        {
            PlayerPrefs.SetInt("level", 1);
            SceneManager.LoadScene("level" + PlayerPrefs.GetInt("level"));
        }
    }
}
