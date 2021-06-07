using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBarScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 2000f;
    HandgunScriptLPFP Player;

    private void Start(){
        HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<HandgunScriptLPFP>();

    }
    private void Update(){
        CurrentHealth = Player.health;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
