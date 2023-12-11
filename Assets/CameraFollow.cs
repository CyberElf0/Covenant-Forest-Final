using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // El Transform del jugador a seguir
    public float smoothSpeed = 5.0f;  // Velocidad suave de seguimiento
    public Vector3 offset = new Vector3(0, 2, -5);  // Desplazamiento desde el jugador
    public float rotationSpeed = 2.0f;  // Velocidad de rotaci�n de la c�mara
    public float minYOffset = 1.0f;  // Valor m�nimo para offset.y
    public float maxYOffset = 5.0f;  // Valor m�ximo para offset.y
    public float scrollSpeed = 1.0f;  // Velocidad de ajuste con la rueda del rat�n

    private float mouseX;  // Movimiento del mouse en el eje X

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Oculta y bloquea el cursor
        Cursor.visible = false;  // Hace que el cursor sea invisible
    }

    private void LateUpdate()
    {
        if (target == null || Time.timeScale == 0)
            return;

        // Actualiza el movimiento del mouse
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;

        // Ajusta el offset.y con la rueda del rat�n
        offset.y -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        offset.y = Mathf.Clamp(offset.y, minYOffset, maxYOffset);

        // Centra el cursor en la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Calcula la posici�n deseada de la c�mara
        Quaternion rotation = Quaternion.Euler(0, mouseX, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        // Suaviza el movimiento de la c�mara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Mira al jugador
        transform.LookAt(target);
    }
}
