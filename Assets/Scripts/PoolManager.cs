using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager :MonoBehaviour
{
    public static PoolManager Instance { get; private set; }
    private PoolManager()
    {
        
    }
    public Dictionary<string,Queue<GameObject>> monsterpool=new Dictionary<string,Queue<GameObject>>();
    public GameObject get(string name)
    {
        GameObject obj=null;
        if (monsterpool.ContainsKey(name))
        {
            if (monsterpool[name].Count > 0)
            {

                obj = monsterpool[name].Dequeue();
            }
            else
            {
                obj = Instantiate(Resources.Load<GameObject>(name));
            }
        }
        else
        {
            monsterpool.Add(name, new Queue<GameObject>());
            obj = Instantiate(Resources.Load<GameObject>(name));
        }
        obj.SetActive(true);
        obj.GetComponent<IPoolable>().onSpawned();
        return obj;
    }
    public void giveback(string name,GameObject obj)
    {
        obj.GetComponent<IPoolable>().onDespawned();
        obj.SetActive(false);
        if (!monsterpool.ContainsKey(name))
        {
            monsterpool.Add(name, new Queue<GameObject>());
            monsterpool[name].Enqueue(obj);
        }
        else
        {
            monsterpool [name].Enqueue(obj);
        }
    }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
public interface IPoolable
{
    void onSpawned();
    void onDespawned();
}
