using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float timer;

   
    public void MoveTheThingUp()
    {
        transform.Translate(0, 2, 0);
    }

    public void MoveTheThingDown()
    {
        transform.Translate(0, -2, 0);
    }

    public void MoveTheThingRight()
    {
        transform.Translate(2, 0, 0);
    }

    public void MoveTheThingLeft()
    {
        transform.Translate(-2, 0, 0);
    }

}
