using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisherbear : Tower
{

    public override void Attack(GameObject fish) 
    {
        Destroy(fish);
        Debug.Log("Fisherbear is attacking!!!!");
    }

}
