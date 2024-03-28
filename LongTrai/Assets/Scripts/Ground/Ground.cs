using UnityEngine;
using UnityEngine.UI;

public class Ground : SinhVat
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image imgGround;
    [SerializeField] private GameObject _HatGiong;
    private static GameController gameController;
    private float luongNuoc;
    private int curHeart;
    private int prevMaxHeart;
    private void Start() {
        gameController = FindAnyObjectByType<GameController>();
        eObjects = EObjects.ThucVat;
        MaxHeart = 10;
        prevMaxHeart = MaxHeart;
        curHeart = MaxHeart;
    }
    private void Update() {
        updateHeart();
        if(isDisplay)Debug.Log(gameObject.name);
        if(luongNuoc>1){
            _HatGiong.GetComponent<HatGiong>().speedDevelop = 10;
            imgGround.sprite = _sprites[1];
            giamDoAm();
        }else{
            _HatGiong.GetComponent<HatGiong>().speedDevelop = 0;
            luongNuoc = 0;
            imgGround.sprite = _sprites[0];
        }
        if(gameController.getIsActiveOfOshirase()&&isDisplay){
            Debug.Log("Error" + isDisplay + " " + gameController.getIsActiveOfOshirase());
            displayed();
        }
    }
    private void updateHeart(){
        prevMaxHeart = MaxHeart;
        MaxHeart = (_HatGiong.GetComponent<HatGiong>().index + 1) * 10;
        if(prevMaxHeart<MaxHeart){
            curHeart = curHeart * MaxHeart / prevMaxHeart;
        }
    }
    public void DecHeart(){
        curHeart-=5;
        if(curHeart<=0){
            _HatGiong.SetActive(false);
        }
    }
    private void displayed(){
        gameController.Display("Máu: "+curHeart+"/"+MaxHeart,"Độ ẩm: "+(int)luongNuoc+"/100","Tốc độ: "+_HatGiong.GetComponent<HatGiong>().speedDevelop);
    }
    private void giamDoAm(){
        luongNuoc -= Time.deltaTime;
    }
    public void UotDat(float water){
        luongNuoc += water;
        if(luongNuoc>100) luongNuoc = 100;
    }
    private void TuoiNuoc(){
        UotDat(infoItems.water);
    }
    private void TrongHatGiong(){
        _HatGiong.GetComponent<HatGiong>().eTrees = CurrentSelect.getCurrentItem();
        _HatGiong.SetActive(true);
    }
    public void ClickedGround(){
        if(CurrentSelect.getCurrentItem() == EItems.Water){
            TuoiNuoc();
        }else if(CurrentSelect.getCurrentItem() == EItems.Food_Human ||
                CurrentSelect.getCurrentItem() == EItems.Food_Water ||
                CurrentSelect.getCurrentItem() == EItems.Food_Animal
        ){
            TrongHatGiong();
        }else if(CurrentSelect.getCurrentItem() == EItems.None){
            gameController.openDisplay();
            gameController.CheckDisplay(this);
        }
    }
}