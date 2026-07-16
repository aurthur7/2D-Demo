using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase2AttackType : MonoBehaviour
{
    public float angle;
    public Vector3 dir;
    public int bulletcount=16;
    private GameObject flamecircle;
    public void attacktypechoser()
    {
        int typecount = flamecircle == null ? 3 : 2;
        int a=Random.Range(0,typecount);
        switch (a)
        {
            case 0:
                type1();
                break;
            case 1:
                type2(); 
                break;
            case 2:
                type3();
                break;
        }
    }
    public void type1()
    {
        GameObject obj = PoolManager.Instance.get("BulletCircle");
        obj.GetComponent<BulletCircleMove>().init(transform.position,Player.Instance.transform.position);
    }
    public void type2()
    {
        for (int i = 0; i < bulletcount; i++)
        {
            angle = (360f / bulletcount) * i;
            float rad = angle * Mathf.Deg2Rad;
            dir = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0).normalized;
            GameObject obj = PoolManager.Instance.get("Bullet");
            obj.GetComponent<BulletMove>().init(dir, transform.position);
        }
    }
    public void type3()
    {
        if (flamecircle!=null)
        {
            return ;
        }
        flamecircle = PoolManager.Instance.get("FlameballCircle");
        flamecircle.transform.SetParent(transform);
        flamecircle.transform.localPosition=new Vector3(0,0,0);
    }
    public void ClearFlameCircle()
    {
        if (flamecircle == null)
        {
            return;
        }
        if (flamecircle.activeInHierarchy)
        {
            PoolManager.Instance.giveback("FlameballCircle", flamecircle);
        }
        flamecircle = null;
    }
}
