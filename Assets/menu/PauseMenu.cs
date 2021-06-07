using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

	[SerializeField] GameObject pauseMenu;

	public static bool isGamePaused = false;


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isGamePaused)
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
			}
		}
	}

	public void ResumeGame()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		isGamePaused = false;
		Cursor.visible = false;
		Debug.Log("Resume Game"); 
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	void PauseGame()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		isGamePaused = true;
		Cursor.visible = true; 
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

	}

	public void QuitGame()
	{
		Application.Quit();
		Debug.Log("Quit");
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

}
