using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    /// <summary>
    /// 1 - The speed of the ship
    /// </summary>
    public Vector2 speed = new Vector2(10, 10);

    //2 - Store the movement and the component
    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //3 - Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(
            speed.x * inputX,
            speed.y * inputY);

        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if(weapon != null)
            {
                // false because the player is not an enemy               
                weapon.Attack(false);
                SoundEffectsHelper.Instance.MakePlayerShotSound();
            }
        }

    }

    private void FixedUpdate()
    {
        //print("FixedUpdate");
        // 5 - Get the component and store the reference
        if (rigidbodyComponent == null)
        {
            print("Initial");
            rigidbodyComponent = GetComponent<Rigidbody2D>();
        }

        //6 - Move the game object
        rigidbodyComponent.velocity = movement;

        //print(rigidbodyComponent.velocity.ToString());
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isPlayerDamaged = false;

        EnemyScript enemyScript = collision.gameObject.GetComponent<EnemyScript>();
        if (enemyScript != null)
        {
            //Kill enemy
            HealthScript enemyHealth = enemyScript.gameObject.GetComponent<HealthScript>();
            enemyHealth.Damage(enemyHealth.hp);
            isPlayerDamaged = true;
        }

        if (isPlayerDamaged)
        {
            HealthScript health = this.gameObject.GetComponent<HealthScript>();
            health.Damage(1);
        }
    }

    
}
