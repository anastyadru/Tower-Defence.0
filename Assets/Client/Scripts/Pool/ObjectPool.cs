// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Bullet bulletPrefab;
    private readonly Dictionary<Type, Queue<IPoolable>> poolDictionary = new();

    public void PrePool<T>(T prefab, int count) where T : MonoBehaviour, IPoolable
    {
        var type = typeof(T);
        if (!poolDictionary.ContainsKey(type))
        {
            var objectPool = new Queue<IPoolable>();
            for (int i = 0; i < count; i++)
            {
                var obj = Instantiate(prefab);
                obj.gameObject.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary[type] = objectPool;
        }
    }

    public T Get<T>() where T : MonoBehaviour, IPoolable
    {
        if (poolDictionary.TryGetValue(typeof(T), out var objectPool) && objectPool.Count > 0)
        {
            return (T)objectPool.Dequeue();
        }
        return null;
    }

    public void Release<T>(T poolableObject) where T : MonoBehaviour, IPoolable
    {
        if (poolDictionary.TryGetValue(typeof(T), out var objectPool))
        {
            objectPool.Enqueue(poolableObject);
            poolableObject.OnRelease();
        }
    }
}