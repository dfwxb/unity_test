using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private static GameManager _instance;

	public static GameManager Instance {
		get { 
			return _instance;
		}	
	}

	private BoxCollider2D rightWall;
	private BoxCollider2D leftWall;
	private BoxCollider2D upWall;
	private BoxCollider2D downWall;

	public Transform player1;
	public Transform player2;

	// 记录分数
	private int score1;
	private int score2;

	public Text score1Text;
	public Text score2Text;

	void Awake() {
		_instance = this;
	}

	// Use this for initialization
	void Start () {
		ResetWall ();
		ResetPlayer ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void ResetWall() {
		rightWall = transform.Find ("rightWall").GetComponent<BoxCollider2D> ();
		leftWall = transform.Find ("leftWall").GetComponent<BoxCollider2D> ();
		upWall = transform.Find ("upWall").GetComponent<BoxCollider2D> ();
		downWall = transform.Find ("downWall").GetComponent<BoxCollider2D> ();

		Vector3 tmpPosition = Camera.main.ScreenToWorldPoint (new Vector2 (Screen.width, Screen.height));

		upWall.transform.position = new Vector3(0, tmpPosition.y + 0.5F, 0);
		downWall.transform.position = new Vector3(0, -tmpPosition.y - 0.5F, 0);
		leftWall.transform.position = new Vector3(-tmpPosition.x -0.5F, 0, 0);
		rightWall.transform.position = new Vector3(tmpPosition.x +0.5F, 0, 0);

		upWall.size = new Vector2 (tmpPosition.x*2, 1);
		downWall.size = new Vector2 (tmpPosition.x*2, 1);
		leftWall.size = new Vector2 (1, tmpPosition.y*2);
		rightWall.size = new Vector2 (1, tmpPosition.y*2);
	}

	void ResetPlayer() {
		Vector3 player1Position = Camera.main.ScreenToWorldPoint (new Vector3 (100, Screen.height/2, 0));
		player1Position.z = 0;
		player1.position = player1Position;

		Vector3 player2Position = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width - 100, Screen.height/2, 0));
		player2Position.z = 0;
		player2.position = player2Position;
	}

	public void ChangeScore(string wallName) {
		if (wallName == "leftWall") {
			score2++;
		}

		if (wallName == "rightWall") {
			score1++;
		}

		score1Text.text = score1.ToString ();
		score2Text.text = score2.ToString ();
	}

	public void Reset() {
		score1 = 0;
		score2 = 0;

		score1Text.text = score1.ToString ();
		score2Text.text = score2.ToString ();

		GameObject.Find ("Ball").SendMessage ("Reset");
	}
}
