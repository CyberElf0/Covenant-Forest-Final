using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Referencia a la animación de ataque del enemigo
    public Animator enemyAnimator;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el collider en contacto es el del jugador
        if (other.CompareTag("Player"))
        {
            // Activa la animación de ataque del enemigo
            enemyAnimator.SetTrigger("golpear");

            // Puedes agregar aquí cualquier lógica adicional que necesites al atacar al jugador
        }
    }
}
