using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManoplaScript : MonoBehaviour {

	public GameObject player;

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Enemy") {
			player.GetComponent<WolfBehaviourScript> ().enemyInTrigger = true;
			player.GetComponent<WolfBehaviourScript> ().target = target.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D target){
		if (target.tag == "Enemy") {
			player.GetComponent<WolfBehaviourScript> ().enemyInTrigger = false;
			player.GetComponent<WolfBehaviourScript> ().target = null;
		}
	}
}
