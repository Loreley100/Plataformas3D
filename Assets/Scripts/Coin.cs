using UnityEngine;

public class Coin : MonoBehaviour
{
    public int valor = 1;
    public float velocidadRotacion = 90f;

    void Update()
    {
        transform.Rotate(0f, velocidadRotacion * Time.deltaTime, 0f, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
                GameManager.Instance.AgregarMoneda(valor);
            Destroy(gameObject);
        }
    }
}
