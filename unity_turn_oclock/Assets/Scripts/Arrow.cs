using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Arrow : MonoBehaviour
{
    public float speed;
    public GameObject dot;

    private int direction;
    private bool isNear, isClicked;
    private GameObject dotToRemove;

    private GameState gameState;

    enum GameState
    {
        START,
        PLAYING,
        OVER
    }

    void Start()
    {
        direction = 0;
        isNear = false;
        isClicked = false;
        gameState = GameState.START;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed * direction));

        if (Input.GetMouseButtonDown(0))
        {
            switch (gameState)
            {
                case GameState.START:
                    direction = -1;
                    gameState = GameState.PLAYING;
                    SpawnNewDot();
                    break;
                case GameState.PLAYING:
                    if (isNear)
                    {
                        direction = -direction;
                        isClicked = true;
                        Destroy(dotToRemove);
                        SpawnNewDot();
                    }
                    else
                    {
                        GameOver();
                    }

                    break;
                case GameState.OVER:
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    Destroy(GameObject.Find("Dot(Clone)").gameObject);
                    gameState = GameState.START;
                    break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isNear = true;
        dotToRemove = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!isClicked)
            GameOver();
    }

    private void SpawnNewDot()
    {
        isNear = false;
        isClicked = false;
        float angle = 0;
        if ((int) Random.Range(0, 2) == 0)
            angle = Random.Range(30, 60) + 20;
        else
            angle = Random.Range(10, 30) + 10;
        Instantiate(dot, transform.position,
            Quaternion.Euler(0, 0, angle * direction));
    }

    private void GameOver()
    {
        direction = 0;
        gameState = GameState.OVER;
    }
}