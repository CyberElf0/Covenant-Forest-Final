using UnityEngine;

public class Dummy : MonoBehaviour
{
    public Animator anim;
    public string animacionDanio = "Danio";  // Nombre de la animaci�n de da�o

    private void Start()
    {
        // Obt�n el componente Animator del objeto
        anim = GetComponent<Animator>();

        // Aseg�rate de que el componente Animator est� presente
        if (anim == null)
        {
            Debug.LogError("El objeto no tiene un componente Animator.");
        }
    }

    public void ReproducirAnimacionDanio()
    {
        // Reproduce la animaci�n de da�o
        anim.SetTrigger(animacionDanio);
    }
}
