using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    private int direction;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (direction == 0)
                direction = -1;
            else
                direction = -direction;
        }

        transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed * direction));
    }
}