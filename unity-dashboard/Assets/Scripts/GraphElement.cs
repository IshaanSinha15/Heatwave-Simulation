using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class GraphElement : VisualElement
{
    List<float> temp = new List<float>();
    List<float> heart = new List<float>();

    const int maxPoints = 120;

    public GraphElement()
    {
        generateVisualContent += DrawGraph;
    }

    public void AddPoint(float t, float h)
    {
        temp.Add(t);
        heart.Add(h);

        if (temp.Count > maxPoints)
        {
            temp.RemoveAt(0);
            heart.RemoveAt(0);
        }

        MarkDirtyRepaint();
    }

    void DrawGraph(MeshGenerationContext ctx)
    {
        var painter = ctx.painter2D;

        float width = contentRect.width;
        float height = contentRect.height;

        if (temp.Count < 2)
            return;

        float step = width / maxPoints;

        painter.lineWidth = 2;

        painter.strokeColor = Color.red;

        for (int i = 1; i < temp.Count; i++)
        {
            float y1 = Mathf.InverseLerp(35, 41, temp[i - 1]) * height;
            float y2 = Mathf.InverseLerp(35, 41, temp[i]) * height;

            painter.BeginPath();
            painter.MoveTo(new Vector2((i - 1) * step, height - y1));
            painter.LineTo(new Vector2(i * step, height - y2));
            painter.Stroke();
        }

        painter.strokeColor = Color.green;

        for (int i = 1; i < heart.Count; i++)
        {
            float y1 = Mathf.InverseLerp(40, 180, heart[i - 1]) * height;
            float y2 = Mathf.InverseLerp(40, 180, heart[i]) * height;

            painter.BeginPath();
            painter.MoveTo(new Vector2((i - 1) * step, height - y1));
            painter.LineTo(new Vector2(i * step, height - y2));
            painter.Stroke();
        }
    }
}