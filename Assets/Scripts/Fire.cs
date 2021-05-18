using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fire : MonoBehaviour
{
        public float Mesafe;

        public float sıkma_aralıgı;
        float zamanlayici;

        public float Hasar;

        public Image crosshair;

        bool fire = true;

        public AudioSource sfx;
        public AudioClip ak;

        public ParticleSystem muzzleflash;

        public Animation anim;


        void FixedUpdate ()
        {
                if (fire == true && Time.time > zamanlayici && (Input.GetMouseButton (0)))
                {
                        AtesEt ();
                        zamanlayici = Time.time + sıkma_aralıgı;
                }

                crosshair.color = Color.white;
                RaycastHit hit;
                if (Physics.Raycast (transform.position, transform.forward, out hit, Mesafe))
                {
                        if (hit.distance <= Mesafe && hit.collider.gameObject.tag == "Enemy")
                                crosshair.color = Color.red;
                }
        }

        public void AtesEt ()
        {
                muzzleflash.Play ();

                sfx.clip = ak;
                sfx.Play ();

                anim.Play ("Tepme");

                RaycastHit hit;
                if (Physics.Raycast (transform.position, transform.forward, out hit, Mesafe))
                {
                        Enemy dusman = hit.transform.GetComponent<Enemy> ();
                        if (dusman != null)
                        {
                                dusman.HasarVer (Hasar);
                        }
                }
        }
}
