using UnityEngine;

public class Dummy : MonoBehaviour
{
    public Animator anim;
    public string animacionDanio = "Danio";  // Nombre de la animación de daño

    private void Start()
    {
        // Obtén el componente Animator del objeto
        anim = GetComponent<Animator>();

        // Asegúrate de que el componente Animator está presente
        if (anim == null)
        {
            Debug.LogError("El objeto no tiene un componente Animator.");
        }
    }

    public void ReproducirAnimacionDanio()
    {
        // Reproduce la animación de daño
        anim.SetTrigger(animacionDanio);
    }
}
