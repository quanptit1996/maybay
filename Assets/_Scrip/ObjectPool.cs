using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool instance;

    private List<GameObject> _poolObject = new List<GameObject>();
    private List<GameObject> _poolExObject = new List<GameObject>();
    private List<GameObject> _poolEnemy = new List<GameObject>();

    private int _amountToPool = 8;
    [SerializeField] private GameObject objPool;
    [SerializeField] private GameObject exObjPool;
    [SerializeField] private GameObject enemyPool;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0 ; i < _amountToPool; i++)
        {
            GameObject obj = Instantiate(objPool);
            obj.SetActive(false);
            _poolObject.Add(obj);
        }
        for (int i = 0 ; i < _amountToPool; i++)
        {
            GameObject obj = Instantiate(exObjPool);
            obj.SetActive(false);
            _poolExObject.Add(obj);
        }
        for (int i = 0 ; i < _amountToPool; i++)
        {
            GameObject obj = Instantiate(enemyPool);
            obj.SetActive(false);
            _poolEnemy.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0;i < _poolObject.Count; i++)
        {
            if (!_poolObject[i].activeInHierarchy)
            {
                return _poolObject[i];
            }
        }
        return null;
    }
    
    public GameObject GetExPooledObject()
    {
        for (int i = 0;i < _poolExObject.Count; i++)
        {
            if (!_poolExObject[i].activeInHierarchy)
            {
                return _poolExObject[i];
            }
        }
        return null;
    }
    
    public GameObject GetEnemyPooledObject()
    {
        for (int i = 0;i < _poolEnemy.Count; i++)
        {
            if (!_poolEnemy[i].activeInHierarchy)
            {
                return _poolEnemy[i];
            }
        }
        return null;
    }
    
}
