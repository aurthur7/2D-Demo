using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchStateController : MonoBehaviour
{
    public enum cunrrentstate { none,chase,idle,wander,attackfront,attackup,attackdown,dead}
    public cunrrentstate state;
    public event System.Action<cunrrentstate> onstatechange;
    public Transform torchtransform;
    public TorchMove move;
    public Coroutine wandercoroutine;
    public Vector3 point;
    private void Awake()
    {
        torchtransform = GetComponent<Transform>();
        move = GetComponent<TorchMove>();
    }
    private void FixedUpdate()
    {
        if (state == cunrrentstate.attackfront || state == cunrrentstate.attackup || state == cunrrentstate.attackdown
            || state == cunrrentstate.dead||state==cunrrentstate.wander||state==cunrrentstate.idle)
        {
            return;
        }
        statejudge();
    }
    public void statechange(cunrrentstate newstate)
    {
        if (state == cunrrentstate.dead)
        {
            return;
        }
        if (state == newstate)
        {
            return;
        }
        else
        {
            state = newstate;
        }
        if (state == cunrrentstate.dead)
        {
            StopAllCoroutines();
            wandercoroutine = null;
        }
        onstatechange?.Invoke(state);
    }
    public void statejudge()
    {
        float distance = Vector2.Distance(torchtransform.position, Player.Instance.transform.position);
        Vector2 dir = torchtransform.position - Player.Instance.transform.position;
        if (distance > 1.5f)
        {
            statechange(cunrrentstate.chase);
        }
        else 
        {
            if (Mathf.Abs(dir.x) < Mathf.Abs(dir.y) && dir.y > 0)
            {
                statechange(cunrrentstate.attackdown);
            }
            else if (Mathf.Abs(dir.x) < Mathf.Abs(dir.y) && dir.y < 0)
            {
                statechange(cunrrentstate.attackup);
            }
            else
            {
                statechange(cunrrentstate.attackfront);
            }
        }
    }
    public void wanderstate()
    {
        if (state == cunrrentstate.wander)
        {
            randompoint();
            if (wandercoroutine == null)
            {
                wandercoroutine = StartCoroutine(wandering());
            }
        }
    }
    public void onattackend()
    {
        if (state == cunrrentstate.dead)
        {
            return;
        }
        statechange(cunrrentstate.wander);
        wanderstate();
    }
    IEnumerator wandering()
    {
        yield return new WaitUntil(() => hasarrived(point));
        if (state == cunrrentstate.dead)
        {
            wandercoroutine = null;
            yield break;
        }
        statechange(cunrrentstate.idle);
        yield return new WaitForSeconds(1);
        if (state == cunrrentstate.dead)
        {
            wandercoroutine = null;
            yield break;
        }
        statechange(cunrrentstate.chase);
        wandercoroutine = null;
    }
    public Vector3 randompoint()
    {
        float r = Random.Range(4, 6);
        float angle = Random.Range(0f, 360f);
        Vector3 vec = new Vector2(r * Mathf.Cos(angle * Mathf.Deg2Rad), r * Mathf.Sin(angle * Mathf.Deg2Rad));
        point = Player.Instance.transform.position + vec;
        return point;
    }
    public bool hasarrived(Vector3 vec)
    {
        if (Vector2.Distance(vec, torchtransform.position) < 0.01)
        {
            return true;
        }
        else
            return false;
    }
}
