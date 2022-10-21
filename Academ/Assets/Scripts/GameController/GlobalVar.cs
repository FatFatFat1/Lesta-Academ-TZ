using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVar : MonoBehaviour
{
    public static GameObject[] AllPlate;
    public static GameObject[] AllChip;
    public static GameObject[] AllPointer;
    [SerializeField] public ColorsChip[] typyOfChip;

    public static GameObject GameController;

    public const string GAME_CONTROLLER_TAG = "GameController";
    public const string PLATE_TAG = "Plate";
    public const string CHIP_TAG = "Chip";
    public const string POINTER_TAG = "Pointer";

    public bool IsWin = false;

    private void Awake()
    {
        GameController = GameObject.FindGameObjectWithTag(GAME_CONTROLLER_TAG);
        AllPlate = GameObject.FindGameObjectsWithTag(PLATE_TAG);
        AllChip = GameObject.FindGameObjectsWithTag(CHIP_TAG);
        AllPointer = GameObject.FindGameObjectsWithTag(POINTER_TAG);
    }

    public void Win()
    {
        IsWin = true;
    }
}
[System.Serializable]
public class ColorsChip
{
    [SerializeField] public int count;
    [SerializeField] public Color color;
    [SerializeField] public string name;
}