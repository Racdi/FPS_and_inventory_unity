using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagement : MonoBehaviour
{
    public static InventoryManagement instance = null;
    public List<Interactable> takenItems = new List<Interactable>();
    public List<GameObject> players = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //Sanity check
        if(instance != null && instance != this){
            Destroy(gameObject);
            return;
        }
        instance = this;
        GameObject[] playersArray = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < playersArray.Length; i++){
            players.Add(playersArray[i]);
        }
    }

    public void StoreItem(GameObject storingPlayer, GameObject storedItem){
        Interactable pocketed = new Interactable(storedItem, storingPlayer);
        takenItems.Add(pocketed);
        storedItem.SetActive(false);
    }

    public void TakeoutItem(Interactable droppedItem){
        takenItems.Remove(droppedItem);
        droppedItem.item.SetActive(true);
        droppedItem.item.transform.position = droppedItem.owner.transform.position + 
            droppedItem.owner.transform.forward;
    }

    public List<Interactable> GetItemsOwned(GameObject playerOwner){
        List<Interactable> itemsToReturn = new List<Interactable>();

        for(int i = 0; i < takenItems.Count; i++){
            if(takenItems[i].owner == playerOwner){
                itemsToReturn.Add(takenItems[i]);
            }
        }
        return itemsToReturn;
    }

}

public class Interactable
{
    public GameObject item;
    public GameObject owner;

    public Interactable(GameObject newItem, GameObject newOwner){
        this.item = newItem;
        this.owner = newOwner;
    }
}