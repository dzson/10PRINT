using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] meshes = new TextMeshProUGUI[] { };
    [SerializeField] private Image caret = null;
    [SerializeField] private LineManager lineManager = null;
    [SerializeField] private UILineRendererList lineRenderer = null;
    [SerializeField] private AudioSource enterSound = null;

    private ImageBlinker imageBlinker = null;

    private void Start()
    {
        imageBlinker = caret.GetComponent<ImageBlinker>();

        SetupTextAnimators();
        EnableCaret(false);
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Return))
            return;

        if (!imageBlinker.IsActive)
            return;

        enterSound.Play(0);

        EnableCaret(false);
        lineRenderer.enabled = true;
        lineManager.enabled = true;
    }

    private void SetupTextAnimators()
    {
        foreach (var mesh in meshes)
        {
            var animator = mesh.GetComponent<TextAnimator>();
            if (animator == null)
                continue;

            animator.Text = mesh.text;
            mesh.text = String.Empty;
        }
    }

    private void EnableCaret(bool enabled)
    {
        if (imageBlinker == null)
            return;

        imageBlinker.enabled = enabled;
        imageBlinker.IsActive = enabled;
        caret.enabled = enabled;
    }
}
