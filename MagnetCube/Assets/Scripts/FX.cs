using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour
{

    [SerializeField] private ParticleSystem explosionFX;
    ParticleSystem.MainModule explosionFXMainModule;
    public static FX Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        explosionFXMainModule = explosionFX.main;
    }

    public void StartExplosionFX(Vector3 position,Color color)
    {
        explosionFXMainModule.startColor = new ParticleSystem.MinMaxGradient(color);
        explosionFX.transform.position = position;
        explosionFX.Play();
    }
}
