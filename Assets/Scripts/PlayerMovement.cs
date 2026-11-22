using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float velocidad = 6f;
    public float fuerzaSalto = 2f;
    public float gravedad = -9.81f;

    private CharacterController controller;
    private float velocidadVertical;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Keyboard teclado = Keyboard.current;

        if (teclado == null)
            return;

        float x = 0f;
        float z = 0f;

        if (teclado.aKey.isPressed) x -= 1f;
        if (teclado.dKey.isPressed) x += 1f;
        if (teclado.wKey.isPressed) z += 1f;
        if (teclado.sKey.isPressed) z -= 1f;

        Vector3 movimiento = new Vector3(x, 0, z);
        movimiento = Vector3.ClampMagnitude(movimiento, 1f);

        if (controller.isGrounded)
        {
            if (velocidadVertical < 0)
                velocidadVertical = -2f;

            if (teclado.spaceKey.wasPressedThisFrame)
            {
                velocidadVertical =
                    Mathf.Sqrt(fuerzaSalto * -2f * gravedad);
            }
        }

        velocidadVertical += gravedad * Time.deltaTime;

        Vector3 desplazamiento = movimiento * velocidad;
        desplazamiento.y = velocidadVertical;

        controller.Move(desplazamiento * Time.deltaTime);
    }
}
