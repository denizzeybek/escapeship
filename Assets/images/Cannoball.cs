using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannoball : MonoBehaviour
{
    [SerializeField] 
    public AudioSource tickSource;
    // Start is called before the first frame update
    void Start()
    {
        tickSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("soldier"))
        { 
            tickSource.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("soldier"))
        {
            tickSource.Stop();
        }
    }


}
