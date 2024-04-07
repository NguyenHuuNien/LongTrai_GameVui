using UnityEngine;

public class Chicken : SinhVat, IDataChicken{
    public int curHeart{get;set;}
    public float doi{get;set;}
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
        if(curHeart<=0){
            Debug.Log("Ga chet roi!");
            curHeart = 0;
            chickenMove.isDie = true;
        }
        chickenMove.chickenRun();
    }
    public void killChicken(){
        attackChicken(curHeart);
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
    // Save load
    public Vector3 getPosChicken(){
        return this.transform.position;
    }
    public void setPosChicken(Vector3 value) {
        this.transform.position = value;
    }

    public int getHeartChicken()
    {
        return this.curHeart;
    }

    public void setHeartChicken(int heart)
    {
        this.curHeart = heart;
    }

    public float getDoiChicken()
    {
        return this.doi;
    }

    public void setDoiChicken(float doi)
    {
        this.doi = doi;
    }

    public ESex getSexChicken()
    {
        return eSex;
    }

    public void setSexChicken(ESex sex)
    {
        eSex = sex;
    }
}