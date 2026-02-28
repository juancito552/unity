using UnityEngine;
using UnityEngine.InputSystem;

public class SaltoVR : MonoBehaviour
{
    public float fuerzaSalto = 5f;
    public float gravedad = 9.81f;
    public InputActionProperty botonSalto;
    public InputActionProperty teclaEspacio; // Nueva línea para el teclado

    private CharacterController _controller;
    private Vector3 _direccionMovimiento;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        teclaEspacio.action.Enable(); // Activa el teclado
    }

    void Update()
    {
        if (_controller.isGrounded)
        {
            _direccionMovimiento.y = -0.5f;

            // Detecta el botón de VR o la tecla configurada
            if (botonSalto.action.WasPressedThisFrame() || teclaEspacio.action.WasPressedThisFrame())
            {
                _direccionMovimiento.y = fuerzaSalto;
            }
        }

        _direccionMovimiento.y -= gravedad * Time.deltaTime;
        _controller.Move(_direccionMovimiento * Time.deltaTime);
    }
}