using UnityEngine;
using UnityEngine.UI;

public class BotonDesactivarImagen : MonoBehaviour
{
    public Image imagenADesactivar;

    private void Start()
    {
        // Asegúrate de que la imagen esté activada al inicio (si así lo deseas)
        if (imagenADesactivar != null)
        {
            imagenADesactivar.gameObject.SetActive(true);
        }
    }

    // Este método se llama cuando se presiona el botón
    public void OnBotonPresionado()
    {
        if (imagenADesactivar != null)
        {
            // Desactiva la imagen cuando se presiona el botón
            imagenADesactivar.gameObject.SetActive(false);
        }
    }
}
