using System.Collections.Generic;
using UnityEngine;

public class EventsButton : MonoBehaviour
{
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