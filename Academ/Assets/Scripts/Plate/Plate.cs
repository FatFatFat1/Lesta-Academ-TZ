using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private string _state;

    public string State => _state;

    [SerializeField] private Sprite _blockSprite;
    [SerializeField] private Sprite _freeSprite;
    [SerializeField] private Sprite _filledSprite;


    private bool isSelected = false;

    public void UpdateState(string state)
    {
        switch (state)
        {
            case GlobalVar.BLOCKSTATE:
                _state = state;
                GetComponent<SpriteRenderer>().sprite = _blockSprite;
                break;
            case GlobalVar.FREESTATE:
                _state = state;
                GetComponent<SpriteRenderer>().sprite = _freeSprite;
                break;
            case GlobalVar.FILLEDSTATE:
                _state = state;
                GetComponent<SpriteRenderer>().sprite = _filledSprite;
                break;
        }
    }
    public void Selected()
    {
        isSelected = !isSelected;
    }
    private void OnMouseDown()
    {
        GameObject oldPlate = null;
        for (int i = 0; i < GlobalVar.AllPlate.Length; i++)
        {
            if (GlobalVar.AllPlate[i].GetComponent<Plate>().isSelected)
            {
                oldPlate = GlobalVar.AllPlate[i];
            }
        }
        if (oldPlate != null && oldPlate != gameObject)
        {
            GlobalVar.GameController.GetComponent<SelectController>().Reselect(oldPlate, gameObject);
        }
        else
        {
            GlobalVar.GameController.GetComponent<SelectController>().Reselect(gameObject);
        }
    }
}
