using UnityEngine;

public class PlayDestroySound : MonoBehaviour
{
    [SerializeField] private AudioSource AS;


    private void Awake()
    {
        AS = GetComponent<AudioSource>();
        AS.Play();
    }
}
