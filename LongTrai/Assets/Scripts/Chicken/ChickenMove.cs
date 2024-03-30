using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChickenMove : SinhVat
{
    [SerializeField] private ESex eSex;
    [SerializeField] private Animator _anim;
    private LayerMask layerMaskWall;
    private LayerMask layerMaskLuongThuc;
    private int dame;
    private Vector2 dicMove;
    private String currentAnim = "isDung";
    private bool isAttack;
    private int speedMove = 1;
    private float timeAttack, speedAttack, timeMove, timeChangeMove;
    private int[][] dic = new int[][]{new int[]{0,-1,0,1,0},new int[]{0,-1,0,1,0}};
    private void Awake() {
        layerMaskWall = LayerMask.GetMask("Wall");
        layerMaskLuongThuc = LayerMask.GetMask("LuongThuc");
    }
    private void Start() {
        isAttack = false;
        eObjects = EObjects.DongVat;
        MaxHeart = 100;
        dame = eSex==ESex.Duc?7:5;
        speedAttack = eSex==ESex.Duc?3:2;
        timeChangeMove = randomTime();
        randomDic();
    }
    private void Update() {
        checkedLuongThuc();
        checkedDicMove();
        move();
    }
    private void move(){
        Debug.Log(dicMove);
        transform.position = new Vector3(transform.position.x+speedMove*dicMove.x * Time.deltaTime,transform.position.y+speedMove*dicMove.y * Time.deltaTime,0);
        if(isAttack){
            dicMove = new Vector2(0,0);
            changeAnim("isAttack");
            return;
        }
        if(dicMove.x==0&&dicMove.y==0){
            changeAnim("isDung");
        }else{
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
    private void randomDic(){
        dicMove = new Vector2(dic[0][Random.Range(0,5)],dic[1][Random.Range(0,5)]);
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
        Invoke(nameof(restartSpeedMove),Random.Range(1,3));
    }
    private void restartSpeedMove(){
        speedMove = 1;
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
        Collider2D luongthuc = Physics2D.OverlapCircle(transform.position,0.4f,layerMaskLuongThuc);
        if(luongthuc!=null&&luongthuc.gameObject.GetComponent<Ground>().getCurrentHeart()>0){
            isAttack = true;
            if(isAttack)
                if(timeAttack<5)
                    timeAttack += Time.deltaTime * speedAttack;
                else{
                    timeAttack = 0;
                    luongthuc.gameObject.GetComponent<Ground>().DecHeart(dame);
                }
        }else{
            isAttack = false;
        }
    }
}