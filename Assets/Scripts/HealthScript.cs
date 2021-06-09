﻿using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	// Define HP.
	public int hp = 1;

	// Identify enemy or player.
	public bool isEnemy = true;

	// Inflict damage and check if the object should be destroyed.
	public void Damage(int damageCount) {
		hp -= damageCount;

		if (hp <= 0) {
			// Explosion!
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			SoundEffectsHelper.Instance.MakeExplosionSound();

			// Dead!
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();

        // Only take damage if the gameObject is in the camera view.
		if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) && shot != null) {
			// Avoid friendly fire.
			if (shot.isEnemyShot != isEnemy) {
				Damage(shot.damage);

				// Destroy the shot.
				Destroy(shot.gameObject); // Remeber to always target the game object. Otherwise, you will just remove the script.
			}
		}
	}
}
