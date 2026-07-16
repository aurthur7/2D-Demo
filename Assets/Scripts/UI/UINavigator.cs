using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINavigator : MonoBehaviour
{
    public Stack<GameObject> pagestack= new Stack<GameObject>();
    public GameObject currentpage;
    public void opennewpage(GameObject frompage,GameObject newpage)
    {
        if (frompage == null || newpage == null)
        {
            return;
        }
        pagestack.Push(frompage);
        frompage.SetActive(false);
        newpage.SetActive(true);
        currentpage = newpage;
    }
    public bool backtopage()
    {
        if (pagestack.Count == 0)
        {
            return false;
        }
        if (currentpage != null)
        {
            currentpage.SetActive(false);
        }
        GameObject backtopage= pagestack.Pop();
        backtopage.SetActive(true);
        currentpage=backtopage;
        return true;
    }
    public void setroot(GameObject rootpage)
    {
        pagestack.Clear();
        currentpage = rootpage;
        if (currentpage != null)
        {
            currentpage.SetActive(true);
        }
    }
    public bool canback()
    {
        return pagestack.Count > 0;
    }
    public void clear()
    {
        pagestack.Clear();
        currentpage = null;
    }
}
