using UnityEngine;

public class ActivarObjetos : MonoBehaviour
{
    public GameObject[] objetosAActivar; // Array de GameObjects que se activarán al tocar el collider

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Verifica si el objeto que tocó el collider tiene la etiqueta "Player"
            // Puedes ajustar la etiqueta según la configuración de tu jugador

            // Activa los GameObjects especificados
            foreach (GameObject objeto in objetosAActivar)
            {
                objeto.SetActive(true);
            }

            // Desactiva este GameObject si es necesario
            gameObject.SetActive(false);
        }
    }
}
