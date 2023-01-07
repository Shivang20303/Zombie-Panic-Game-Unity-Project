using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    public string itemName = "";

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inv = other.gameObject.GetComponent<Inventory>();
            if (inv != null)
            {
                inv.AddItem(itemName);
                Destroy(gameObject);
            }
        }
    }
}