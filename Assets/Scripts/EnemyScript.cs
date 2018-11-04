using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private bool hasSpawn;
    private WeaponScript[] weapons;
    private MoveScript moveScript;
    private Collider2D coliderComponent;
    private SpriteRenderer rendererComponent;

    private void Awake()
    {
        // Retrieve the weapons
        weapons = GetComponentsInChildren<WeaponScript>();

        // Retrieve scripts to disable when not spawn
        moveScript = GetComponent<MoveScript>();

        coliderComponent = GetComponent<Collider2D>();

        rendererComponent = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
        hasSpawn = false;

        //Disable everything
        //-- collider
        coliderComponent.enabled = false;
        //-- Moving
        moveScript.enabled = false;
        //-- Shooting
        foreach(WeaponScript weapon in weapons)
        {
            weapon.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (hasSpawn == false)
        {
            if (rendererComponent.IsVisibleForm(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            //Auto-fire
            foreach (WeaponScript weapon in weapons)
            {
                if (weapon != null && weapon.CanAttack)
                {
                    weapon.Attack(true);
                    SoundEffectsHelper.Instance.MakeEnemyShotSound();
                }
            }

            // 4 - Out of the camera ? Destroy the game object.
            if(rendererComponent.IsVisibleForm(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
		
	}

    // 3 - Activate itself.
    private void Spawn()
    {
        hasSpawn = true;

        // Enable everything
        // -- Collider
        coliderComponent.enabled = true;
        // -- Moving
        moveScript.enabled = true;
        // -- Shooting
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = true;
        }
    }
}
