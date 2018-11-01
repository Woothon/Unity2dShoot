using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour {

    // 1 - Designer variables

    /// <summary>
    /// Projectile prefab for shooting
    /// </summary>
    public Transform shotPrefab;

    /// <summary>
    /// Cooldown in seconds between two shots
    /// </summary>
    public float shootingRate = 0.25f;

    // 2 - Cooldown

    private float shootCooldown;

	// Use this for initialization
	void Start () {
        shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
	}

    // 3 - Shooting from another script

    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            //Create a new shot
            var shotTransform = Instantiate(shotPrefab) as Transform;

            //Assign position
            shotTransform.position = transform.position;

            // The is enemy property
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            // Make the weapon shot always towards it
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if( move != null)
            {
                move.direction = this.transform.right; //toward in 2D space is the right of the sprite
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
