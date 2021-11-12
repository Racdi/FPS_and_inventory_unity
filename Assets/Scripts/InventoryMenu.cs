using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    public GameObject itemView;
    public GameObject itemViewContent;

    public GameObject buttonPrefab;
    
    bool isActive = false;
    List<GameObject> buttonList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        itemView.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bool click = Input.GetButtonDown("Fire2");

        if(isActive && click){
            Cursor.lockState = CursorLockMode.Locked;
            isActive = false;
            CloseMenu();
        }
        else if(!isActive && click){
            Cursor.lockState = CursorLockMode.None;
            isActive = true;
            OpenMenu();
        }
    }

    void OpenMenu(){
        itemView.SetActive(true);
        CreateLayoutButtons();
    }

    void CloseMenu(){
        ClearButtons();
        itemView.SetActive(false);
    }

    void CreateLayoutButtons(){
        List<Interactable> ownedItems = InventoryManagement.instance.GetItemsOwned(gameObject);
        for(int i = 0; i < ownedItems.Count ; i++){
            buttonList.Add(createButton(ownedItems[i]));
        }
    }
    void ClearButtons(){
        for(int i = 0; i < buttonList.Count ; i++){
            Destroy(buttonList[i]);
        }
    }

    GameObject createButton(Interactable item){
        Interactable itemToTakeout = item;

        GameObject newButton = GameObject.Instantiate(buttonPrefab);
        newButton.transform.SetParent(itemViewContent.transform);
        newButton.transform.Find("Text").GetComponent<Text>().text = item.item.name;
        Button button = newButton.GetComponent<Button>();
        button.onClick.AddListener(
            () => {
                InventoryManagement.instance.TakeoutItem(itemToTakeout);
                ClearButtons();
                CreateLayoutButtons();
            }
        );

        return newButton;
    }
}
