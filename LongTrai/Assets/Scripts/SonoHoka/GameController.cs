using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour{
    private static Dictionary<EItems,int> storageBox = new Dictionary<EItems, int>();
    private static Dictionary<EItems, int> tabemono = new Dictionary<EItems, int>();
    [SerializeField] private GameObject Oshirase;
    private static SinhVat curSinhVat;
    public static bool chooseChicken{get;set;}
    [SerializeField] private Text[] txtSoLuong;
    private void Start() {
        storageBox[EItems.Food_Human] = 15;
        storageBox[EItems.Food_Animal] = 15;
        storageBox[EItems.Food_Water] = 15;
        storageBox[EItems.Water] = 10000;
        tabemono[EItems.Food_Human] = 0;
        tabemono[EItems.Food_Animal] = 0;
        tabemono[EItems.Food_Water] = 0;
        tabemono[EItems.ThitGa] = 0;
        tabemono[EItems.Egg] = 0;
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
        if(txtSoLuong.Length==3){
            txtSoLuong[0].text = "x"+storageBox[EItems.Food_Human];
            txtSoLuong[1].text = "x"+storageBox[EItems.Food_Water];
            txtSoLuong[2].text = "x"+storageBox[EItems.Food_Animal];
        }else{
            Debug.Log("Chua cho text vao!");
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
    public void SuDungHoaQua(int index){
        EItems tmpItem = EItems.None;
        if(index==0)
            tmpItem = EItems.Food_Human;
        else if(index==1)
            tmpItem = EItems.Food_Water;
        else if(index==2)
            tmpItem = EItems.Food_Animal;
        else if(index==3)
            tmpItem = EItems.ThitGa;
        else if(index==4){
            tmpItem = EItems.Egg;
        }
        if(tmpItem==EItems.ThitGa){
            if(tabemono[EItems.ThitGa]<1) return;
            tabemono[EItems.ThitGa]--;
            Debug.Log("An thi ga");
        }else if(tmpItem==EItems.Food_Human){
            if(tabemono[EItems.Food_Human]<1) return;
            tabemono[EItems.Food_Human]--;
            Debug.Log("An food for human");
        }else if(tmpItem==EItems.Food_Water){
            if(tabemono[EItems.Food_Water]<1) return;
            tabemono[EItems.Food_Water]--;
            Debug.Log("An food for water");
        }else if(tmpItem==EItems.Food_Animal){
            if(tabemono[EItems.Food_Animal]<1) return;
            tabemono[EItems.Food_Animal]--;
            Debug.Log("An food for animal");
        }else if(tmpItem==EItems.Egg){
            if(tabemono[EItems.Egg]<1) return;
            tabemono[EItems.Egg]--;
            Debug.Log("An Egg");
        }
    }
}