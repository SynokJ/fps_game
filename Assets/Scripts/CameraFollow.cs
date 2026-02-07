using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerTr = default;

    private Vector3 _positionOffset = default;

    private void Start()
    {
        //                  cameraTr - playerTr
        _positionOffset = transform.position - _playerTr.position;
    }

    private void Update()
    {
        transform.position = _playerTr.position + _positionOffset;
    }
}
