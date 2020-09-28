using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CartController : MonoBehaviour
{

    private float speed = 6.0f; // velocidade do cart
    private float cooldown = 0f; // controle de cooldown
    private float cooldownTimer = 2f; // tempo de cooldown para evitar conflito

    public static bool isInteracting = false; // se esta interagindo com o cart

    public Transform targetPlayer1; // Player1
    public Transform cart; // Cart

    PlayerMotor motor;

    private void Start()
    {



    }

    private void Update()
    {
        
        // Se estiver interagindo com o cart
        if(isInteracting == true)
        {

            //CART
            cart.position = Vector3.MoveTowards(transform.position, targetPlayer1.position, speed * Time.deltaTime); // Move o cart
            transform.LookAt(targetPlayer1.position); // Faz o cart olhar para o player
            cart.transform.rotation = targetPlayer1.transform.rotation; // Rotaciona o cart junto com o player
            PlayerMotor.speed = 6.0f; // Diminui a velocidade do player

        }

        // Se nao estiver intergindo com o cart
        if (isInteracting == false)
        {

            PlayerMotor.speed = 6.0f; // Player volta a sua velocidade normal

        }

    }

    public void OnTriggerStay(Collider other)
    {
        
        // Apenas o player1 pode levar o cart
        if(other.CompareTag("Player1"))
        {

            // Quando apertar a tecla F e nao estiver interagindo com o cart, alem do tempo de cooldwon
            if(Input.GetKeyDown(KeyCode.F) && isInteracting == false && Time.time >= cooldown)
            {

                isInteracting = true; // Começa a interagir com o cart

                cooldown = Time.time + cooldownTimer; // Seta o cooldown

            }

            // Quando apertar a tecla F e estiver intergindo com o cart, alem do tempo de cooldown
            if (Input.GetKeyDown(KeyCode.F) && isInteracting == true && Time.time >= cooldown)
            {

                isInteracting = false; // Para de intergair com o cart

                cooldown = Time.time + cooldownTimer; // Seta o cooldwon

            }

        }

    }

}

