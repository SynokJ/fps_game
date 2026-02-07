using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _bulletOgirinPosition;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _weapon.Create(_bulletOgirinPosition.position);
            _weapon.Shoot(_bulletOgirinPosition.forward);
        }
    }
}
