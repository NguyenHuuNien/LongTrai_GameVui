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
    public void chooseHatGiong(){
        if(CurrentSelect.getCurrentItem() != EItems.HatGiong)
            CurrentSelect.changeItems(EItems.HatGiong);
        else
            CurrentSelect.changeItems(EItems.None);
    }
}