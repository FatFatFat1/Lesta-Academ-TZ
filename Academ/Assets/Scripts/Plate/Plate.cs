using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private string _state;

    [SerializeField] private Sprite _blockSprite;
    [SerializeField] private Sprite _freeSprite;
    [SerializeField] private GameObject[] nearPlate = new GameObject[8];


    [SerializeField] private bool isSelected = false;

    public string State => _state;
    public bool IsSelected => isSelected;
    public GameObject[] NearPlate => nearPlate;

    public GameObject myChip;

    private void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        FindNearPlate();
        GetComponent<BoxCollider2D>().enabled = true;
    }

    void FindNearPlate()
    {
        Vector2 myPosition = transform.position;
        Collider2D[] hits = Physics2D.OverlapCircleAll(myPosition, 2f);
        int f = 0;
        foreach (Collider2D i in hits)
        {
            if (i.gameObject != null)
            {
                nearPlate[f] = i.gameObject;
                f++;
            }
        }
    }
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
        bool isNear = false;
        for (int i = 0; i < GlobalVar.AllPlate.Length; i++)
        {
            if (GlobalVar.AllPlate[i].GetComponent<Plate>().isSelected)
            {
                oldPlate = GlobalVar.AllPlate[i];
            }
        }
        if (oldPlate != null)
        {
            for (int i = 0; i < oldPlate.GetComponent<Plate>().NearPlate.Length; i++)
            {
                if (oldPlate.GetComponent<Plate>().NearPlate[i] == gameObject)
                {
                    isNear = true;
                }
            }
        }
        if (oldPlate != null && oldPlate != gameObject)
        {
            GlobalVar.GameController.GetComponent<SelectController>().Reselect(oldPlate, gameObject);
            if(oldPlate.GetComponent<Plate>().myChip != null && isNear)
            {
                oldPlate.GetComponent<Plate>().myChip.GetComponent<Chip>().Move(oldPlate,gameObject);
            }
        }
        else if (oldPlate == null || oldPlate == gameObject)
        {
            GlobalVar.GameController.GetComponent<SelectController>().Reselect(gameObject);
        }

    }
}
