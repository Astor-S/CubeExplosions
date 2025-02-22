using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _chanceSeparate = 100;

    private Rigidbody _rigidbody;
    private Renderer _renderer;

    private Spawner _spawner;

    public event Action<Cube> Clicked;

    public int ChanceSeparate => _chanceSeparate;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
    }

    public void Initialize(Vector3 scale, int chanceSeparate, Spawner spawner)
    {
        _spawner = spawner;
        transform.localScale = scale;
        _chanceSeparate = chanceSeparate;
        _renderer.material.color = UnityEngine.Random.ColorHSV();
    }

    public void AddForce(float force, float distance = 1)
    {
        float minDistance = 0.1f;
        float minValue = 5f;
        float maxValue = 10f;

        if (distance < minDistance)
            distance = minDistance;

        force /= distance;

        Vector3 direction = new Vector3(
                force * RandomizeValue(minValue, maxValue),
                force * RandomizeValue(minValue, maxValue),
                force * RandomizeValue(minValue, maxValue));

        _rigidbody.AddForce(direction);
    }

    public void Destroy()
    {
        Clicked?.Invoke(this);
        Destroy(gameObject);
    }

    private float RandomizeValue(float minValue, float maxValue) => UnityEngine.Random.Range(minValue, maxValue);
}