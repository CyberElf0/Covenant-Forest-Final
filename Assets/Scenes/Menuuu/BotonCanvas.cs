using UnityEngine;
using UnityEngine.UI;

public class BotonCanvas : MonoBehaviour
{
    public Image imagenActivar;

    private void Start()
    {
        // Aseg�rate de que la imagen est� desactivada al inicio
        if (imagenActivar != null)
        {
            imagenActivar.gameObject.SetActive(false);
        }
    }

    // Este m�todo se llama cuando se presiona el bot�n
    public void OnBotonPresionado()
    {
        if (imagenActivar != null)
        {
            // Activa la imagen cuando se presiona el bot�n
            imagenActivar.gameObject.SetActive(true);
        }
    }
}
