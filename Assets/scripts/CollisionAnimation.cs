using UnityEngine;

public class CollisionAnimation : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with a specific tag or layer if needed
        // For example, you can use: if (collision.gameObject.CompareTag("Player"))
        if (other.transform.CompareTag("Armaaaaa")) { 
            Debug.Log("ATK " + other.name);
            // Play the animation when a collision occurs
            if (animator != null)
            {
                animator.SetTrigger("golpe"); // "PlayAnimation" is the name of the trigger parameter in the Animator
            }
        }
    }
}
