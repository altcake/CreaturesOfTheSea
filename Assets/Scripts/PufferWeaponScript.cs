using UnityEngine;
using System.Collections;

public class PufferWeaponScript : MonoBehaviour
{

    public Transform shotPrefab;

    public float shootingRate = 2.0f;

    public Transform player;

    private float shootCooldown;

    void start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            var shotTransform = Instantiate(shotPrefab) as Transform;

            shotTransform.position = transform.position;

            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();

            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();

            if (move != null)
            {
//                move.direction = player.transform.position.normalized;
                move.direction = new Vector2(-(this.transform.position.x - player.transform.position.x), -(this.transform.position.y - player.transform.position.y)).normalized;
            }
        }
    }

    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}
