using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    private int direction;

    void Start()
    {
    }

    public void TurnAround()
    {
        direction = -direction;
    }

    public void TurnRight()
    {
        direction = -1;
    }

    public void TurnLeft()
    {
        direction = 1;
    }

    public int GetDirection()
    {
        return direction;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed * direction));
    }
}