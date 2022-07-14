using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takipKamera : MonoBehaviour
{

    public GameObject player;
    public Vector3 takipMesafesi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + takipMesafesi, Time.deltaTime);
        
    }
}
