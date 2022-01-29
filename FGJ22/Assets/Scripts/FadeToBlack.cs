using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    private FadeBlack fadeBlack;
    private const float fadeTime = 3f;
    private float timeFaded = 0;
    [SerializeField]
    private SpriteRenderer sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        sprite.enabled = true;
        fadeBlack = FadeBlack.From;
        Debug.Log(sprite.color.a);
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
                
                break;
            case FadeBlack.From:
                timeFaded += Time.deltaTime;
                var color = sprite.color;
                color.a = Mathf.Lerp(1, 0, timeFaded / fadeTime);
                sprite.color = color;
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