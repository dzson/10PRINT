using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageBlinker : MonoBehaviour
{
    [HideInInspector] public Image Image;
    [HideInInspector] public bool IsActive;

    [SerializeField] private RectTransform target;
    [SerializeField] private float blinkRate = 1f;
    private float blinkTimer;

    private void Start()
    {
        Image = GetComponent<Image>();
    }

    private void Update()
    {
        blinkTimer += Time.deltaTime;
        Image.enabled = (blinkTimer % blinkRate < blinkRate / 2);
    }
}
