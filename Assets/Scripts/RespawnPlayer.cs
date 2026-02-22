using UnityEngine;
using StarterAssets;

[RequireComponent(typeof(CharacterController))]
public class RespawnPlayer : MonoBehaviour
{
    public float yThreshold = -5f;
    public AudioClip respawnSound;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private CharacterController characterController;
    private ThirdPersonController thirdPersonController;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        characterController = GetComponent<CharacterController>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }

    void Update()
    {
        if (transform.position.y < yThreshold)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        characterController.enabled = false;

        transform.position = startPosition;
        transform.rotation = startRotation;

        characterController.enabled = true;

        if (respawnSound != null)
        {
            AudioSource.PlayClipAtPoint(respawnSound, transform.position);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Beast"))
        {
            Respawn();
        }
    }
}
