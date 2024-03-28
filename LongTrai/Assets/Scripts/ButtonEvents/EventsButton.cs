using System.Collections.Generic;
using UnityEngine;

public class EventsButton : MonoBehaviour
{
    [SerializeField] private GameObject Oshirase;
    private void Update() {
        if(CurrentSelect.getCurrentItem()==EItems.None && Oshirase.activeSelf){
            if(Input.GetMouseButtonDown(1)){
                Oshirase.SetActive(false);
            }
        }else if(CurrentSelect.getCurrentItem()!=EItems.None){
            if(Input.GetMouseButtonDown(1)){
                CurrentSelect.changeItems(EItems.None);
            }
        }
    }
    public void chooseWater(){
        if(CurrentSelect.getCurrentItem() != EItems.Water)
            CurrentSelect.changeItems(EItems.Water);
        else
            CurrentSelect.changeItems(EItems.None);
    }
    public void chooseHGFHuman(){
        if(CurrentSelect.getCurrentItem() != EItems.Food_Human)
            CurrentSelect.changeItems(EItems.Food_Human);
        else
            CurrentSelect.changeItems(EItems.None);
    }
    public void chooseHGFWater(){
        if(CurrentSelect.getCurrentItem() != EItems.Food_Water)
            CurrentSelect.changeItems(EItems.Food_Water);
        else
            CurrentSelect.changeItems(EItems.None);
    }
    public void chooseHGFAnimal(){
        if(CurrentSelect.getCurrentItem() != EItems.Food_Animal)
            CurrentSelect.changeItems(EItems.Food_Animal);
        else
            CurrentSelect.changeItems(EItems.None);
    }
}