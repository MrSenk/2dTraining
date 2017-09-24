﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBehaviourScript : MonoBehaviour {

	public float velocidadMax = 10f;
	bool mirandoDerecha = true;
	Rigidbody2D rigi;
	Animator anim;

	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveX = Input.GetAxis ("Horizontal");
		float moveY = Input.GetAxis ("Vertical");

		anim.SetFloat ("velocidad", Mathf.Abs (moveX+moveY));

		rigi.velocity = new Vector2 (moveX * velocidadMax, (moveY * velocidadMax)/2);
		if (moveX > 0 && !mirandoDerecha) {
			Girar ();
		} else if(moveX < 0 && mirandoDerecha) {
			Girar ();
		}

	}

	void Girar () {
		mirandoDerecha = !mirandoDerecha;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
