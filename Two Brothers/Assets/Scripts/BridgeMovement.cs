using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BridgeMovement : MonoBehaviour
{

    public GameObject player1;
    public GameObject cart;
    public Transform bridge;

    private bool readyToMove = false;

    private void Update()
    {

        if (readyToMove == true && bridge.transform.position.z <= 90f)
        {

            bridge.transform.Translate(0, 0, 1f * Time.deltaTime);

        }

        if(readyToMove == true && bridge.transform.position.z >= 90f)
        {

            readyToMove = false;

            player1.GetComponent<NavMeshAgent>().enabled = true;

        }

    }

    private void OnTriggerStay(Collider other)
    {
        
        if(other.CompareTag("Player2"))
        {

            if(Input.GetKeyDown(KeyCode.F))
            {

                player1.transform.parent = bridge.transform;
                cart.transform.parent = bridge.transform;

                player1.GetComponent<NavMeshAgent>().enabled = false;

                readyToMove = true;

            }

        }

    }
}
