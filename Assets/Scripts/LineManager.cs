using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI.Extensions;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(UILineRendererList))]
public class LineManager : MonoBehaviour
{
    [SerializeField] private float spacing = 5f;
    [SerializeField] private float timePerCharacter = 0.05f;

    private RectTransform rectTransform;
    private UILineRendererList lineRenderer;
    private float width;
    private float height;
    private float x;
    private float y;

    private List<LineModel> lines = new List<LineModel>();
    private float timer;
    private int lineIndex = 0;

    private void Start()
    {        
        rectTransform = GetComponent<RectTransform>();
        lineRenderer = GetComponent<UILineRendererList>();

        width = rectTransform.rect.width;
        height = rectTransform.rect.height;

        while (y < height)
        {
            if (Random.Range(0f, 1f) < 0.5f)
            {
                // \
                lines.Add(new LineModel(x, y, x + spacing, y + spacing));
            }
            else
            {
                // /
                lines.Add(new LineModel(x + spacing, y, x, y + spacing));
            }

            x += spacing;
            if (x >= width)
            {
                x = 0;
                y += spacing;
            }
        }
    }

    private void Update()
    {
        if (lineIndex >= lines.Count)
            return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer += timePerCharacter;
            lineRenderer.Points.AddRange(lines[lineIndex].Points);
            lineRenderer.UseNativeSize = !lineRenderer.UseNativeSize;

            lineIndex++;
        }
    }
}
