using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreText : MonoBehaviour
{
    public static Text _scoreText;
    public static int _scoreTextInt = 0 ;

    public static void setScoreText()
    {
        GameObject.FindGameObjectWithTag("scoreText").GetComponent<Text>().text = _scoreTextInt.ToString();
        
    }
}
