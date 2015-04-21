using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {
	public float speed;

	void Start () {
	
	}
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector3 (moveHorizontal, moveVertical);
		GetComponent<Rigidbody2D>().velocity = movement * speed;
	}
}
