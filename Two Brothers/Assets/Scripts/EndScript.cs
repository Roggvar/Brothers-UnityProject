using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        
        if(other.CompareTag("Player1"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {

                SceneManager.LoadScene("Menu");

            }

        }

    }
}
