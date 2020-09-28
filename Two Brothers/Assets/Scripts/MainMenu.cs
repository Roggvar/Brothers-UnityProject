using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    // botao de PlayGame
    public void PlayGame ()
    {

        SceneManager.LoadScene("MainLevel"); // Troca de cena de acordo com o nome dado

    }

    // fecha a aplicaçao
    public void QUitGame ()
    {

        Application.Quit();

    }

}
