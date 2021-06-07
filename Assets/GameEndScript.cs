using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndScript : MonoBehaviour
{
    public GameObject Endscrn;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "soldier"){
            Endscrn.gameObject.SetActive(true);
        }
    }

    public void QuitGame()
	{
		Application.Quit();
		Debug.Log("Quit");
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
}
