using UnityEngine;
using System.Collections;

public class PufferScript : MonoBehaviour
{
    private bool hasSpawn;
    private MoveScript moveScript;
    private PufferWeaponScript[] weapons;

    void Awake()
    {
        // Retrieve the weapon only once.
        weapons = GetComponentsInChildren<PufferWeaponScript>();
        moveScript = GetComponent<MoveScript>();
    }

    void Start()
    {
        hasSpawn = false;
        collider2D.enabled = false;
        moveScript.enabled = false;

        foreach (PufferWeaponScript weapon in weapons)
        {
            weapon.enabled = false;
        }
    }

    void Update()
    {
        // Spawn the game object if it hasn't been spawned yet.
        if (hasSpawn == false)
        {
            Spawn();
        }

        else
        {
            foreach (PufferWeaponScript weapon in weapons)
            {
                // Auto-Fire
                if (weapon != null && weapon.CanAttack && renderer.IsVisibleFrom(Camera.main))
                {
                    weapon.Attack(true);
                    SoundEffectsHelper.Instance.MakeEnemyShotSound();
                }
            }

            // Only destroy the game object if it's less than -10.
            // 0 is still within a quarter of the camera view so -10 is a safe number.
            if (gameObject.transform.position.x < -10)
            {
                Destroy(gameObject);
            }
        }
    }
    private void Spawn()
    {
        hasSpawn = true;
        collider2D.enabled = true;
        moveScript.enabled = true;
        foreach (PufferWeaponScript weapon in weapons)
        {
            weapon.enabled = true;
        }
    }
}