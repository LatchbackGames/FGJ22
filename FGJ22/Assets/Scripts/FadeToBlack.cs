using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    public FadeBlack fadeBlack;
    private const float fadeTime = 3f;
    private float timeFaded = 0;
    [SerializeField]
    private SpriteRenderer sprite1;
    [SerializeField]
    private SpriteRenderer sprite2;
    
    // Start is called before the first frame update
    void Start()
    {
        sprite1.enabled = true;
        sprite2.enabled = true;
        fadeBlack = FadeBlack.From;
    }

    // Update is called once per frame
    void Update()
    {
        switch (fadeBlack)
        {
            case FadeBlack.Stay:
                return;
                break;
            case FadeBlack.To:
                Debug.Log("Fading to black");
                timeFaded += Time.deltaTime;
                var toColor = sprite1.color;
                toColor.a = Mathf.Lerp(0, 1, timeFaded / fadeTime);
                sprite1.color = toColor;
                sprite2.color = toColor;
                Debug.Log(toColor.a+", time: "+timeFaded);
                if (toColor.a < 1)
                    return;
                fadeBlack = FadeBlack.Stay;
                timeFaded = 0;
                
                break;
            case FadeBlack.From:
                timeFaded += Time.deltaTime;
                var color = sprite1.color;
                color.a = Mathf.Lerp(1, 0, timeFaded / fadeTime);
                sprite1.color = color;
                sprite2.color = color;
                if (color.a > 0)
                    return;
                fadeBlack = FadeBlack.Stay;
                timeFaded = 0;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }     
    }
}

public enum FadeBlack
{
    Stay,
    To,
    From
}