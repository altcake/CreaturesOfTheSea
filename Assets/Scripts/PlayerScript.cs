using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	public Vector2 speed = new Vector2(50, 50);

	private Vector2 movement;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		movement = new Vector2 (speed.x * inputX, speed.y * inputY);
		bool shoot = Input.GetButtonDown ("Fire1");
		shoot |= Input.GetButtonDown ("Fire2");
		
		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript> ();
			if (weapon != null && weapon.CanAttack)
			{
				weapon.Attack (false);
				SoundEffectsHelper.Instance.MakePlayerShotSound();
			}
		}

		// Make sure we are not outside the camera bounds.
		var dist = (transform.position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (0, 0, dist)
		).x;

		var rightBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (1, 0, dist)
		).x;

		var topBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (0, 0, dist)
		).y;

		var bottomBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (0, 1, dist)
		).y;

		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp (transform.position.y, topBorder, bottomBorder),
			transform.position.z
		);

		// End of the update method.
	}

	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		bool damagePlayer = false;

        TriggerEndLevelScript_01 triggerEndLevel_01 = collision.gameObject.GetComponent<TriggerEndLevelScript_01>();
        if (triggerEndLevel_01 != null)
        {
            transform.parent.gameObject.AddComponent<EndLevelScript_01>();
        }

        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            if (enemyHealth != null)
            {
                enemyHealth.Damage(enemyHealth.hp);
            }
            damagePlayer = true;
        }

        if (damagePlayer)
        {
            HealthScript playerHealth = this.GetComponent<HealthScript>();
            if (playerHealth != null)
            {
                playerHealth.Damage(1);
            }
        }
	}

	void OnDestroy() {
		// Game Over
		// Add the script to the parent because the current game
		// object is likely going to be destroyed immediately.
		transform.parent.gameObject.AddComponent<GameOverScript>();
	}

    public void showNextLevel()
    {
        transform.parent.gameObject.AddComponent<EndLevelScript_01>();
    }
}
