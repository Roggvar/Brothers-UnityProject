using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{

    public static float speed = 6.0f; // velocidade do player

    Transform target;
    NavMeshAgent agent; // aloca o navmesh ao agent

    void Start()
    {

        agent = GetComponent<NavMeshAgent>(); ; // aloca o navmesh

    }

    private void Update()
    {

        agent.speed = speed; // seta a velocidade do agent(player)

        //Segue o foco do player
        if (target != null)
        {

            agent.SetDestination(target.position);
            FaceTarget();

        }

    }

    //Gerencia a movimentaçao do player
    public void MoveToPoint(Vector3 point)
    {

        agent.SetDestination(point);

    }

    // Gerencia a perseguiçao do alvo
    public void FollowTarget(Interactable newTarget)
    {

        agent.stoppingDistance = newTarget.radius * 1.8f; //Evita que o player entre no objeto 

        agent.updateRotation = false; // para de rodar o agent

        target = newTarget.interactionTransform;


    }

    // Gerencia a parada da perseguiçao do alvo
    public void StopFollowingTarget()
    {

        agent.stoppingDistance = 0f; // distancia da parada
        agent.updateRotation = true; // para de rodar o agent
       
        target = null;


    }

    //Matematica da rotaçao do alvo
    void FaceTarget()
    {

        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }

}
