// Coded by Tales Mariano - TalesMariano.com
// Based on the folowing resources
// https://www.mathsisfun.com/sine-cosine-tangent.html

using UnityEngine;

public class PathMaker : MonoBehaviour
{
    public Transform target1;
    Vector3 posTarget1;


    public Transform target2;
    Vector3 posTarget2;

    public Transform roadEntry;
    Vector3 posroadEntry;

    float distanceRoad;

    [HideInInspector]
    public float floorHeight = 0;


    void Start()
    {
        UpdatePositions();
    }
    

    void UpdatePositions()
    {
        posTarget1 = target1.position;
        posTarget1.y = floorHeight;

        posTarget2 = target2.position;
        posTarget2.y = floorHeight;

        posroadEntry = roadEntry.position;
        posroadEntry.y = floorHeight;

        CalculateDistanceRoad();
    }

    /// <summary>
    /// Calculate foward distance from road based on target 1
    /// </summary>
    void CalculateDistanceRoad()
    {
        float _distanceTarget = Vector3.Distance(target1.position, roadEntry.position);


        Vector3 targetDir = target1.position - roadEntry.position; //tira a direcao que se olha
        float _angleBetween = Vector3.Angle(target1.forward, targetDir); // pega o angulo


        float _adjacent = Mathf.Cos(_angleBetween * Mathf.Deg2Rad) * _distanceTarget;

        float _oposite = Mathf.Sin(_angleBetween * Mathf.Deg2Rad) * _distanceTarget;

        distanceRoad = _adjacent;
    }

    void OnDrawGizmos()
    {

        UpdatePositions();


        //Draw road path

        Gizmos.color = Color.red;

        Gizmos.DrawLine(posTarget1, posTarget1 - (target1.forward * distanceRoad));
        Gizmos.DrawLine(posroadEntry, posTarget1 - (target1.forward * distanceRoad));


        //Draw target path

        Gizmos.color = Color.yellow;

        Vector3 middle1 = posTarget1 - (target1.forward * distanceRoad);
        Vector3 middle2 = posTarget2 - (target2.forward * distanceRoad);



        //midle 1
        Gizmos.DrawLine(posTarget1, middle1);

        //midle 2
        Gizmos.DrawLine(posTarget2, middle2);

        //middle line
        Gizmos.DrawLine(middle1, middle2);

    }
}
