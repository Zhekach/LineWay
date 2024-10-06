using UnityEngine;

public class Portal : MonoBehaviour
{
    
    [SerializeField] private Transform _teleportPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.StopMove();
            playerMovement.transform.position = _teleportPoint.position;
        }
    }

}
