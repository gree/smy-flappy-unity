using UnityEngine;
using System;
namespace flappySample {
	public partial class Main {
		
// [state2unity]Start:ee07a671d95935d0fffa514052a2c59331039caf

		private void StateStart() {
			playerControler = GameObject.Find ("Player").GetComponent<PlayerController> ();
			playerControler.enabled = false;
			playerControler.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
			buttonController = GameObject.Find ("Button").GetComponent<ButtonController> ();
			scoreLabel = GameObject.Find ("Score").GetComponent<ScoreLabel> ();
			boardManager = GameObject.Find ("Spawn").GetComponent<BoadManager> ();
			boardManager.enabled = false;
			mStateMachine.SwitchTo(StateWaitStartGame);
		}
    
// [state2unity]WaitStartGame:3cfc00a7786767afe32a1b61b10203d514324637

		private void StateWaitStartGame() {
			if (buttonController.IsClick) {// タップ
				gameStart();
				mStateMachine.SwitchTo (StateStartGame);
			}
		}
    
// [state2unity]StartGame:806947c2f1c64d59ccae1905f7e9ae35c1dffb53

		private void StateStartGame() {
			if (playerControler.isCollision) {// 障害物に衝突
				gameOver();
				mStateMachine.SwitchTo(StateGameOver);
			}
		}
    
// [state2unity]GameOver:02db0878f34bf1687150e560e5c4a0429c717fe1

		private void StateGameOver() {
			if (true) {// GameOverアニメーション終了
				mStateMachine.SwitchTo(StateWaitInitGame);
			}
		}
    
// [state2unity]WaitInitGame:9c73567e1e0ee0c37382ab4289077bff716c0d2e

		private void StateWaitInitGame() {
			if (buttonController.IsClick) {// タップ
				mStateMachine.SwitchTo(StateWaitStartGame);
				Application.LoadLevel( Application.loadedLevel) ;
			}
		}
  // []__end__
  }
} // namespace flappySample
