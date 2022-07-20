using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loadings : MonoBehaviour
{
    public int SceneId;
    public Slider slider;


    private void Start()
    {
        StartCoroutine(load());
    }
    IEnumerator load()
    {


        AsyncOperation oper = SceneManager.LoadSceneAsync(SceneId);
        while (!oper.isDone)
        {
            float progress = oper.progress / 0.9f;
            slider.value = progress;
            yield return null;
        }
    }
}
