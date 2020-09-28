using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ElevatorMovement2 : MonoBehaviour
{

    public GameObject player2;
    public GameObject elevatorGO;
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

            player2.transform.parent = null;

            player2.GetComponent<NavMeshAgent>().enabled = true;

        }

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player1"))
        {

            if (Input.GetKeyDown(KeyCode.F))
            {

                elevatorGO.GetComponent<ElevatorComeback>().enabled = false;

                player2.transform.parent = elevator.transform;

                player2.GetComponent<NavMeshAgent>().enabled = false;

                readyToMove = true;

            }

        }

    }

}
