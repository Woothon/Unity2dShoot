using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private WeaponScript[] weapons;

    private void Awake()
    {
        // Retrieve the weapons
        weapons = GetComponentsInChildren<WeaponScript>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Auto-fire
        foreach(WeaponScript weapon in weapons)
        {
            if (weapon != null && weapon.CanAttack)
            {
                weapon.Attack(true);
            }
        }
	}
}
