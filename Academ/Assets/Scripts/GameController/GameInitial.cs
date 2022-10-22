using UnityEngine;

public class GameInitial : MonoBehaviour
{
    private ColorsChip[] AllColorChip;
    [SerializeField] private GameObject[] AllPointer;
    [SerializeField] private GameObject GameController;
    [SerializeField] private GameObject _ChipPrefab;

    private void Start()
    {
        AllColorChip = GameController.GetComponent<GlobalVar>().typyOfChip;
        AllPointer = GlobalVar.AllPointer;
        for (int i = 0; i < AllColorChip.Length; i++)
        {
            FillMap(i);
            SetPointerColor(AllPointer[i], i);
        }
    }
    private void FillMap(int color)
    {
        ColorsChip myColor = AllColorChip[color];
        int i = 0;
        while (i < myColor.count)
        {
            for (int c = 0; c < GlobalVar.AllPlate.Length; c++)
            {
                int randomFill = Random.Range(-2, 2);
                GameObject myPlate = GlobalVar.AllPlate[c];
                if (randomFill >= 0 && myPlate.GetComponent<Plate>().myChip == null)
                {
                    GameObject myChip = Instantiate(_ChipPrefab, myPlate.transform.position, Quaternion.identity);
                    myPlate.GetComponent<Plate>().myChip = myChip;
                    myChip.GetComponent<Chip>().MyColorName = myColor.name;
                    myChip.GetComponent<SpriteRenderer>().color = myColor.color;
                    i++;
                    break;
                }
            }
        }
    }
    private void SetPointerColor(GameObject pointer, int color)
    {
        ColorsChip myColor = AllColorChip[color];
        pointer.GetComponent<Pointer>().MyColorName = myColor.name;
        pointer.GetComponent<SpriteRenderer>().color = myColor.color;
    }

}
