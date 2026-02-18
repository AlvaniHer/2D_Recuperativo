using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu: MonoBehaviour
{
    // Método para iniciar el juego
    public void Jugar()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.vidas = 3;
            // GameManager.instance.manzanas = 0; 
        }
        // Carga la escena del juego 
        SceneManager.LoadScene("SampleScene");
    }

    // Método para reiniciar el juego
    public void Reinicio()
    {
        SceneManager.LoadScene("juego"); 
    }

    // Método para salir del juego
    public void Salir()
    {

        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

}