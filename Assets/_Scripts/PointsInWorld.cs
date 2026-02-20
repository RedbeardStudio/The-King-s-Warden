using System.Collections.Generic;
using UnityEngine;

public class PointsInWorld : MonoBehaviour
{

    //Vector3 pointInWorld;
    List<Vector3> points = new List<Vector3>();
    public GameObject treeModel;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 100; i++)
        {
            
            points.Add(new Vector3(Random.Range(-50f, 50f), 0f, Random.Range(-50f, 50f)));
//            Debug.Log("Points in points: " + points);
        }

        foreach (Vector3 point in points)
        {
           Instantiate(treeModel, point, Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.red;
        foreach (Vector3 point in points)
        {
            Gizmos.DrawSphere(point, 0.1f);
            Gizmos.color = UnityEngine.Color.green;
        }
        
        }
}
