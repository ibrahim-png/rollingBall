using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject StartPanel, IngamePanel, GameOverPanel;
    public float countDown = 2f;

    public enum GameState
    {
        Start,
        Ingame,
        GameOver
    }
    public GameState gameState;

    public enum Panels {
        StartPanel,
        IngamePanel,
        GameOverPanel
    }

    private void Start()
    {
        gameState = GameState.Start;
    }


    private void Update()
    {
        
        switch (gameState)
        {
            case GameState.Start:
                gameStart();
                break;
            case GameState.Ingame:
                gameIngame();
                break;
            case GameState.GameOver:
                gameOver();
                break;
        }
    }

  

    void gameStart()
    {
        panelController(Panels.StartPanel);
    }
    void gameIngame()
    {
        panelController(Panels.IngamePanel);
    }
    void gameOver()
    {
        panelController(Panels.GameOverPanel);
    }


    void panelController(Panels currentPanel)
    {
        StartPanel.SetActive(false);
        IngamePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        switch (currentPanel)
        {
            case Panels.StartPanel:
                StartPanel.SetActive(true);
                break;
            case Panels.IngamePanel:
                IngamePanel.SetActive(true);
                break;
            case Panels.GameOverPanel:
                GameOverPanel.SetActive(true);
                break;
        }
    }

    public void setStartGame() {
      
        
        gameState = GameState.Ingame;
        Player.Instance.playerRun();
        scoreText._scoreTextInt = 0;
        scoreText.setScoreText();
        movement.Instance.setMove();
        Player.Instance.transform.position= new Vector3(Player.Instance.transform.position.x, 1f , Player.Instance.transform.position.z); // player ı y ekseninde 1 e getiriyorum çünkü altında sadece mainball kalmalı . daha fazla ball varsa otomatik olarak y ekseninde road ın altında kaldıgı için direkt olarak destroy oluyor
        Player.kacTaneToplandi = 0;
        Debug.Log("oyun tekrar basladı");
    }
}
