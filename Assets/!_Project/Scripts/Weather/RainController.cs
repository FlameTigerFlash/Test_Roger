using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class RainController : MonoBehaviour
{
    [SerializeField] private WeatherSystem _weatherSystem;
    [SerializeField] private float _maxEmissionRate = 2000f;
    [SerializeField] private float _fallSpeed = 20f;
    [SerializeField] private float _windHorizontalFactor = 5f;

    private ParticleSystem _particles;

    private void Awake()
    {
        _particles = GetComponent<ParticleSystem>();

        var velocity = _particles.velocityOverLifetime;
        velocity.enabled = true;
        velocity.space = ParticleSystemSimulationSpace.World;
    }

    private void Update()
    {
        float intensity = _weatherSystem.Intensity;

        var emission = _particles.emission;
        emission.rateOverTime = _maxEmissionRate * intensity;

        Vector3 windDir = _weatherSystem != null ? _weatherSystem.WindDirectionVector : Vector3.forward;
        float windForce = _weatherSystem != null ? _weatherSystem.WindForce : 0f;

        Vector3 wind = windDir * (windForce * _windHorizontalFactor);
        wind.y = -_fallSpeed;

        var velocity = _particles.velocityOverLifetime;
        velocity.x = wind.x;
        velocity.y = wind.y;
        velocity.z = wind.z;
    }
}