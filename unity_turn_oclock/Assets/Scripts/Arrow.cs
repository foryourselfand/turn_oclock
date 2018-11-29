using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 60;
    private int direction = 1;

    // Use this for initialization
    void Start()
    {
        direction = -1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed * direction));
    }
}