using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerpentHealth : MonoBehaviour
{
    [SerializeField] ParticleSystem _particles;

    [SerializeField]
    int health = 10;
    // Start is called before the first frame update
    void Update()
    {
    }

    public void HealthCheck()
    {
        --health;
        if (health <= 0)
        {
            _particles.transform.position = gameObject.transform.position;
            _particles.Play();
            FindObjectOfType<SperpentSpawner>().KillSperp();
            gameObject.SetActive(false);
        }
    }
}
