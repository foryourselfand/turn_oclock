using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Arrow arrow;
    public GameObject dot;

    private GameState gameState;
    
    enum GameState
    {
        START,
        PLAYING
    }

    void Start()
    {
        gameState = GameState.START;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (gameState)
            {
                case GameState.START:
                    arrow.TurnRight();
                    gameState = GameState.PLAYING;
                    Instantiate(dot, arrow.transform.position, Quaternion.Euler(0, 0, getRandomAngle() * arrow.GetDirection()));
                    break;
                case GameState.PLAYING:
                    Debug.Log(arrow.transform.rotation.eulerAngles.z.ToString());
                    Debug.Log(dot.transform.rotation.z.ToString());
                    break;
            }
        }
    }

    private int getRandomAngle()
    {
        return 45;
    }
}