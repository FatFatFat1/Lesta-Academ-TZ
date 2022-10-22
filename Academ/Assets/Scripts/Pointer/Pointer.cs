using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private GameObject[] myPlate;
    public string MyColorName;

    private void Awake()
    {
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(transform.position, Vector2.down, 100f);
        int i = 0;
        foreach (RaycastHit2D h in hits)
        {
            if (h.collider.gameObject != null && h.collider.gameObject.CompareTag(GlobalVar.PLATE_TAG))
            {
                myPlate[i] = h.collider.gameObject;
                i++;
            }
        }
    }

    public bool CheckVictory()
    {
        for (int i = 0; i < myPlate.Length; i++)
        {
            if (myPlate[i].GetComponent<Plate>().myChip == null || myPlate[i].GetComponent<Plate>().myChip.GetComponent<Chip>().MyColorName != MyColorName)
            {
                return false;
            }
        }
        return true;
    }
}
