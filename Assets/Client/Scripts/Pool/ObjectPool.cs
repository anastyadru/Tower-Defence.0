// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPool : MonoBehaviour
{
    public Bullet bulletPrefab;
    
    public Dictionary<Type, Queue<IPoolable>> poolDictionary = new Dictionary<Type, Queue<IPoolable>>();
    private DiContainer container;
    
    [Inject]
    public void Construct(DiContainer container)
    {
        this.container = container;
    }

    public void Start()
    {
        PrePool<Bullet>(bulletPrefab, 200, poolDictionary);
    }

    public void PrePool<T>(T prefab, int count, Dictionary<Type, Queue<IPoolable>> poolDict) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (!poolDict.ContainsKey(type))
        {
            Queue<IPoolable> objectPool = new Queue<IPoolable>();
            for (int i = 0; i < count; i++)
            {
                T obj = GameObject.Instantiate(prefab) as T;
                obj.gameObject.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDict.Add(type, objectPool);
        }
    }

    public T Get<T>() where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (poolDictionary.ContainsKey(type) && poolDictionary[type].Count > 0)
        {
            IPoolable obj = poolDictionary[type].Dequeue();
            return (T)obj;
        }
    
        return null;
    }

    public void Release<T>(T poolableObject) where T : MonoBehaviour, IPoolable
    {
        Type type = typeof(T);
        if (poolDictionary.ContainsKey(type))
        {
            Queue<IPoolable> objectPool = poolDictionary[type];
            objectPool.Enqueue(poolableObject);
            poolableObject.OnRelease();
        }
    }
    
    public Bullet GetBullet()
    {
        return Get<Bullet>();
    }

    public void ReleaseBullet(Bullet bullet)
    {
        Release(bullet);
    }
}