using UnityEngine;

public class ChickenXXX : MonoBehaviour{
    [SerializeField] private GameObject eggChicken;
    [SerializeField] private GameObject shitChicken;
    private LayerMask layerChicken;
    private ChickenMove chickenMove;
    private Chicken chicken;
    private bool isAite = false;
    private float timer,timeX = 10f;
    private void Awake() {
        layerChicken = LayerMask.GetMask("Chicken");
        chickenMove = GetComponent<ChickenMove>();
        chicken = GetComponent<Chicken>();
    }
    private void Update() {
        checkedAite();
        ChickenWC();
        if(isAite){
            if(timer<timeX){
                timer += Time.deltaTime;
            }else{
                Instantiate(eggChicken,transform.position,transform.rotation);
                timer = 0;
                isAite = false;
                chickenMove.isAttack = false;
                chickenMove.chickenRun();
            }
        }
    }
    private void ChickenWC(){
        if(chicken.doi>15){
            int x = Random.Range(1,10);
            if(x==5&&chicken.doi%2==0){
                Instantiate(shitChicken,transform.position,transform.rotation);
            }else{
                chicken.doi -= Time.deltaTime / 10;
            }
        }
    }
    private void checkedAite(){
        Collider2D aite = Physics2D.OverlapCircle(transform.position,0.3f,layerChicken);
        if(aite!=null&&chicken.curHeart>0){
            if(chicken.getSex() == ESex.Duc){
                if(aite.GetComponent<Chicken>().getSex()==ESex.Cai){
                    isAite = true;
                    chickenMove.isAttack = true;
                }else{
                    isAite = false;
                    return;
                }
            }
        }else{
            isAite = false;
            chickenMove.isAttack = false;
        }
    }
}