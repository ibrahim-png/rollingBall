using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class blockScript :MonoBehaviour, ITouchable
{
    private GameObject player;
    private GameObject sphereGameObject;


    public int kacBallYokEder;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        sphereGameObject= GameObject.FindWithTag("mainSphere");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void touchedEnter(GameObject gO)
    {
        //Debug.Log("yokedici özelligi =" + yokEdici +"    "+"kacballyokeder  =" + kacBallYokEder.ToString());
        if (Player.kacTaneToplandi + 0.5f > kacBallYokEder)
        {


            Player.kacTaneToplandi = Player.kacTaneToplandi - kacBallYokEder;
            Player.Instance.playerJump();


        }
        else
        {
            Debug.Log("!!!GAME OVER!!!");
            GameManager.Instance.gameState = GameManager.GameState.GameOver;
            movement.Instance.setDontMove();
            //Player.Instance.GetComponent<movement>().moveForward = 0;
            Player.Instance.playerDie(); // player ın el sallama animasyonu
            sphereGameObject.GetComponent<sphere>().oyunSonu = true; // player ın el sallama animasyonu
            soundManager.playSound(soundManager.Sound.gameOver);
            //Destroy(gameObject); //oyuncunun son dokundugu blogu yok et
            gameObject.SetActive(false);
            objectPool.Instance.allItemSetActiveFalse();
        }

    }

    public void touchedExit(GameObject gameObject)
    {
        if (GameManager.Instance.gameState == GameManager.GameState.Ingame)
        {
            DOTween.Sequence().Append(gameObject.transform.DOMove(new Vector3(player.transform.position.x - (kacBallYokEder / 2f), player.transform.position.y - 1 * kacBallYokEder, player.transform.position.z), 0.1f).
             SetEase(Ease.Linear)); // oyuncunun block a çarptıktan sonra zınk diye aşağıya inmesinden ziyade bu şekilde biraz ileriye dogru çağraz düşmesine yarıyor.

            Player.Instance.playerRun();
            Debug.Log("bloktan çıktı");
        }
          
    }
}
