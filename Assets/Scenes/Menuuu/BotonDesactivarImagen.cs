using UnityEngine;
using UnityEngine.UI;

public class BotonDesactivarImagen : MonoBehaviour
{
    public Image imagenADesactivar;

    private void Start()
    {
        // Aseg�rate de que la imagen est� activada al inicio (si as� lo deseas)
        if (imagenADesactivar != null)
        {
            imagenADesactivar.gameObject.SetActive(true);
        }
    }

    // Este m�todo se llama cuando se presiona el bot�n
    public void OnBotonPresionado()
    {
        if (imagenADesactivar != null)
        {
            // Desactiva la imagen cuando se presiona el bot�n
            imagenADesactivar.gameObject.SetActive(false);
        }
    }
}
