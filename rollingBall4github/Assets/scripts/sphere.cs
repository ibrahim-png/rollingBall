using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere : MonoBehaviour
{
    public bool oyunSonu = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.Ingame)
        {
            transform.Rotate(-100 * Time.deltaTime, 0, 0);
        }
        
    }
}
