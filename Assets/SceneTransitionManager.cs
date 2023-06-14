using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public ScreneFade fadescrene;
    public static SceneTransitionManager Instance { get; private set; }

    public void GoToScene(int sceneIndex) {
        StartCoroutine(GotoSceneRoutine(sceneIndex));
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public IEnumerator GotoSceneRoutine(int sceneIndex)
    {
        fadescrene.fadeOut();
       AsyncOperation opertaion= SceneManager.LoadSceneAsync(sceneIndex);
        opertaion.allowSceneActivation = false;
        float timer = 0;
        while (timer <= fadescrene.fadeduration & !opertaion.isDone)
        {
            fadescrene.fadeOut();
            timer += Time.deltaTime;
            yield return null;
        }
        opertaion.allowSceneActivation = true;
        
    }
}
