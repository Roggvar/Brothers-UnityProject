using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorComeback : MonoBehaviour
{

    private bool readyToMove = false;

    private float cooldown = 0f; // controle de cooldown
    private float cooldownTimer = 1f; // tempo de cooldown para evitar conflito

    public Transform elevator;

    private void Update()
    {
        
        if(readyToMove == true && Time.time >= cooldown && elevator.transform.position.y >= 12f)
        {

            elevator.transform.Translate(0, -1f * Time.deltaTime, 0);

        }

    }

    private void OnTriggerExit(Collider other)
    {
        
        if(other.CompareTag("Player1"))
        {

            readyToMove = true;
            cooldown = Time.time + cooldownTimer; // Seta o cooldown

        }

    }

}
