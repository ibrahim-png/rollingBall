using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

using UnityEngine.SceneManagement;

public class Player : Singleton<Player>
{
    Animator anim;
  
    public static int kacTaneToplandi = 0;
    public GameObject diamondImage;
    protected Image diamond;
    public Image targetImage;

    public GameObject _canvasGameObject;
    public GameObject _lastTouchedgO;
    public GameObject pointBallTextPrefab;

    public GameObject gameOverPanel;

    public int haveUeverPlayMyGame;


    public GameObject tutorialFinger;

    public static int score = 0;
    public  Text scoreText;





    void Start()
    {
        anim = GetComponent<Animator>();//karakterin animasyon component ine ulasıyoruz
                                        //coinsManager = FindObjectOfType<coinManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        ITouchable touchable = other.GetComponent<ITouchable>(); // dokunulabilen nesneyi alıyoruz.
        _lastTouchedgO = other.GetComponent<GameObject>();
        if (touchable != null)//eger dokunulabilen bir nesne ise interface ile kendi metoduna gönderiyoruz
        {
            touchable.touchedEnter(gameObject);
        }
        else
        {
            Debug.Log("carpilan nesne = " + other.ToString());
        }

    }
    private void OnTriggerExit(Collider other)
    {
        ITouchable touchable = other.GetComponent<ITouchable>(); // dokunulabilen nesneyi alıyoruz.
        if (touchable != null)//eger dokunulabilen bir nesne ise interface ile kendi metoduna gönderiyoruz
        {
            touchable.touchedExit(gameObject);
        }
    }


    public void playerJump()
    {
        soundManager.playSound(soundManager.Sound.jump);
        anim.SetInteger("hareket", 1); // karekterin koşma animasyonu başlar
        Debug.Log("zıpladım");
    }
    public void playerRun()
    {
        anim.SetInteger("hareket", 0); // karekterin koşma animasyonu başlar
    }
    public void playerDie()
    {
        anim.SetInteger("hareket", 2); // karekterin koşma animasyonu başlar
    }


   
}
