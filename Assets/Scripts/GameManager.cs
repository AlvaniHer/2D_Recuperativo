

using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int puntos = 0;
    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoVidas;    //el objeto texto de vidas
    //para las vidas
    public int vidas = 3; //contador

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //el manager no muera al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        Debug.Log("Puntos actuales: " + puntos); // Esto te confirmará en consola si los puntos suben
        ActualizarTexto();
    }

    public void ActualizarTexto()
    {
        // Esto asegura que tras reiniciar la escena, encuentre el nuevo objeto
        GameObject obj = GameObject.Find("textoConteo");

        if (obj != null)
        {
            textoPuntos = obj.GetComponent<TextMeshProUGUI>();
            textoPuntos.text = "zanahorias: " + puntos.ToString();
        }
        else
        {
            Debug.LogWarning("No se encontró el objeto 'textoconteo' en la jerarquía.");
        }
    }
    //metodo para actualizar el texto de vidas
    public void ActualizarVidasUI(int v)
    {
        // Si el texto se pierde al reiniciar, busca la referencia de nuevo
        GameObject.Find("textovidas").GetComponent<TextMeshProUGUI>().text = "Vidas: " + v;
    }

}
