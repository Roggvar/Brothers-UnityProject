using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{

    const float smoothTime = .1f; // tempo de smooth entre animaçoes

    Animator animator; // referencia ao animator
    NavMeshAgent agent; // referencia ao navmesh

    void Start()
    {

        agent = GetComponent<NavMeshAgent>(); // aloca o navmesh
        animator = GetComponentInChildren<Animator>(); // aloca o animator

    }

    void Update()
    {

        float speedPercent = agent.velocity.magnitude / agent.speed;

        animator.SetFloat("speedPercent", speedPercent, smoothTime, Time.deltaTime); // puxa do animator do player


    }
}
