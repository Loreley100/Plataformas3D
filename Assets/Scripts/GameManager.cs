using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int monedas = 0;
    public int vidas = 3;

    public Text textoMonedas;
    public Text textoVidas;
    public Text textoMensaje;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        ActualizarUI();
        if (textoMensaje != null) textoMensaje.text = "";
    }

    public void AgregarMoneda(int cantidad = 1)
    {
        monedas += cantidad;
        ActualizarUI();
    }

    public void PerderVida(int cantidad = 1)
    {
        if (vidas <= 0) return;
        vidas -= cantidad;
        if (vidas < 0) vidas = 0;
        ActualizarUI();
        if (textoMensaje != null)
        {
            if (vidas <= 0) textoMensaje.text = "Game Over";
            else textoMensaje.text = "-1 vida";
        }
    }

    public void ActualizarUI()
    {
        if (textoMonedas != null) textoMonedas.text = "Monedas: " + monedas;
        if (textoVidas != null) textoVidas.text = "Vidas: " + vidas;
    }
}
