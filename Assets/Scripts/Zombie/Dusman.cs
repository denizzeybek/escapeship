using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman : MonoBehaviour
{
    public float can = 100;
    public float damage = 100f;
    private Animator anim;
    GameObject target;
    public bool öldümü = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void HasarVer (float amount)
    {
        can -= amount;
        anim.SetBool("Öldü", true);
        if(can <= 0)
        {
            Ölüm();
        }
    }

    public void Ölüm ()
    {
        
        öldümü = true;
        gameObject.tag = "Untagged";
        StartCoroutine(sil());
    }

    IEnumerator sil ()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

     
 

}
