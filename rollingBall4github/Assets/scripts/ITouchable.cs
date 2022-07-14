using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public interface ITouchable
{
    void touchedEnter(GameObject gameObject);
    void touchedExit(GameObject gameObject);
}
