using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyParticle;
    [SerializeField] private int _healthPoints;
    [SerializeField] private int _damagePoints;
    [SerializeField] private Slider _healthSlider;

    private int _currentHelthPoints = 0;
    private int _originHealthPoints = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _currentHelthPoints -= _damagePoints;
            collision.gameObject.SetActive(false);

            if (_currentHelthPoints <= 0)
            {
                ParticleSystem tempParticle = Instantiate(_destroyParticle, transform.position, Quaternion.identity);
                tempParticle.Play();
                Destroy(gameObject);
            }
        }
    }

    private void Awake()
    {
        _currentHelthPoints = _healthPoints;
        _originHealthPoints = _healthPoints;
    }

    private void Update()
    {
        _healthSlider.value = _currentHelthPoints / (float)_originHealthPoints;
    }
}
