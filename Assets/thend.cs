using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thend : MonoBehaviour
{
    public ParticleSystem Particles1;
    public ParticleSystem Particles2;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Particles1.gameObject.SetActive(true);
            Particles2.gameObject.SetActive(true);
        }
    }
}
