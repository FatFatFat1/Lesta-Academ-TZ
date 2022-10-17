using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVar : MonoBehaviour
{
    //Состояния плиток
    public const string BLOCKSTATE = "Block";
    public const string FREESTATE = "Free";
    public const string FILLEDSTATE = "Filled";

    public static GameObject[] AllPlate;
    public static GameObject[] AllChip;

    public static GameObject GameController;
    private void Awake()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
        AllPlate = GameObject.FindGameObjectsWithTag("Plate");
        AllChip = GameObject.FindGameObjectsWithTag("Chip");
    }
}
