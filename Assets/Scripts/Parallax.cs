using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : TI3NMono
{
    private Material material;
    [SerializeField] private float parallaxFactor = 0.01f;
    [SerializeField] private float offset;
    //private bool isDelayed = true;
    //private float delayTimer = 0f;
    private bool shouldDelay = true;
    void Start()
    {
        material = GetComponent<Renderer>().material;
        GameManager.OnGameStarted += HandleGameStarted;
    }
    void Update()
    {
        //if (SkipParallaxScroll()) return;
        if (shouldDelay) return;
        ParallaxScroll();
    }
    private void OnDestroy()
    {
        GameManager.OnGameStarted -= HandleGameStarted;
    }
    protected virtual void HandleGameStarted()
    {
        StartCoroutine(DelayParallaxStart());
    }
    protected IEnumerator DelayParallaxStart()//trì hoãn parallax
    {
        yield return new WaitForSecondsRealtime(0.5f);
        shouldDelay = false;
    }
    //protected virtual bool SkipParallaxScroll()
    //{
    //    if (!this.isDelayed) return false;

    //    delayTimer += Time.unscaledDeltaTime;

    //    if (delayTimer >= 1f) 
    //    { 
    //        isDelayed = false; 
    //    }
    //    return true;
    //}
    private void ParallaxScroll()
    {
        float speed = GameManager.Instance.GetGameSpeed() * parallaxFactor;
        offset += Time.deltaTime * speed;
        material.SetTextureOffset("_MainTex", Vector2.right * offset);
    }
}
