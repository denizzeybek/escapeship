using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
	public static bool isGameOver = false;


	public void Setup(){
        gameObject.SetActive(true);
    }

    public void RestartButton(){
        SceneManager.LoadScene("EscapeFromShipProject");
    }
    public void QuitGame()
	{
		Application.Quit();
		Debug.Log("Quit");
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
 

    
}

 
