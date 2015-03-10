using UnityEngine;
using System.Collections;

public class PufferHealth : MonoBehaviour {
	// Define HP.
	public int hp = 5;
	private int hits = 0;
	private Animator animator;
	public Sprite spriterenderer;
	// Identify enemy or player.
	public bool isEnemy = true;
	void Start()
	{
		animator = this.GetComponent<Animator> ();
	}
	
	// Inflict damage and check if the object should be destroyed.
	public void Damage(int damageCount) {
		hp -= damageCount;
		
		if (hp <= 0) {
			// Explosion!
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			SoundEffectsHelper.Instance.MakeExplosionSound();
			
			// Dead!
			Destroy(gameObject);
            Application.LoadLevel("Menu");
		}
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider) {
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript> ();
		
		if (shot != null) {
			// Avoid friendly fire.
			if (shot.isEnemyShot != isEnemy) {
				Damage(shot.damage);
				hits++;
				animator.SetBool("Collision", true);
				animator.SetInteger ("NumHits", hits);
				this.GetComponent<SpriteRenderer>().sprite = (spriterenderer);
				// Destroy the shot.
				Destroy(shot.gameObject); // Remeber to always target the game object. Otherwise, you will just remove the script.
			}
		}
	}
}
