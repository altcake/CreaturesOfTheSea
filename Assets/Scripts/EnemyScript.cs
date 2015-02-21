using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	private WeaponScript[] weapons;

	void Awake() {
		// Retrieve the weapon only once.
		weapons = GetComponentsInChildren<WeaponScript>();
	}

	void Update() {
		foreach (WeaponScript weapon in weapons) {
			// Auto-Fire
			if (weapon != null && weapon.CanAttack) {
				weapon.Attack(true);
			}
		}
	}
}