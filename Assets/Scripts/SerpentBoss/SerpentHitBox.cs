using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SerpentHitBox : MonoBehaviour
{
    [SerializeField] ParticleSystem particlePrefab;
    public bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Sword"))
        {
            hit = true;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<DamagePlayer>().enabled = false;
            GetComponent<Light2D>().enabled = false;
            ParticleSystem _particles = Instantiate(particlePrefab, gameObject.transform.position, Quaternion.identity);
            _particles.Play();
            FindObjectOfType<SerpentHealth>().HealthCheck();
        }
    }
}
