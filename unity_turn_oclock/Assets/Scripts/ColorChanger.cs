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
        setNewColor();
    }

    public void SetPreviousColor()
    {
        camera.backgroundColor = previousColor;
    }

    public void setNewColor()
    {
        Color newColor;
        do
        {
            newColor = colors[Random.Range(0, 3)];
        } while (newColor == previousColor);

        previousColor = newColor;
        SetPreviousColor();
    }

    public void setLoseColor()
    {
        camera.backgroundColor = loseColor;
    }
}