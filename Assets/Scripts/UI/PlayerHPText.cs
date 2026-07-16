
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHPText : MonoBehaviour
{
    public TMP_Text text;
    public PlayerHealth playerhealth;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }
    private void Start()
    {
        text.text="HP: "+ playerhealth.playerdata.nowhp + "/" + playerhealth.playerdata.maxhp;
    }
    private void OnEnable()
    {
        playerhealth.onhpchanged += onhpchange;
    }
    private void OnDisable()
    {
        playerhealth.onhpchanged -= onhpchange;
    }
    public void onhpchange(int nowhp,int maxhp)
    {
        text.text ="HP: "+ nowhp+"/"+maxhp;
    }
}
