using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    public string MyColorName;
    public void Move(GameObject oldPlate, GameObject newPlate)
    {
        transform.position = newPlate.transform.position;
        newPlate.GetComponent<Plate>().myChip = gameObject;
        oldPlate.GetComponent<Plate>().myChip = null;

    }
}