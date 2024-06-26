using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChickenMove : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    private LayerMask layerMaskWall,layerMaskLuongThuc;
    private Vector2 dicMove;
    private int speedMove = 1;
    private String currentAnim = "isDung";
    public bool isAttack{get;set;}
    private Chicken chicken;
    private float timeAttack, timeMove, timeChangeMove;
    public bool isDie{get;set;}
    public bool isSitdown{get;set;}
    public float rangeAttack{get;set;}
    private int[][] dic = new int[][]{new int[]{-1,0,1,0},new int[]{-1,0,1,0}};
    private void Awake() {
        chicken = GetComponent<Chicken>();
        layerMaskWall = LayerMask.GetMask("Wall");
        layerMaskLuongThuc = LayerMask.GetMask("LuongThuc");
    }
    private void Start() {
        isDie = false;
        isAttack = false;
        isSitdown = false;
        chicken.eObjects = EObjects.DongVat;
        timeChangeMove = randomTime();
        randomDic();
    }
    private void Update() {
        if(isDie){
            _anim.SetFloat("x",0);
            _anim.SetFloat("y",1);
            changeAnim("isNgoi");
            return;
        }
        checkedLuongThuc();
        checkedDicMove();
        move();
    }
    private void move(){
        transform.position = new Vector3(transform.position.x+speedMove*dicMove.x * Time.deltaTime,transform.position.y+speedMove*dicMove.y * Time.deltaTime,0);
        if(isAttack){
            isSitdown = true;
            dicMove = new Vector2(0,0);
            changeAnim("isAttack");
            return;
        }
        if(dicMove.x==0&&dicMove.y==0){
            isSitdown = true;
            changeAnim("isDung");
        }else{
            isSitdown = false;
            changeAnim("isMove");
        }
        if(timeMove<timeChangeMove){
            timeMove+=Time.deltaTime*2;
        }else{
            timeMove = 0;
            timeChangeMove = randomTime();
            randomDic();
        }
    }
    private float randomTime(){
        return Random.Range(5,15);
    }
    private void changeAnim(String newAnim){
        if(!currentAnim.Equals(newAnim)){
            _anim.SetBool(currentAnim,false);
            currentAnim = newAnim;
            _anim.SetBool(currentAnim,true);
        }
    }
    public void randomDic(){
        dicMove = new Vector2(dic[0][Random.Range(0,4)],dic[1][Random.Range(0,4)]);
        if(!(dicMove.x==0&&dicMove.y==0)){
            if(dicMove.x!=0&&dicMove.y!=0){
                _anim.SetFloat("x",dicMove.x);
                _anim.SetFloat("y",0);
            }else{
                _anim.SetFloat("x",dicMove.x);
                _anim.SetFloat("y",dicMove.y);
            }
        }
    }
    public void chickenRun(){
        speedMove = 3;
        rangeAttack = 0;
        Invoke(nameof(restartSpeedMove),Random.Range(2,5));
    }
    private void restartSpeedMove(){
        Invoke(nameof(restartRangeAttack),Random.Range(2,4));
        speedMove = 1;
    }
    private void restartRangeAttack(){
        rangeAttack = 0.4f;
    }  
    private void checkedDicMove(){
        RaycastHit2D down = Physics2D.Raycast(transform.position,Vector2.down,0.8f,layerMaskWall);
        RaycastHit2D up = Physics2D.Raycast(transform.position,Vector2.up,0.8f,layerMaskWall);
        RaycastHit2D left = Physics2D.Raycast(transform.position,Vector2.left,0.8f,layerMaskWall);
        RaycastHit2D right = Physics2D.Raycast(transform.position,Vector2.right,0.8f,layerMaskWall);
        if(down||up){
            dicMove = new Vector2(dicMove.x,dicMove.y*-1);
            _anim.SetFloat("y",dicMove.y);
        }else if(right||left){
            dicMove = new Vector2(dicMove.x*-1,dicMove.y);
            _anim.SetFloat("x",dicMove.x);
        }
    }
    private void checkedLuongThuc(){
        Collider2D luongthuc = Physics2D.OverlapCircle(transform.position,rangeAttack,layerMaskLuongThuc);
        if(luongthuc!=null&&luongthuc.gameObject.GetComponent<Ground>().getCurrentHeart()>0){
            isAttack = true;
            if(isAttack)
                if(timeAttack<5)
                    timeAttack += Time.deltaTime * chicken.speedAttack;
                else{
                    timeAttack = 0;
                    luongthuc.gameObject.GetComponent<Ground>().DecHeart(chicken.dame);
                }
        }else{
            isAttack = false;
        }
    }
}