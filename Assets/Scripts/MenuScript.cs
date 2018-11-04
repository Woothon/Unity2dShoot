using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

    public void StartGame()
    {
        // "Stage1" is the name of the first scene we created.

        UnityEngine.SceneManagement.SceneManager.LoadScene("AppleTree");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
