using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] private Sprite _blockSprite;
    [SerializeField] private Sprite _freeSprite;
    [SerializeField] private GameObject[] nearPlate = new GameObject[4];


    [SerializeField] private bool isSelected = false;

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
        for (int i = 0; i < 4; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(myPosition, Vector2.up);
            if (i == 1)
            {
                hit = Physics2D.Raycast(myPosition, Vector2.right);
            }
            if (i == 2)
            {
                hit = Physics2D.Raycast(myPosition, Vector2.left);
            }
            if (i == 3)
            {
                hit = Physics2D.Raycast(myPosition, Vector2.down);
            }
            if (hit.collider != null)
            {
                nearPlate[i] = hit.collider.gameObject;
            }
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
            if (oldPlate.GetComponent<Plate>().myChip != null && gameObject.GetComponent<Plate>().myChip == null && isNear)
            {
                oldPlate.GetComponent<Plate>().myChip.GetComponent<Chip>().Move(oldPlate, gameObject);
            }
        }
        else if (oldPlate == null || oldPlate == gameObject)
        {
            GlobalVar.GameController.GetComponent<SelectController>().Reselect(gameObject);
        }
    }
}
