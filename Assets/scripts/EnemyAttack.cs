using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Referencia a la animaci�n de ataque del enemigo
    public Animator enemyAnimator;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el collider en contacto es el del jugador
        if (other.CompareTag("Player"))
        {
            // Activa la animaci�n de ataque del enemigo
            enemyAnimator.SetTrigger("golpear");

            // Puedes agregar aqu� cualquier l�gica adicional que necesites al atacar al jugador
        }
    }
}
