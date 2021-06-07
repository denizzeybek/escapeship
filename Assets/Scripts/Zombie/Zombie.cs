using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    public float mesafe;

    private Transform hedef;

    NavMeshAgent agent;

    Animator anim;

    public Dusman dusman;


    void Start()
    {
        hedef = GameObject.FindWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        if (dusman.öldümü == false)
        {
            anim.SetFloat("Hız", agent.velocity.magnitude);

            mesafe = Vector3.Distance(transform.position, hedef.position);

            if (mesafe <= 5000)
            {
                agent.enabled = true;
                agent.destination = hedef.position;
            }
            else
            {
                agent.enabled = false;
            }
            if (mesafe <= 1.2)
            {
                agent.enabled = false;
            }
            if (dusman.öldümü == true)
            {
                agent.enabled = false;
            }
        }
    }
}
