using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonsterEvacuateHandler
{
    bool canevacuate();
    void onevacuatestart();
    void onevacuateend();
}
