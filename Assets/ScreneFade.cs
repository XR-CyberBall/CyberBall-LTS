using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreneFade : MonoBehaviour
{
    public float fadeduration = 2;
    public Color fadecolor;
    private Renderer render;

    public bool FadeOnStart = true;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        if (FadeOnStart)
            fadeIn();
             
    }

    // Update is called once per frame
    public void Fade(float AlphaIn, float AlphaOut) {
        gameObject.SetActive(true);

        StartCoroutine(FadeRoutine(AlphaIn,AlphaOut));

    }
    public void fadeIn()
    {
        Fade(1, 0);
    }
    public void fadeOut()
    {
        Fade(0, 1);
    }
    public IEnumerator FadeRoutine(float AlphaIn, float AlphaOut)
    {

        gameObject.SetActive(true);

        float timer = 0;
        while (timer <= fadeduration)
        {
            Color newColor = fadecolor;
            newColor.a = Mathf.Lerp(AlphaIn, AlphaOut, timer / fadeduration);
            render.material.SetColor("_Color", newColor);
            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadecolor;
        newColor2.a = AlphaOut;
        render.material.SetColor("_Color", newColor2);
        timer += Time.deltaTime;

        gameObject.SetActive(false);
    }
    public void Update()
    {
    
    }
}
