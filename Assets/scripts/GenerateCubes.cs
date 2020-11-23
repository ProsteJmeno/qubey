using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateCubes : MonoBehaviour
{
    public GameObject cubePrefab;
    public float randomOffset;
    public Vector3 scale = Vector3.one;
    public Vector3 dimensions;
    public Vector3 offset;

    void Start()
    {
        if(dimensions.x * dimensions.y * dimensions.z > 10_000)
        {
            throw new ArgumentException($"Can't generate more than {10_000} objects.");
        }

        for(var x = 0; x < dimensions.x; x++)
        {
            for(var y = 0; y < dimensions.y; y++)
            {
                for(var z = 0; z < dimensions.z; z++)
                {
                    var xPos = (x + offset.x) * scale.x + Random.value * randomOffset;
                    var yPos = (y + offset.y) * scale.y + Random.value * randomOffset;
                    var zPos = (z + offset.z) * scale.z + Random.value * randomOffset;
                    var position = new Vector3(xPos, yPos, zPos);
                    var cube = Instantiate(cubePrefab, position, Quaternion.identity);
                }
            }
        }
    }
}
