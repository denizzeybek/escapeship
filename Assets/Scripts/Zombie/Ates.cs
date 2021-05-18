using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ates : MonoBehaviour
{
    public float Mesafe;

    public float sıkma_aralıgı;
    float zamanlayici;

    public float Hasar;

    public int Mermi_Sayisi;
    public int Sarjor;
    public int Sarjor_mermi;

    public TextMeshProUGUI mermisayisi, sarjor;

    public Image crosshair;

    bool fire = true;

    public AudioSource sfx;
    public AudioClip ak;
    public AudioClip reload;
    public AudioClip Bos;

    public ParticleSystem muzzleflash;

    public Animation anim;

    private void Start()
    {
        mermisayisi.text = Mermi_Sayisi.ToString();
        sarjor.text = Sarjor.ToString();
    }

    void FixedUpdate()
    {
        if (fire == true && Time.time > zamanlayici && (Input.GetMouseButton(0)))
        {
            if (Mermi_Sayisi > 0)
            {
                AtesEt();
                zamanlayici = Time.time + sıkma_aralıgı;
            }
            else if (Sarjor > 0 && Mermi_Sayisi < 30)
            {
                Reload();
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (Mermi_Sayisi <= 0 && Sarjor <= 0)
            {
                sfx.clip = Bos;
                sfx.Play();
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            if (Sarjor > 0 && Mermi_Sayisi < 30)
            {
                Reload();
            }
        }

        crosshair.color = Color.white;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mesafe))
        {
            if (hit.distance <= Mesafe && hit.collider.gameObject.tag == "Enemy")
                crosshair.color = Color.red;
        }
    }

    public void AtesEt()
    {
        muzzleflash.Play();

        sfx.clip = ak;
        sfx.Play();

        Mermi_Sayisi--;
        mermisayisi.text = Mermi_Sayisi.ToString();

        anim.Play("Tepme");

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, Mesafe))
        {
            Dusman dusman = hit.transform.GetComponent<Dusman>();
            if(dusman != null)
            {
                dusman.HasarVer(Hasar);
            }
        }
    }

    public void Reload ()
    {
        Sarjor--;
        Mermi_Sayisi = Sarjor_mermi;
        mermisayisi.text = Mermi_Sayisi.ToString();
        sarjor.text = Sarjor.ToString();
        anim.Play("Sarjor");
        sfx.clip = reload;
        sfx.Play();
        fire = false;
        StartCoroutine(SDegis());
    }

    IEnumerator SDegis ()
    {
        yield return new WaitForSeconds(1f);
        sfx.clip = reload;
        sfx.Play();
        yield return new WaitForSeconds(0.47f);
        fire = true;
    }
}

