using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Diamond : MonoBehaviour, ITouchable
{
    

    public GameObject _FloatTextPrefab; // olusakcak olan text in prefab ı
    private GameObject _canvasGameObject;

    public GameObject _diamondImage;
    private Image _diamond;
    private GameObject _targetImage;

    public void Start()
    {
        _canvasGameObject = GameObject.Find("Canvas");
        _targetImage = GameObject.Find("Image");
    }

    

    private void addFloatPoint()
    {
        var textObject = Instantiate(_FloatTextPrefab, Camera.main.WorldToScreenPoint(transform.position), Quaternion.identity, _canvasGameObject.transform);
        textObject.GetComponent<Text>().text = "X " + (Player.kacTaneToplandi + 1);
        Player.score = Player.score + Player.kacTaneToplandi + 1;
        float renk = .1f;
        Handheld.Vibrate();
        textObject.GetComponent<Text>().color = new Color(Player.kacTaneToplandi * renk, renk * Player.kacTaneToplandi, renk * Player.kacTaneToplandi, 255);//sari diamond
     
    }
    private void addScoreText()
    {
        scoreText._scoreTextInt += Player.kacTaneToplandi + 1; // kaç adet top aldı + mainSphere
        scoreText.setScoreText();

    }

    public void touchedEnter(GameObject gO)
    {
       


        addFloatPoint();
        addScoreText();

        Destroy(gameObject);

        
        float duration = 2f;
        for (int i = 0; i < Player.kacTaneToplandi + 1; i++) //altında kaç tane top varsa o kadar diamond gidecek
        {
            soundManager.playSound(soundManager.Sound.diamondCollect);
            GameObject gODiamond = objectPool.Instance.GetPooledObject(0);
            gODiamond.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            gODiamond.transform.SetParent(FindObjectOfType<Canvas>().transform);
            _diamond = gODiamond.GetComponent<Image>();
            //_diamond = (Instantiate(_diamondImage, Camera.main.WorldToScreenPoint(transform.position), Quaternion.identity, FindObjectOfType<Canvas>().transform)).GetComponent<Image>(); // diamond image ini canvas ın altında olusturdum.
            DOTween.Sequence().Append(_diamond.transform.DOMove(_targetImage.transform.position, duration).
            SetEase(Ease.OutExpo)).OnComplete(() => Destroy(this));
            duration += .5f;
        }
        
    }

    public void touchedExit(GameObject gameObject)
    {
        Debug.Log("diamond dan çıkıldı");
    }
}
