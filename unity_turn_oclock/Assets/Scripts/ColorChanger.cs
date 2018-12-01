using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Camera camera;

    public Color[] colors = new Color[3];
    public Color loseColor;

    private Color previousColor;


    void Start()
    {
        camera = GetComponent<Camera>();
        SetNewColor();
    }

    public void SetPreviousColor()
    {
        camera.backgroundColor = previousColor;
    }

    public void SetNewColor()
    {
        Color newColor;
        do
        {
            newColor = colors[Random.Range(0, colors.Length)];
        } while (newColor == previousColor);

        previousColor = newColor;
        SetPreviousColor();
    }

    public void SetLoseColor()
    {
        camera.backgroundColor = loseColor;
    }
}