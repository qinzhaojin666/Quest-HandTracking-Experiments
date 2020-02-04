using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{        
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;

    private List<Vector2> points;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    public void UpdateLine(Vector2 _mousePosition)
    {
        if(points == null)
        {
            points = new List<Vector2>();
            SetPoint(_mousePosition);
            return;
        }

        if (Vector2.Distance(points.Last(), _mousePosition) > 0.1F)
        {
            SetPoint(_mousePosition);
        }
    }

    // Check if the mouse has moved enough for us to insert new point
    // If it has: Insert point at mouse position

    private void SetPoint(Vector2 _point)
    {
        points.Add(_point);

        lineRenderer.positionCount = points.Count;        

        lineRenderer.SetPosition(points.Count - 1, _point);
        if (points.Count > 1)
        {
            edgeCollider.points = points.ToArray();
        }
    }

          
}
