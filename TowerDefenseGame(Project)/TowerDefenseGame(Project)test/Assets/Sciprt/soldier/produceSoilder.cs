using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class produceSoilder : MonoBehaviour
{
    public GameObject soldierName;
    public Transform spawnPosition;

    private void OnMouseDown()
    {
        spawnSoldier();
    }


    void spawnSoldier() {
        Instantiate(soldierName, spawnPosition.position, spawnPosition.rotation);
    }


}
