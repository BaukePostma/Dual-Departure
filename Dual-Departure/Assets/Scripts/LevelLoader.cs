using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    //public Slider slider;

    public Animator transition;
    public float transitionTime =1f;

    public void LoadNextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex +1;
        StartCoroutine(LoadAsync(sceneIndex));
    }

    public void LoadLevel(int index)
    {
        StartCoroutine(LoadAsync(index));
    }
    public void LoadLevel(string name)
    {
        StartCoroutine(LoadAsync(name));
    }

    IEnumerator LoadAsync(int index)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        AsyncOperation op = SceneManager.LoadSceneAsync(index);
   

        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            //slider.value = progress;
            yield return null;
        }
    }

    IEnumerator LoadAsync(string name)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        AsyncOperation op = SceneManager.LoadSceneAsync(name);

        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            //slider.value = progress;
            yield return null;
        }
    }
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetLevel(float delay)
    {
        StartCoroutine(ResetWithDelay(delay));
    }

    private IEnumerator ResetWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
