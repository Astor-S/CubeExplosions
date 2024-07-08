using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _baseRadius = 2f;
    [SerializeField] private float _power = 10f;

    public void Explode(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            cube.AddForce(_power);
        }
    }
}