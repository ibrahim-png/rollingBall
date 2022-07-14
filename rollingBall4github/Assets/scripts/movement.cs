using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : Singleton<movement>
{
	private move _swerveInputSystem;
	[SerializeField] private float swerveSpeed = 0.5f;
	[SerializeField] private float maxSwerveAmount = 1f;
	[SerializeField] public float moveForward = .3f;
    
    public void setDontMove()
    {
        swerveSpeed = 0f;
        maxSwerveAmount = 0f;
        moveForward = 0f;
    }

    public void setMove()
    {
        swerveSpeed = 0.5f;
        maxSwerveAmount = 1f;
        moveForward = .3f;
    }

    public bool isTouchScreenEver = false;
    public GameObject tutorialHand;
    private void Awake()
	{
		_swerveInputSystem = GetComponent<move>();

    }



	private void Update()
	{
        if (Input.GetMouseButtonDown(0) && (GameManager.Instance.gameState == GameManager.GameState.Start))
        {
            GameManager.Instance.gameState = GameManager.GameState.Ingame;
            isTouchScreenEver = true;
        }

        if (isTouchScreenEver)
        {
            Destroy(tutorialHand);
            float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX();
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
            transform.Translate(swerveAmount, 0, moveForward);
        }


        if (transform.position.z > 3.5f)
        {
            transform.position = new Vector3(transform.position.x , transform.position.y ,3.5f);
        }
        else if (transform.position.z < -3.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -3.5f);
        }
	}
}
