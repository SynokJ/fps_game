using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float _sensetivity = 100.0f;
    [SerializeField] private Transform _playerTr = default;

    private float _rotY = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensetivity * Time.deltaTime;

        _rotY -= mouseY;  // _rotY = _rotY - mouseY -> _rot -= mouseY
        _rotY = Mathf.Clamp(_rotY, -90.0f, 90.0f); 

        transform.localRotation = Quaternion.Euler(_rotY, 0, 0);
        _playerTr.Rotate(Vector3.up * mouseX);
    }
}
