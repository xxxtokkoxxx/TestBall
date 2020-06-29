using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabMove : MonoBehaviour
{
    [SerializeField]
    private float prefabSpeed;

    private void Update()
    {
       transform.Translate(Vector3.left * prefabSpeed * Time.deltaTime);
       prefabSpeed += 0.0005f;//збільшення швидкості
    }
}
