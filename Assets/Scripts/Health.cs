using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyParticle;
    [SerializeField] private int healthPoints;
    [SerializeField] private int damagePoints;
    [SerializeField] private Text healthText;

    private int currentHelthPoints = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHelthPoints -= damagePoints;
            collision.gameObject.SetActive(false);

            if (currentHelthPoints <= 0)
            {
                ParticleSystem tempParticle = Instantiate(_destroyParticle, transform.position, Quaternion.identity);
                tempParticle.Play();
                Destroy(gameObject);
            }
        }
    }

    private void Awake()
    {
        currentHelthPoints = healthPoints;
    }

    private void Update()
    {
        healthText.text = currentHelthPoints.ToString();
    }
}
