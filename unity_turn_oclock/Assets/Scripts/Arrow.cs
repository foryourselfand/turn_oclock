using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Arrow : MonoBehaviour
{
    public float speed;

    public GameObject dot;
    public ColorChanger colorChanger;

    public Text scoreText;
    public AlphaChanger scoreAlpha;

    public DialogSystem dialogSystem;
    public AlphaChanger dialogAlpha;

    private int score, currentScore;

    private int direction;
    private bool isNear, isClicked;

    private GameState gameState;

    enum GameState
    {
        START,
        PLAYING,
        OVER,
        WIN
    }

    void Start()
    {
        direction = 0;
        isNear = false;
        isClicked = false;
        gameState = GameState.START;
        score = 1;
        currentScore = 1;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed * direction));

        if (Input.GetMouseButtonDown(0))
        {
            switch (gameState)
            {
                case GameState.START:
                    direction = Random.Range(0, 2) == 0 ? -1 : 1;
                    gameState = GameState.PLAYING;
                    SpawnNewDot();
                    dialogAlpha.FromStartToEnd();
                    scoreAlpha.FromStartToEnd();
                    break;

                case GameState.PLAYING:
                    if (isNear)
                    {
                        direction = -direction;
                        isClicked = true;
                        Destroy(GameObject.Find("Dot(Clone)").gameObject);
                        DecreaseScore();
                        if (currentScore == 0)
                        {
                            score++;
                            currentScore = score;

                            direction = 0;
                            gameState = GameState.WIN;
                            dialogAlpha.FromEndToStart();
                            dialogSystem.RandomWin();
                        }
                        else
                        {
                            SpawnNewDot();
                        }
                    }
                    else
                        GameOver();

                    break;

                case GameState.OVER:
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    Destroy(GameObject.Find("Dot(Clone)").gameObject);
                    gameState = GameState.START;
                    currentScore = score;
                    scoreText.text = currentScore.ToString();
                    colorChanger.SetPreviousColor();
                    break;

                case GameState.WIN:
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    gameState = GameState.START;
                    scoreText.text = currentScore.ToString();
                    colorChanger.SetNewColor();
                    scoreAlpha.FromEndToStart();
                    break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isNear = true;
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
        float angle = Random.Range(0, 2) == 0 ? Random.Range(30, 60) + 20 : Random.Range(10, 30) + 10;
        Instantiate(dot, transform.position,
            Quaternion.Euler(0, 0, angle * direction));
    }

    private void GameOver()
    {
        direction = 0;
        gameState = GameState.OVER;
        colorChanger.SetLoseColor();
        dialogAlpha.FromEndToStart();
        dialogSystem.RandomLose();
    }

    private void DecreaseScore()
    {
        currentScore -= 1;
        scoreText.text = currentScore.ToString();
    }
}