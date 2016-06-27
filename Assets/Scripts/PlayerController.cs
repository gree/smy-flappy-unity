using UnityEngine;
using System.Collections;

/// <summary>
/// プレイヤーの挙動を制御
/// </summary>
public class PlayerController : MonoBehaviour
{
	public bool isCollision = false;
	void Start ()
	{
		
//		ChangeGameState (GameController.gameState.Value);
//		GameController.gameState.AddListener( ChangeGameState );
	}

	void OnDestroy ()
	{
//		if (GameController.Instance != null)
//			GameController.gameState.RemoveListener( ChangeGameState );
	}

	public void init()
	{
		enabled = false;
		GetComponent<Rigidbody2D> ().isKinematic = true;
		transform.position.Set (-1.0f, .0f, .0f);
	}

	public void GameStart() {
		init ();
		isCollision = false;
		enabled = true;
		Rigidbody2D rigidBody2d = GetComponent<Rigidbody2D> ();
		rigidBody2d.isKinematic = false;
		rigidBody2d.transform.position.Set (-1.0f, .0f, .0f);
	}

//	void ChangeGameState (GameController.GameState state)
//	{
//		switch (state) {
//		case GameController.GameState.Title:
//			enabled = false;
//			GetComponent<Rigidbody2D>().isKinematic = true;
//			break;
//		case GameController.GameState.Play:
//			enabled = true;
//			GetComponent<Rigidbody2D>().isKinematic = false;
//			break;
//		case GameController.GameState.GameOver:
//			enabled = false;
//			GetComponent<Rigidbody2D>().velocity = Vector3.zero;
//			break;
//		}
//	}

	void OnCollisionEnter2D (Collision2D  cal)
	{
		isCollision = true;
//		GameController.gameState.Value = GameController.GameState.GameOver;
	}

	private bool isJumpRequest;

	void Update ()
	{
		Debug.Log (transform.position);
		if (Input.GetMouseButtonDown (0))
			isJumpRequest = true;
	}

	public float power = 2;

	void FixedUpdate ()
	{
		if (isJumpRequest) {
			isJumpRequest = false;
			GetComponent<Rigidbody2D>().velocity = Vector3.up * power;
		}
	}
}
