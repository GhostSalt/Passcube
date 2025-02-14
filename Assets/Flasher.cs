﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flasher : MonoBehaviour
{
    public SpriteRenderer[] Sprites;

    private Coroutine _flashCoroutine;
    private Coroutine _briefFlashCoroutine;

    // Use this for initialization
    void Start()
    {
        ResetAllSprites();
    }

    public void StartFlashing()
    {
        if (_flashCoroutine != null)
            StopCoroutine(_flashCoroutine);
        _flashCoroutine = StartCoroutine(Flash());
    }

    public void StopFlashing()
    {
        if (_flashCoroutine != null)
            StopCoroutine(_flashCoroutine);
        ResetAllSprites();
    }

    private IEnumerator Flash(float holdDur = 0.075f, float interval = 0.035f)
    {
        while (true)
            for (int i = 0; i < Sprites.Length; i++)
            {
                SetSprite(i, true);
                yield return new WaitForSeconds(holdDur);
                SetSprite(i, false);
                yield return new WaitForSeconds(interval);
            }
    }

    private void SetSprite(int ix, bool status)
    {
        Sprites[ix].gameObject.SetActive(status);
    }

    private void ResetAllSprites()
    {
        for (int i = 0; i < Sprites.Length; i++)
            SetSprite(i, false);
    }

    public void BriefFlash()
    {
        if (_briefFlashCoroutine != null)
            StopCoroutine(_briefFlashCoroutine);
        _briefFlashCoroutine = StartCoroutine(HandleBriefFlash());
    }

    private IEnumerator HandleBriefFlash()
    {
        StartFlashing();

        yield return new WaitForSeconds(0.35f);

        StopFlashing();
    }
}
