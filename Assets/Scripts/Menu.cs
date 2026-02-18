using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Método para iniciar el juego
    public void Jugar()
    {
        // Si el GameManager ya existe, reseteamos sus valores manualmente
        if (GameManager.instance != null)
        {
            GameManager.instance.vidas = 3;
            // Si tienes una variable de manzanas en el manager, ponla a 0 también
            // GameManager.instance.manzanas = 0; 
        }
        // Carga la escena del juego (asegúrate de que esté añadida en Build Settings)
        SceneManager.LoadScene("SampleScene"); // Cambia por el nombre de tu escena de juego
    }

    // Método para mostrar créditos (si tienes otra escena)
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