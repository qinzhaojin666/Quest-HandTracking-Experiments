using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    [SerializeField] GameObject linePrefab;

    private Line activeLine;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject gO = Instantiate(linePrefab);
            activeLine = gO.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePosition);
        }       
    }
}
