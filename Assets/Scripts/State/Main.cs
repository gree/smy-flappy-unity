using UnityEngine;
using System.Collections;

namespace flappySample {
	public partial class Main : MonoBehaviour {

		private StateMachine mStateMachine;
		private PlayerController playerControler = null;
		private ButtonController buttonController = null;
		private ScoreLabel scoreLabel = null;
		private BoadManager boardManager = null;

		// Use this for initialization
		void Start () {
			mStateMachine = new StateMachine("Main");
			mStateMachine.Spawn(StateStart);
		}

		// Update is called once per frame
		void Update () {
			mStateMachine.Exec();
		}

		void gameStart() {
//			playerControler.isCollision = false;
//			playerControler.enabled = true;
//			playerControler.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
			playerControler.GameStart();
			buttonController.gameObject.SetActive (false);
			boardManager.enabled = true;
			boardManager.Clear ();
		}

		void gameOver() {
			playerControler.enabled = false;
			playerControler.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			buttonController.gameObject.SetActive (true);
			buttonController.IsClick = false;
			buttonController.label.text = "RETRY";
		}
	}
} // namespace flappySample


