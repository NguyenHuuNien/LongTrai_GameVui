using UnityEngine;

public class Chicken : SinhVat{
    public int curHeart{get;set;}
    public int doi{get;set;}
    [SerializeField] private ESex eSex;
    public int dame{get;set;}
    public int speedAttack{get;set;}
    private ChickenMove chickenMove;
    private void Awake() {
        chickenMove = GetComponent<ChickenMove>();
    }
    private void Start() {
        isDisplay = false;
        isCanGetIt = true;
        MaxHeart = 100;
        curHeart = 100;
        dame = eSex==ESex.Duc?7:5;
        speedAttack = eSex==ESex.Duc?3:2;
        eObjects = EObjects.DongVat;
    }
    public void attackChicken(int dame){
        curHeart -= dame;
        chickenMove.rangeAttack = 0;
        if(curHeart<=0){
            Debug.Log("Ga chet roi!");
            curHeart = 0;
            chickenMove.isDie = true;
        }
        chickenMove.chickenRun();
    }
    public void killChicken(){
        curHeart = 0;
    }
    public void incHeart(){
        curHeart += 10;
    }
    public ESex getSex(){
        return eSex;
    }
    public void notSitDown(){
        chickenMove.randomDic();
    }    
}