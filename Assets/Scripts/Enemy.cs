using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
        public float can = 100;

        public void HasarVer (float amount)
        {
                can -= amount;

                if (can <= 0)
                {
                        Death ();
                }
        }

        public void Death ()
        {
                Destroy (gameObject);
        }
}
