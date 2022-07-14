using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointBallScript : MonoBehaviour,ITouchable
{
    public bool dahaOnceAlindiMi = false;
    public GameObject _playerGameObject;
    public GameObject _pointBallTextPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dahaOnceAlindiMi)
        {
            transform.Rotate(0, 0, -100 * Time.deltaTime);
        }

        if (transform.position.y < 0)
        {
            soundManager.playSound(soundManager.Sound.hitblock);
            //Destroy(gameObject);
            gameObject.SetActive(false);
            transform.parent = null;
        }
     }


    void dahaOnceAlindiMiSetTrue()
    {
        dahaOnceAlindiMi = true;
    }
    public void touchedEnter(GameObject gO)
    {
        if (dahaOnceAlindiMi == false)
        {

            soundManager.playSound(soundManager.Sound.pointBallCollect);
            Player.Instance.transform.position = new Vector3(Player.Instance.transform.position.x, Player.Instance.transform.position.y + 1f, Player.Instance.transform.position.z);
            gameObject.transform.SetParent(Player.Instance.transform); // oyuncunun child ı yapıyoruz vuran topa.
            Player.kacTaneToplandi++;

            gameObject.transform.position = new Vector3(Player.Instance.transform.position.x, (Player.Instance.transform.position.y - 1f * Player.kacTaneToplandi) - 0.5f, Player.Instance.transform.position.z);
            dahaOnceAlindiMi = true;

            var textObject = Instantiate(_pointBallTextPrefab, Camera.main.WorldToScreenPoint(gameObject.transform.position), Quaternion.identity, GameObject.FindGameObjectWithTag("canvas").transform);
            textObject.GetComponent<Text>().text = "+ 1";

            // Debug.Log(kacTaneToplandi);
            Debug.Log("pointBall a dokunuldu");
        }
    }

    public void touchedExit(GameObject gameObject)
    {
        Debug.Log("pointBall dan çıkıldı");
    }
}
