using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creating instance of particles from code with no effort
/// </summary>
public class SpecialEffectsHelper : MonoBehaviour {

    /// <summary>
    /// Singleton
    /// </summary>
    public static SpecialEffectsHelper Instance;
    public ParticleSystem smokeEffect;
    public ParticleSystem fireEffect;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Multiple instance of SpecialEffectsHelper!");
        }

        Instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Explosion(Vector3 position)
    {
        //Smoke on the water
        instantiate(smokeEffect, position);

        //Tu tu tu, tu tu tudu

        //Fire in the sky
        instantiate(fireEffect, position);
    }

    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(prefab, position, Quaternion.identity) as ParticleSystem;

        //Make sure if will be destroyed.
        Destroy(
            newParticleSystem.gameObject,
            newParticleSystem.main.startLifetime.constant);

        return newParticleSystem;
    }
}
