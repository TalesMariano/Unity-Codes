// Code by Tales Mariano - TalesMariano.com
// References:
// https://docs.unity3d.com/ScriptReference/Mathf.PerlinNoise.html

using UnityEngine;

public class PerlinFloatingVFX : MonoBehaviour
{
    Vector3 startPos;

    float randomValue; // a random number so intances moves slighet diferrent

    public float speed = 0.5f; //how fast the obj moves
    public float changeScale = 3; // how far it goes

    void Start()
    {
        randomValue = Random.value * 10;
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 posPlus = Vector3.zero;

        posPlus.x = Mathf.PerlinNoise(randomValue + 0, Time.timeSinceLevelLoad* speed) -0.5f; //subtract 0.5 because perlirnoise return value between 0 and 1
        posPlus.y = Mathf.PerlinNoise(randomValue + 1, Time.timeSinceLevelLoad* speed) - 0.5f;
        posPlus.z = Mathf.PerlinNoise(randomValue + 2, Time.timeSinceLevelLoad * speed) - 0.5f;

        transform.position = startPos + posPlus * changeScale;
    }
}
