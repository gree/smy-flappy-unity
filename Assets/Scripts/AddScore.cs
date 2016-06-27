using UnityEngine;
using System.Collections;

/// <summary>
/// 接触時にスコアを加算する
/// </summary>
public class AddScore : MonoBehaviour
{
	public bool isColision = false;
	void OnTriggerExit2D (Collider2D cal)
	{
		if (cal.CompareTag ("Player")) {
			isColision = true;
			GameController.score.Value += 1;
		}
	}
}
