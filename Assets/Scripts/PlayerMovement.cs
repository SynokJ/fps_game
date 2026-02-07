using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private CharacterController _characterController = default;
    [SerializeField] private Animator _weaponAnimator;

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // Left Arrow and Right Arrow
        float moveY = Input.GetAxis("Vertical"); // Up and Down

        Vector3 direction = transform.forward * moveY + transform.right * moveX;
        _characterController.Move(direction * _speed * Time.deltaTime); // 1 -> 100%     0.5 -> 50% 

        bool isMoving = moveX != 0 || moveY != 0;
        _weaponAnimator.SetBool("isMoving", isMoving);
    }
}
