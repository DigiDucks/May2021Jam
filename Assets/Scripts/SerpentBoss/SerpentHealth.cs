using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerpentHealth : MonoBehaviour
{
    [SerializeField] ParticleSystem _particles;
    SerpentHitBox[] health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponentsInChildren<SerpentHitBox>();
    }

    public void HealthCheck()
    {
        foreach(SerpentHitBox box in health)
        {
            if (!box.hit)
                return;
        }
        _particles.transform.position = gameObject.transform.position;
        _particles.Play();
        FindObjectOfType<SperpentSpawner>().KillSperp();
        gameObject.SetActive(false);

    }
}
