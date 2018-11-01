using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private WeaponScript weapon;

    private void Awake()
    {
        // Retrieve the weapon only once
        weapon = GetComponent<WeaponScript>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Auto-fire
        if(weapon != null && weapon.CanAttack)
        {
            weapon.Attack(true);
        }
	}
}
