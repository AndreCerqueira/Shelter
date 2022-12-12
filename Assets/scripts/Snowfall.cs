using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowfall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<ParticleSystem>().Simulate(2);
        this.GetComponent<ParticleSystem>().Play();
    }
}
