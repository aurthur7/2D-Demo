using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCreat : MonoBehaviour
{
    private int a;
    private int b;
    private float minoffset=0;
    private float maxoffset=2;
    public float time = 0;
    private int monstercount = 5;
    public float phasechangeingtime = 0;
    private bool bossfightintro=false;
    private bool bossfight=false;
    public MonsterKillTracker tracker;
    private List<GameObject> monsterlist = new List<GameObject>();
    private void OnEnable()
    {
        tracker.achievekillnumber += IK;
    }
    private void OnDisable()
    {
        tracker.achievekillnumber -= IK;
    }
    public void IK()
    {
        bossfightintro = true;
    }
    private void FixedUpdate()
    {
        if (bossfightintro == true||bossfight==true)
        {
            return;
        }
        monstercreat();
    }
    public Vector2 RandomPoint()
    {
        Camera cam = Camera.main;
        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;
        Vector2 center = cam.transform.position;
        float left = center.x - halfWidth;
        float right = center.x + halfWidth;
        float bottom = center.y - halfHeight;
        float top = center.y + halfHeight;
        //0ÉÏ£¬1ÏÂ£¬2×ó£¬3ÓÒ
        int side = Random.Range(0, 4);
        switch (side)
        {
            case 0: // ÆÁÄ»ÉÏ·½
                return new Vector2(
                    Random.Range(left - maxoffset, right + maxoffset),
                    Random.Range(top + minoffset, top + maxoffset)
                );
            case 1: // ÆÁÄ»ÏÂ·½
                return new Vector2(
                    Random.Range(left - maxoffset, right + maxoffset),
                    Random.Range(bottom - maxoffset, bottom - minoffset)
                );
            case 2: // ÆÁÄ»×ó²à
                return new Vector2(
                    Random.Range(left - maxoffset, left - minoffset),
                    Random.Range(bottom - maxoffset, top + maxoffset)
                );
            case 3: // ÆÁÄ»ÓÒ²à
                return new Vector2(
                    Random.Range(right + minoffset, right + maxoffset),
                    Random.Range(bottom - maxoffset, top + maxoffset)
                );
        }
        return center;
    }
    public void monstercreat()
    {
        time += Time.fixedDeltaTime;
        if (time > 1)
        {
            time = 0;
            a = 1;
            a = Random.Range(0, 3);
            if (a == 0)
            {
                GameObject obj= PoolManager.Instance.get("Monster_TNT");
                obj.transform.position = RandomPoint();
            }
            else if (a == 1)
            {
                GameObject obj= PoolManager.Instance.get("Monster_Barrel");
                obj.transform.position = RandomPoint();
            }
            else
            {
                GameObject obj= PoolManager.Instance.get("Monster_Torch");
                obj.transform.position = RandomPoint();
            }
        }
    }
    public GameObject changephasemonstercreat()
    {
        b = Random.Range(0, 3);
        if (b == 0)
        {
            GameObject obj= PoolManager.Instance.get("Monster_TNT");
            obj.transform.position = RandomPoint();
            return obj;
        }
        else if (b == 1)
        {
            GameObject obj= PoolManager.Instance.get("Monster_Barrel");
            obj.transform.position = RandomPoint();
            return obj;
        }
        else
        {
            GameObject obj= PoolManager.Instance.get("Monster_Torch");
            obj.transform.position = RandomPoint();
            return obj;
        }
    }
    public void phasechangingmonsterlist()
    {
        monsterlist.Clear();
        for (int i = 0; i < monstercount; i++)
        {
            monsterlist.Add( changephasemonstercreat());
        }
    }
    public bool monstercleared()
    {
        monsterlist.RemoveAll(monster=>monster==null||monster.activeInHierarchy==false);
        return monsterlist.Count==0;
    }
}
