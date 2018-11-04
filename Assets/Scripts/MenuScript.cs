using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

    public void StartGame()
    {
        // "AppleTree" is the name of the first scene we created.

        UnityEngine.SceneManagement.SceneManager.LoadScene("AppleTree");
    }

    public void CloseGame()
    {
        // Quit the game
        Application.Quit();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
