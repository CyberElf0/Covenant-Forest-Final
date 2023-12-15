using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ReproductorDeAudioEnLoopContinuo : MonoBehaviour
{
    public AudioClip clip; // El archivo de audio que se reproducirá

    private AudioSource audioSource;

    void Start()
    {
        // Asegúrate de que hay un AudioSource en el GameObject actual
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("Se requiere un componente AudioSource en el GameObject.");
            return;
        }

        // Configura el clip de audio y habilita el bucle continuo
        audioSource.clip = clip;
        audioSource.loop = true;

        // Inicia la reproducción
        audioSource.Play();
    }
}
