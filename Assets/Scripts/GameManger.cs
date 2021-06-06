using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : UIGamePlayController {
    public static GameManger instance;
    //[SerializeField] private Text scoreText;
    //[SerializeField] private Text coinText;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private Text scoreInGameText;
    [SerializeField] private Text coinInGameText;
    //[SerializeField] private Text yourScoreText;
    //[SerializeField] private Text yourHighScoreText;
    private int bestScore;
    private int gameScore;
    private int coinPoint;
    static int timeToPlay;
    private bool gameOver =  false;


    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start() {
        coinPoint = PlayerPrefs.GetInt("coinPoint", coinPoint);
        bestScore = PlayerPrefs.GetInt("bestScore", bestScore);
        coinInGameText.text = "" + coinPoint;
        //SetCoin(coinPoint);
    }

    public bool GameOver {
        get { return gameOver; }
    }

    public int GameScore {
        get { return gameScore; }
    }

    public void calculateScore(int score) {
        gameScore += score;
        if (gameScore > bestScore) {
			bestScore = gameScore;
			PlayerPrefs.SetInt("bestScore", bestScore);
		}
        scoreInGameText.text = "" + gameScore;
        //SetPoint(gameScore);
    }

    public void calculatorCoin(int coin) {
        coinPoint += coin;
        coinInGameText.text = "" + coinPoint;
        PlayerPrefs.SetInt("coinPoint", coinPoint);
    }

    public void tankGet0 () {
        gameOver = true;
        timeToPlay++;
        gameOverText.SetActive(true);
        //yourScoreText.text = "" + gameScore;
        //yourHighScoreText.text = "" + bestScore;
        SetYourScore(gameScore);
        SetYourBestScore(bestScore);
        SetYourEnemyKill(EventGameManager.instance.EnemyKillCount);
        SetCoin(coinPoint);
    }

    public void GotoGameMenu() {
        GotoScene("GamePlay");
    }

    public void GotoMenu() {
        GotoScene("GameMenu");
    }
}
