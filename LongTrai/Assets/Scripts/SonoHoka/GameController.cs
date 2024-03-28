using System;
using UnityEngine;

public class GameController : MonoBehaviour{
    [SerializeField] private GameObject Oshirase;
    private SinhVat curSinhVat;
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
    public bool getIsActiveOfOshirase(){
        return Oshirase.activeSelf;
    }
    public void openDisplay(){
        Oshirase.SetActive(true);
    }
    public void Display(SinhVat newSv, String t1, String t2, String t3){
        if(curSinhVat!=null){
            curSinhVat.isDisplay = false;
            curSinhVat = newSv;
            curSinhVat.isDisplay = true;
        }
        if(curSinhVat.eObjects==EObjects.ThucVat)
            Oshirase.GetComponent<Oshirase>().DisplayInfo(t1,t2,t3,"Thu hoạch","Lấy giống");
        else if(curSinhVat.eObjects==EObjects.DongVat){
            Oshirase.GetComponent<Oshirase>().DisplayInfo(t1,t2,t3,"Thịt","Chữa");
        }
    }
}