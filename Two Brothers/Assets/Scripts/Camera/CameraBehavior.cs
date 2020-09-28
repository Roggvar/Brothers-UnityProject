using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;

    public float pitch = 2f; // angulo da camera
    public float zoomSpeed = 4f; // velocidade do zoom
    public float minZoom = 5f; // zoom minimo
    public float maxZoom = 15f; // zoom maximo
    public float yawSpeed = 300f; // velocidade da rotaçao
    private float currentZoom = 10f; // zoom inicial
    private float currentYaw = 0f; // rotaçao inicial

    private void Update()
    {

        ChangePlayer();

    }

    private void LateUpdate()
    {

        CameraMovement();

    }

    // Gerencia o behavior da camera
    void CameraMovement()
    {

        //Zoom da camera
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        //Segue o target
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        //Rotaçao em volta do target
        transform.RotateAround(target.position, Vector3.up, currentYaw);

        //Rotação da camera
        if (Input.GetMouseButton(2))
        {

            currentYaw -= Input.GetAxis("Mouse X") * yawSpeed * Time.deltaTime;

        }

    }

    //Gerencia a mudança de player
    void ChangePlayer()
    {

        //Testa a tecla q
        if(Input.GetKeyDown(KeyCode.Q))
        {

            target = GameObject.FindGameObjectWithTag("Player1").transform; // Aloca o transform da camera para o novo objeto

            // Ativa os scripts de movimentaçao do Player1
            GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerController>().enabled = true;
            GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMotor>().enabled = true;

            // desativa os scripts de movimentaçao do Player2
            GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController>().enabled = false;
            GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMotor>().enabled = true;

        }

        //Testa a tecla e
        if (Input.GetKeyDown(KeyCode.E))
        {

            target = GameObject.FindGameObjectWithTag("Player2").transform; // Aloca o transform da camera para o novo objeto

            // desativa os scripts de movimentaçao do Player1
            GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerController>().enabled = false;
            GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMotor>().enabled = true;

            // Ativa os scripts de movimentaçao do Player2
            GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController>().enabled = true;
            GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMotor>().enabled = true;

        }

    }

}
