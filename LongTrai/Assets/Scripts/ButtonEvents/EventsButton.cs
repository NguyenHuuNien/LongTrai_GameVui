using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventsButton : MonoBehaviour
{
    [SerializeField] private Image imgBoxHatGiong;
    [SerializeField] private Image imgBoxTabemono;
    [SerializeField] private Sprite[] spOpenBox;
    [SerializeField] private GameObject componentHatGiong;
    [SerializeField] private GameObject componentTabemono;
    private void Update() {
        if(Input.GetMouseButtonDown(1)){
            if(componentHatGiong.activeSelf)
                onOffBoxPut();
            if(componentTabemono.activeSelf)
                onOffBoxTabemono();
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
    public void chooseItemGay(){
        if(CurrentSelect.getCurrentItem()!=EItems.Gay){
            CurrentSelect.changeItems(EItems.Gay);
        }else{
            CurrentSelect.changeItems(EItems.None);
        }
    }
    public void chooseItemThuHoach(){
        if(CurrentSelect.getCurrentItem()!=EItems.ThuHoach){
            CurrentSelect.changeItems(EItems.ThuHoach);
        }else{
            CurrentSelect.changeItems(EItems.None);
        }
    }
    public void chooseItemLayGiong(){
        if(CurrentSelect.getCurrentItem()!=EItems.LayGiong){
            CurrentSelect.changeItems(EItems.LayGiong);
        }else{
            CurrentSelect.changeItems(EItems.None);
        }
    }
    public void onOffBoxPut(){
        if(componentTabemono.activeSelf)
            onOffBoxTabemono();
        componentHatGiong.SetActive(!componentHatGiong.activeSelf);
        imgBoxHatGiong.sprite = componentHatGiong.activeSelf?spOpenBox[1]:spOpenBox[0];
    }
    public void onOffBoxTabemono(){
        if(componentHatGiong.activeSelf)
            onOffBoxPut();
        componentTabemono.SetActive(!componentTabemono.activeSelf);
        imgBoxTabemono.sprite = componentTabemono.activeSelf?spOpenBox[1]:spOpenBox[0];
    }
}