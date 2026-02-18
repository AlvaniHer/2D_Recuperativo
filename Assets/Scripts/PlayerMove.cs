using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private float velocidad = 2f; //velocidad del jugador
    private Rigidbody2D rb;
    private Vector2 mov;
    private float movementX;
    private float movementY;
    public float fuerzaSalto = 4f; //lit fuerza de salto
    //para el suelo
    public LayerMask sueloLayer; //asigna la capa suelo aqui
    public Transform comprobadorSuelo; //un punto en los pies del personaje
    public float radioComprobador = 0.1f;
    public bool estaensuelo;



    private void Start()
    {
        if (GameManager.instance != null)
        {
            //se reinician las frutas del Manager a 0 al cargar la escena
            GameManager.instance.puntos = 0;

            //se actualizan los textos
            GameManager.instance.ActualizarTexto(); // Mostrará "zanahoria: 0"
            GameManager.instance.ActualizarVidasUI(GameManager.instance.vidas); // Mostrará las vidas que quedaron
        }
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue movimientos)
    {
        // se leen las teclas del movimiento que hace el usuario
        mov = movimientos.Get<Vector2>();
        movementX = mov.x;
        movementY = mov.y;
        Debug.Log(mov.x + " , " + mov.y);
        //orientar al jugador
        if (estaensuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);

        }

    }
    private void FixedUpdate()
    {
        // Creamos el vector de movimiento (X = horizontal)
        Vector2 movimiento = new Vector2(mov.x, 0f);

        // Aplicamos la velocidad al Rigidbody2D
        rb.linearVelocity = new Vector2(movimiento.x * velocidad, rb.linearVelocity.y);
        // mantenemos la velocidad vertical actual (gravedad)

        //detecte el suelo 
        estaensuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, radioComprobador, sueloLayer);


    }
    private void OnJump(InputValue movimientos)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fruta")
        {
            GameManager.instance.SumarPuntos(1);
            Destroy(collision.gameObject);
        }

        // Si toca un enemigo
        if (collision.gameObject.tag == "enemigo")
        {
            RestarVida();
        }
        //cuando llega a la bandera 
        if (collision.gameObject.tag == "finish")
        {
            Victoria();
        }

    }
    //metodo de restar vida
    void RestarVida()
    {
        GameManager.instance.vidas--; // Restamos al manager, no al jugador
        int vidasActuales = GameManager.instance.vidas;
        GameManager.instance.ActualizarVidasUI(vidasActuales);
        if (vidasActuales <= 0)
        {
            SceneManager.LoadScene("Menu");// o escena de derrota
        }
        else
        {
            ReiniciarNivel(); //si aun quedan vidas se reinicia el nivel
        }
    }
    //Y este metodo
    void ReiniciarNivel()
    {
        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Victoria()
    {
        // Cargar la escena de victoria
        SceneManager.LoadScene("Victoria"); // Cambia por el nombre de tu escena
    }


}
