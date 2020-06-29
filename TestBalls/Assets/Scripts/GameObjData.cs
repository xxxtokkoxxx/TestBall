using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GameObjData : MonoBehaviour
{
    //стартові позиції префабів
    [HideInInspector]
    public Vector3 floorStartPos { get; private set; }
    [HideInInspector]
    public Vector3 cellingStartPos { get; private set; }

    //ІД для об'єкта в пул
    [HideInInspector]
    public int currentCellingObj_ID = 0;
    [HideInInspector]
    public int currentFloorObj_ID = 0;
    public int objCount;//максимальнаа кількість об'єктів
    //розміри префабів
    public float minScale;
    public float maxScale;

    public Transform cellPoolParent, floorPoolParent;//батьківські об'єкти для пула префабів

    private void Awake()
    {
        cellPoolParent = cellPoolParent.transform;//ініцілазація батьківських об'єктів
        floorPoolParent = floorPoolParent.transform;
    }

    private void Start()
    {
        floorStartPos = new Vector3 (15, -1.55f, 0);
        cellingStartPos = new Vector3 (15, 4.8f, 0);
    }
}
