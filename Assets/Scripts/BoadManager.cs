using UnityEngine;
using System.Collections;

/// <summary>
/// ボードの生成・破棄を管理
/// </summary>
public class BoadManager : MonoBehaviour
{
	Pool boadPool;

	void Start ()
	{
		boadPool = Pool.GetObjectPool (boadObject);
		boadPool.Interval = 0;

//		ChangeGameState (GameController.gameState.Value);
//		GameController.gameState.AddListener (ChangeGameState);
	}

	void OnDestroy ()
	{
//		if (GameController.Instance != null)
//			GameController.gameState.RemoveListener (ChangeGameState);
	}

	public void Clear()
	{
		boadPool.RemoveObject (100);
	}

//	void ChangeGameState (GameController.GameState state)
//	{
//		switch (state) {
//		case GameController.GameState.Title:
//			enabled = false;
//			break;
//		case GameController.GameState.Play:
//			enabled = true;
//			break;
//		case GameController.GameState.GameOver:
//			break;
//		}
//	}

	float nextSpawnTime = 0;
	float interval = 3;

	void Update ()
	{
		if (nextSpawnTime < Time.timeSinceLevelLoad) {
			nextSpawnTime = Time.timeSinceLevelLoad + interval;
			LocalInstantate ();
		}
	}


	void OnTriggerExit2D (Collider2D cal)
	{
		cal.attachedRigidbody.gameObject.SetActive (false);
	}

	public GameObject boadObject;

	void LocalInstantate ()
	{
		float y = Random.Range (-1.5f, 1.5f);
		GameObject obj = boadPool.GetInstance ();
		obj.transform.parent = transform;

		obj.transform.localPosition = new Vector3 (0, y, 0);

		obj.SetActive (true);
	}
}