using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ElevatorMovement : MonoBehaviour
{

    public GameObject player1;
    public GameObject cart;
    public Transform elevator;

    private bool readyToMove = false;

    private void Update()
    {

        if (readyToMove == true && elevator.transform.position.y <= 20f)
        {

            elevator.transform.Translate(0, 1f * Time.deltaTime, 0);

        }

        if (readyToMove == true && elevator.transform.position.y >= 20f)
        {

            readyToMove = false;

            player1.transform.parent = null;
            cart.transform.parent = null;

            player1.GetComponent<NavMeshAgent>().enabled = true;

        }

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player2"))
        {

            if (Input.GetKeyDown(KeyCode.F))
            {

                player1.transform.parent = elevator.transform;
                cart.transform.parent = elevator.transform;

                player1.GetComponent<NavMeshAgent>().enabled = false;

                readyToMove = true;

            }

        }

    }

}
