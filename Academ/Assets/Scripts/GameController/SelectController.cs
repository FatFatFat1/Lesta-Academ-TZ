using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    public void Reselect(GameObject newPlate)
    {
        newPlate.GetComponent<SpriteRenderer>().color = Color.green;
        if(!newPlate.GetComponent<Plate>().IsSelected)
        {
            newPlate.GetComponent<Plate>().Selected();
        }
    }
    public void Reselect(GameObject oldPlate, GameObject newPlate)
    {

        newPlate.GetComponent<SpriteRenderer>().color = Color.green;
        newPlate.GetComponent<Plate>().Selected();
        oldPlate.GetComponent<SpriteRenderer>().color = Color.white;
        oldPlate.GetComponent<Plate>().Selected();
    }
}
