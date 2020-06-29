using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjController : MonoBehaviour
{
    [SerializeField]
    private GameObjData _gameObjData;

    public GameObject cellingPrefab, floorPrefab;   
    public GameObject[] cell;
    public GameObject[] floor;

    void Start()
    {
        ObjectInitialization(cell, cellingPrefab, _gameObjData.cellingStartPos, _gameObjData.cellPoolParent);
        ObjectInitialization(floor, floorPrefab, _gameObjData.floorStartPos, _gameObjData.floorPoolParent);

        //викликаєм бескінечну корутину з методом "пула об'єктів" та повторюєм його відповідно до заданих параметрів
        StartCoroutine(ObjectGenerate(_gameObjData.currentCellingObj_ID,
            1.5f, 
            _gameObjData.cellingStartPos, 
            _gameObjData.cellPoolParent));//стеля

        StartCoroutine(ObjectGenerate(_gameObjData.currentFloorObj_ID, 
            1.5f, 
            _gameObjData.floorStartPos, 
            _gameObjData.floorPoolParent));//підлога
    }

    //генерація об'єктів на старті, в якості параметрів передано масив об'єктів для пула, сам префаб, стартова позиція та батьківський об'єкт
    private void ObjectInitialization(GameObject [] poolObject, 
        GameObject poolObjectPrefab, 
        Vector3 startPos, 
        Transform poolParent)
    {
        poolObject = new GameObject[_gameObjData.objCount];//визначення кількості об'єктів в масиві

        for (int i = 0; i < _gameObjData.objCount; i++)//цикл ініцілізації об'єктів
        {
           poolObject[i] = Instantiate(poolObjectPrefab, startPos, Quaternion.identity, poolParent);
           poolObject[i].SetActive(false);
        }
    }
    // корутин пула об'єктів, в якості параметрів передано: поточний об'єкт, час генерації, позиція об'єкта, батьківський об'єкт, звідки ми пулим
    IEnumerator ObjectGenerate(int current_ID, 
        float appearTime,
        Vector3 startPos, 
        Transform poolParent)
    {
        while (true)
        {
            yield return new WaitForSeconds(appearTime);
            GameObject obj = poolParent.GetChild(current_ID).gameObject;
            obj.SetActive(true);
            obj.transform.localScale = new Vector3(Random.Range(_gameObjData.minScale, _gameObjData.maxScale), transform.localScale.y, transform.localScale.z);
            obj.transform.position = startPos;
            current_ID++;

            if (current_ID > _gameObjData.objCount - 1)
            {
                current_ID = 0;
            }
        }
    }
}
