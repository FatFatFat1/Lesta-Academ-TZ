using UnityEngine;

public class GlobalVar : MonoBehaviour
{
    public static GameObject[] AllPlate;
    public static GameObject[] AllChip;
    public static GameObject[] AllPointer;

    [SerializeField] public ColorsChip[] typyOfChip;
    [SerializeField] private GameObject WinWindows;

    public static GameObject GameController;

    public const string GAME_CONTROLLER_TAG = "GameController";
    public const string PLATE_TAG = "Plate";
    public const string CHIP_TAG = "Chip";
    public const string POINTER_TAG = "Pointer";



    private void Awake()
    {
        GameController = GameObject.FindGameObjectWithTag(GAME_CONTROLLER_TAG);
        AllPlate = GameObject.FindGameObjectsWithTag(PLATE_TAG);
        AllChip = GameObject.FindGameObjectsWithTag(CHIP_TAG);
        AllPointer = GameObject.FindGameObjectsWithTag(POINTER_TAG);
    }

    public void Win()
    {
        WinWindows.SetActive(true);
    }
}
