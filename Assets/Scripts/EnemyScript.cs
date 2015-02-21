using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	private WeaponScript weapon;

	void Awake() {
		// Retrieve the weapon only once.
		weapon = GetComponent<WeaponScript> ();
	}

	void Update() {
		// Auto-Fire
		if (weapon != null && weapon.CanAttack) {
			weapon.Attack (true);
		}
	}
}
