using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    private Button[] buttons;

    private void Awake()
    {
        // Get the buttons
        buttons = GetComponentsInChildren<Button>();

        // Disable them
        HideButtons();
    }

    public void HideButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(false);
        }
    }

    public void ShowButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(true);
        }
    }

    public void ExitToMenu()
    {
        // Roload the level
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        // Reload the level
        UnityEngine.SceneManagement.SceneManager.LoadScene("AppleTree");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
