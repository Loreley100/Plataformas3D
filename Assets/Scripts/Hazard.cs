using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int dano = 1;
    public float tiempoInvulnerabilidad = 1.0f;
    private float ultimoGolpe = -999f;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (Time.time - ultimoGolpe < tiempoInvulnerabilidad) return;
        ultimoGolpe = Time.time;
        if (GameManager.Instance != null)
            GameManager.Instance.PerderVida(dano);
    }
}
