/* 
 * Elisa Kalbé
 * portalEnter.cs
 * 
 * Script pour les actions suivants le passage d'un portail
 * Lorsqu'on passe dans un portail, il disparaît et réapparait 
 * aléatoirement dans la map.
 * A ajouter : boost
 * 
 * Dans la scene Game
 * A mettre sur l'objet : Circle (enfant de l'objet portal)
 *  
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalEnter : MonoBehaviour {


	/*********************************************************************
	************************** FONCTIONS *********************************
	*********************************************************************/

	// Lorsque le joueur passe un portail
	private void OnCollisionEnter(Collision joueur){

		// on verifie qu'il s'agit d'un joueur
		if (joueur.collider.tag == "Player" || joueur.collider.tag == "Equipe1" || joueur.collider.tag == "Equipe2") {

			// On récupère les caractéristiques du portail concerné
			GameObject parent = this.transform.parent.gameObject;

			// ---- On regarde quel bonus le joueur a eu
			// INVINCIBILITE : le joueur ne peux etre touché pendant quelques secondes
			if (parent.tag == "Invincible") {
				Debug.Log ("Invincible");
				StartCoroutine (accelere());
			}

			// INVISIBILITE : le joueur ne peux etre vu pendant quelques secondes
			if (parent.tag == "Invisible") {
				Debug.Log ("Invisible");
				StartCoroutine (accelere());
			}

			// DEGAT : le joueur fait plus de dégat pendant quelques secondes
			if (parent.tag == "Degat") {
				Debug.Log ("Degat");
				StartCoroutine (accelere());
			}

			// ESPION : le joueur apparaît aux couleurs de l'équipe adversaire pendant quelques secondes
			if (parent.tag == "Espion") {
				Debug.Log ("Espion");
				StartCoroutine (accelere());
			}

			// ACCELERATION : le vaisseau du joueur accelere pendant quelques secondes
			if (parent.tag == "Accelere") {
				Debug.Log ("Accelere debut");
				StartCoroutine (accelere());
			}


			// ---- On change le portail de position
			// On modifie sa position
			parent.transform.position = Random.insideUnitSphere * 170; // idem que dans portalCreation ( a changer selon scale de la map)
			// On modifie sa rotation
			parent.transform.rotation = Random.rotationUniform;
		}

	}

	// Routine pour acceleration
	private IEnumerator accelere(){

		// demarre acceleration
		Debug.Log("debut accelere");
		// modifie valeur vitesse
		GameObject obj = GameObject.FindGameObjectWithTag ("Player");
		//obj.GetComponent<PlayerControl> ().Speed = 30;

		// attend 5 secondes
		yield return new WaitForSeconds(5);

		// fini acceleration
		Debug.Log("Fin accelere");
		// vitesse par défault
		//obj.GetComponent<PlayerControl> ().Speed = 15;
	}
}
