using System;
using UnityEngine;

public class GameController : MonoBehaviour{
    [SerializeField] private GameObject Oshirase;
    private SinhVat curSinhVat;
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
        if(curSinhVat.eObjects==EObjects.ThucVat)
            Oshirase.GetComponent<Oshirase>().DisplayInfo(t1,t2,t3,"Thu hoạch","Lấy giống");
        else if(curSinhVat.eObjects==EObjects.DongVat){
            Oshirase.GetComponent<Oshirase>().DisplayInfo(t1,t2,t3,"Thịt","Chữa");
        }
    }
    public void ButtonThuHoach(){
        curSinhVat.gameObject.SetActive(false);
    }
    public void ButtonLayGiong(){
        curSinhVat.gameObject.SetActive(false); 
    }
}