using UnityEngine;

public class Chip : MonoBehaviour
{
    public string MyColorName;
    public void Move(GameObject oldPlate, GameObject newPlate)
    {
        transform.position = newPlate.transform.position;
        newPlate.GetComponent<Plate>().myChip = gameObject;
        oldPlate.GetComponent<Plate>().myChip = null;

        bool IsWin = false;
        for(int i = 0; i < GlobalVar.AllPointer.Length; i++)
        {
            IsWin = GlobalVar.AllPointer[i].GetComponent<Pointer>().CheckVictory();
            if(!IsWin)
            {
                break;
            }
        }
        if(IsWin)
        {
            GlobalVar.GameController.GetComponent<GlobalVar>().Win();
        }
    }
}