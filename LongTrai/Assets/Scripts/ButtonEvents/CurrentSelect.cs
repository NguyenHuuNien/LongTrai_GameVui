using System;
using Unity.VisualScripting;

public class CurrentSelect
{
    public static HatGiong hatGiong;
    private static EItems items;
    public static void changeItems(EItems newItem){
        items = newItem;
    }
    public static EItems getCurrentItem(){
        return items;
    }
    public static void setHatGiong(HatGiong _hatGiong){
        hatGiong = _hatGiong;
    }
    public static HatGiong GetHatGiong(){
        return hatGiong;
    }
}
