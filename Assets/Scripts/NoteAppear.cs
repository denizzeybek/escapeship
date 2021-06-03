using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NoteAppear : MonoBehaviour
{
    [SerializeField]
    private Image _noteImage;
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
            _noteImage.enabled = true;
            tickSource.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("soldier"))
        {
            _noteImage.enabled = false;
        }
    }

}
