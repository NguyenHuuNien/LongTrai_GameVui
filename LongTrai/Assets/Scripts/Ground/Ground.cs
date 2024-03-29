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
        isCanGetIt = _HatGiong.GetComponent<HatGiong>().isGet;
        updateHeart();
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
    public void DecHeart(int dame){
        curHeart-=dame;
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
    public void UotDat(){
        luongNuoc += GameController.getWater();
        if(luongNuoc>100) luongNuoc = 100;
    }
    private void TuoiNuoc(){
        if(GameController.getCountItem(EItems.Water)<=0)
            return;
        UotDat();
    }
    private void TrongHatGiong(){
        if(_HatGiong.activeSelf)
            return;
        _HatGiong.GetComponent<HatGiong>().eTrees = CurrentSelect.getCurrentItem();
        if(GameController.getCountItem(CurrentSelect.getCurrentItem())<=0)
            return;
        GameController.changeCountItem(CurrentSelect.getCurrentItem(),-1);
        _HatGiong.SetActive(true);
    }
    public void ClickedGround(){
        if(CurrentSelect.getCurrentItem() == EItems.Water){
            TuoiNuoc();
        }else if(CurrentSelect.getCurrentItem() == EItems.Food_Human ||
                CurrentSelect.getCurrentItem() == EItems.Food_Water ||
                CurrentSelect.getCurrentItem() == EItems.Food_Animal
        ){
            if(GameController.getCountItem(CurrentSelect.getCurrentItem())<=0){
                Debug.Log("Het vat pham");
                return;
            }
            TrongHatGiong();
        }else if(CurrentSelect.getCurrentItem() == EItems.None){
            CurrentSelect.setHatGiong(_HatGiong.GetComponent<HatGiong>());
            gameController.openDisplay();
        }
        gameController.CheckDisplay(this);
    }
}