using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoBehaviourScript : MonoBehaviour {

	public float velocidadMax = 10f;
	Transform transform;
	SpriteRenderer sprite;
	private float latestDirectionChangeTime;
	private readonly float directionChangeTime = 1f;
	private float characterVelocity = 2f;
	private Vector2 movementDirection;
	private Vector2 movementPerSecond;
	private int latestXPosition;
	private int latestYPosition;

	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();
		sprite = GetComponent<SpriteRenderer> ();
		latestDirectionChangeTime = 0f;
		calculateNewMovementVector ();
		latestXPosition = 6;
		latestYPosition = -3;
	}

	void calculateNewMovementVector (){
		movementDirection = new Vector2 (Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f)).normalized;
		movementPerSecond = movementDirection * characterVelocity;
	}
	
	// Update is called once per frame
	void Update () {
		sprite.sortingOrder = (Mathf.FloorToInt (transform.position.y * -5));

		if ((int)transform.position.x != latestXPosition) {
			latestXPosition = (int)transform.position.x;
		}

		if ((int)transform.position.y != latestYPosition) {
			latestYPosition = (int)transform.position.y;
		}

		if ((Time.time - latestDirectionChangeTime > directionChangeTime && latestYPosition == (int)transform.position.y) || (Time.time - latestDirectionChangeTime > directionChangeTime && latestXPosition == (int)transform.position.x)) {
			latestDirectionChangeTime = Time.time;
			calculateNewMovementVector ();
		} 

		transform.position = new Vector2 (transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y + (movementPerSecond.y * Time.deltaTime));
			
	}
}
