using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_VFX_Controller : MonoBehaviour
{


    
    public bool ball_received=false;
    public Color startColor = new Color(255,0,249);
    public Color endColor = new Color(0, 218, 255);

    public ParticleSystem particleSystem;
    private ParticleSystem.MainModule mainModule;
    private ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule;
    private ParticleSystem.TrailModule trailModule;

    void Start()
    {
        mainModule = particleSystem.main;
        colorOverLifetimeModule = particleSystem.colorOverLifetime;
        trailModule = particleSystem.trails;

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void SetTrailColors(Color start_color,Color end_color)
    {


       // mainModule.startColor = gradient;

        GradientColorKey[] colorKeys;
        colorKeys = new GradientColorKey[2];
        colorKeys[0] = new GradientColorKey(start_color, 0f);
        colorKeys[1] = new GradientColorKey(end_color, 1f);
        trailModule.colorOverLifetime = CreateGradientWithColorKeys(colorKeys);

    }
    private Gradient CreateGradientWithColorKeys(GradientColorKey[] colorKeys)
    {
        ParticleSystem.MinMaxGradient minMaxGradient = new ParticleSystem.MinMaxGradient();
        Gradient gradient = new Gradient();
        gradient.SetKeys(colorKeys, particleSystem.colorOverLifetime.color.gradient.alphaKeys);
        return gradient;
    }
    public void Waiting_Status(Color startcolor,Color endcolor)
    {
        SetTrailColors(startcolor, endcolor);

    }

    public void Reset_status()
    {

        SetTrailColors(startColor, endColor);


    }
}
