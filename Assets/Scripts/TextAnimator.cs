using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextAnimator : MonoBehaviour
{
    [HideInInspector] public string Text;

    [SerializeField] private float timePerCharacter = 0.05f;
    [SerializeField] private TextAnimator nextAnimation = null;
    [SerializeField] private ImageBlinker nextCaret = null;
    [SerializeField] private AudioSource keyboardSound = null;

    private TextMeshProUGUI textMeshPro;
    private float timer;
    private int charIndex = 0;

    private bool nextAnimationEnabled;
    private bool caretEnabled;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (charIndex >= Text.Length)
        {
            if (nextAnimation != null
                && !nextAnimationEnabled)
            {
                nextAnimation.enabled = true;
                nextAnimationEnabled = true;
            }

            if (nextCaret != null
                && !caretEnabled)
            {
                nextCaret.enabled = true;
                nextCaret.IsActive = true;
                caretEnabled = true;
                keyboardSound.Stop();
            }

            return;
        }

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer += timePerCharacter;
            textMeshPro.text += Text[charIndex];
            
            charIndex++;
        }
    }
}
