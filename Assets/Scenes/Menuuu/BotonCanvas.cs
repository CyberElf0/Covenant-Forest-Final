using UnityEngine;
using UnityEngine.UI;

public class BotonCanvas : MonoBehaviour
{
    public Image imagenActivar;

    private void Start()
    {
        // Asegúrate de que la imagen esté desactivada al inicio
        if (imagenActivar != null)
        {
            imagenActivar.gameObject.SetActive(false);
        }
    }

    // Este método se llama cuando se presiona el botón
    public void OnBotonPresionado()
    {
        if (imagenActivar != null)
        {
            // Activa la imagen cuando se presiona el botón
            imagenActivar.gameObject.SetActive(true);
        }
    }
}
