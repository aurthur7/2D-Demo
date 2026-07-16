using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEvacuationController : MonoBehaviour
{
    public static MonsterEvacuationController Instance { get; private set; }
    private HashSet<MonsterEvacuate> evacuatemonster=new HashSet<MonsterEvacuate>();
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    public void register(MonsterEvacuate monster)
    {
        if (monster==null)
        {
            return;
        }
        evacuatemonster.Add(monster);
    }
    public void unregister(MonsterEvacuate monster) 
    {
        if (monster == null)
        {
            return;
        }
        evacuatemonster.Remove(monster);
    }
    public void  startevacuateall()
    {
        foreach (MonsterEvacuate monster in new List<MonsterEvacuate>(evacuatemonster))
        {
            monster.evacuate();
        }
    }
    public bool allevacuated()
    {
        return evacuatemonster.Count ==0;
    }
}
