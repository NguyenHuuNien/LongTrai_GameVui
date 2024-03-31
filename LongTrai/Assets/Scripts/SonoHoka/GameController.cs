using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour{
    private static Dictionary<EItems,int> storageBox = new Dictionary<EItems, int>();
    private static Dictionary<EItems, int> tabemono = new Dictionary<EItems, int>();
    [SerializeField] private GameObject Oshirase;
    private static SinhVat curSinhVat;
    public static bool chooseChicken{get;set;}
    private void Start() {
        storageBox[EItems.Food_Human] = 15;
        storageBox[EItems.Food_Animal] = 15;
        storageBox[EItems.Food_Water] = 15;
        storageBox[EItems.Water] = 5000;
        tabemono[EItems.Food_Human] = 0;
        tabemono[EItems.Food_Animal] = 0;
        tabemono[EItems.Food_Water] = 0;
        tabemono[EItems.ThitGa] = 0;
        chooseChicken = false;
    }
    private void Update() {
        if(CurrentSelect.getCurrentItem()==EItems.None && Oshirase.activeSelf){
            if(Input.GetMouseButtonDown(1)){
                offOshirase();
            }
        }else if(CurrentSelect.getCurrentItem()!=EItems.None){
            if(Input.GetMouseButtonDown(1)){
                CurrentSelect.changeItems(EItems.None);
            }
        }
    }
    public static void changeCountTabemono(EItems eItems, int soLuong){
        tabemono[eItems]+=soLuong;
    }
    public static void changeCountItem(EItems eItems, int soLuong){
        storageBox[eItems]+=soLuong;
    }
    public static int getCountItem(EItems eItems){
        return storageBox[eItems];
    }
    public static int getWater(){
        if(storageBox[EItems.Water]<infoItems.water){
            int x = storageBox[EItems.Water];
            storageBox[EItems.Water] = 0;
            return x;
        }else{
            storageBox[EItems.Water] -= infoItems.water;
            return infoItems.water;
        }
    }
    public static int getCountTabemono(EItems eItems){
        return tabemono[eItems];
    }

    public void offOshirase(){
        Oshirase.SetActive(false);
        CheckDisplay(null);
    }
    public bool getIsActiveOfOshirase(){
        return Oshirase.activeSelf;
    }
    public void openDisplay(){
        Oshirase.SetActive(true);
    }
    public void CheckDisplay(SinhVat newSv){
        if(curSinhVat!=null){
            curSinhVat.isDisplay = false;
        }
        curSinhVat = newSv;
        if(curSinhVat!=null){
            curSinhVat.isDisplay = true;
        }
    }
    public void Display(String t1, String t2, String t3){
        if(curSinhVat==null) return;
        if(curSinhVat.eObjects==EObjects.ThucVat)
            Oshirase.GetComponent<Oshirase>().DisplayInfo(t1,t2,t3,"Thu hoạch","Lấy giống");
        else if(curSinhVat.eObjects==EObjects.DongVat){
            Oshirase.GetComponent<Oshirase>().DisplayInfo(t1,t2,t3,"Thịt","Chữa");
        }
    }
    public void ButtonThuHoach(){
        if(curSinhVat!=null && curSinhVat.isCanGetIt){ 
            if(curSinhVat.gameObject.layer==LayerMask.NameToLayer("LuongThuc")){
                curSinhVat.gameObject.GetComponent<Ground>().DecHeart(100);
                changeCountTabemono(CurrentSelect.GetHatGiong().eTrees,1);
            }
            else if(curSinhVat.gameObject.layer==LayerMask.NameToLayer("Chicken")){
                curSinhVat.gameObject.GetComponent<Chicken>().killChicken();
                changeCountTabemono(EItems.ThitGa,1);
            }
        }
    }
    public void ButtonLayGiong(){
        if(curSinhVat!=null && curSinhVat.isCanGetIt){
            Debug.Log(curSinhVat.gameObject.layer);
            if(curSinhVat.gameObject.layer==LayerMask.NameToLayer("LuongThuc")){
                changeCountItem(CurrentSelect.GetHatGiong().eTrees,1);
                curSinhVat.gameObject.GetComponent<Ground>().DecHeart(100);
            }
            else if(curSinhVat.gameObject.layer==LayerMask.NameToLayer("Chicken")){
                Debug.Log("Chua benh cho ga! Hay them dieu kien");
                curSinhVat.gameObject.GetComponent<Chicken>().incHeart();
            }
        }
    }
}