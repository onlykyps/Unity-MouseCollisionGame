using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLogic : MonoBehaviour {

	public float playerSpeed = 2000.0f;
	scoreLogic addToScore;

	// Use this for initialization
	void Start () {
		hideMouseCursor ();
	}
	
	// Update is called once per frame
	void Update () {
		movePlayerToMousePos ();
	}

	void movePlayerToMousePos()
	{
		var tempMousePos = Input.mousePosition;
		tempMousePos.z = transform.position.z - Camera.main.transform.position.z;
		tempMousePos = Camera.main.ScreenToWorldPoint (tempMousePos);
		transform.position = Vector3.MoveTowards (transform.position, tempMousePos, playerSpeed * Time.deltaTime);
	}

	void hideMouseCursor()
	{
		Cursor.visible = false;
	}

	void OnCollisionEnter2D(Collision2D tempCollsion)
	{
		if (tempCollsion.gameObject.tag == "goodCollectable") 
		{
			callAddToScoreScript ();
			Destroy (tempCollsion.gameObject);
		}

		if (tempCollsion.gameObject.tag == "badCollectable") 
		{
			resetGame ();

		}
	}

	void callAddToScoreScript()
	{
		addToScore = GameObject.FindGameObjectWithTag ("GUI").GetComponent<scoreLogic> ();
		addToScore.addToScoreVoid ();
	}

	void resetGame()
	{
		SceneManager.LoadScene ("GameScene");
	}

}
