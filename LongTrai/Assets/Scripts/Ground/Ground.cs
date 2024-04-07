using UnityEngine;
using UnityEngine.UI;

public class Ground : SinhVat, IDataGround
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image imgGround;
    [SerializeField] private GameObject _HatGiong;
    private static GameController gameController;
    private float luongNuoc;
    private int curHeart;
    private int prevMaxHeart;
    private HatGiong saveHatGiong;
    private bool saveStateHatGiong;
    private int i; // Tang gia tri mau khi gieo hat
    private void Awake() {
        gameController = FindAnyObjectByType<GameController>();
        saveHatGiong = _HatGiong.GetComponent<HatGiong>();
    }
    private void Start() {
        i = 0;
        eObjects = EObjects.ThucVat;
        MaxHeart = 0;
        prevMaxHeart = MaxHeart;
        curHeart = MaxHeart;
    }
    private void Update() {
        isCanGetIt = saveHatGiong.isGet;
        if(_HatGiong.activeSelf)
            updateHeart();
        else{
            MaxHeart = 0;
            curHeart = 0;
        }
        if(luongNuoc>1){
            saveHatGiong.speedDevelop = 1;
            imgGround.sprite = _sprites[1];
            giamDoAm();
        }else{
            saveHatGiong.speedDevelop = 0;
            luongNuoc = 0;
            imgGround.sprite = _sprites[0];
        }
        if(gameController.getIsActiveOfOshirase()&&isDisplay){
            displayed();
        }
    }
    private void updateHeart(){
        prevMaxHeart = MaxHeart;
        MaxHeart = (saveHatGiong.index + i) * 10;
        if(prevMaxHeart<MaxHeart){
            curHeart+=10;
        }
    }
    public int getCurrentHeart(){
        return curHeart;
    }
    public void DecHeart(int dame){
        curHeart-=dame;
        if(curHeart<=0){
            _HatGiong.SetActive(false);
            MaxHeart = 0;
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
        if(GameController.getCountItem(EItems.Water)<=0){
            CurrentSelect.changeItems(EItems.None);
            return;
        }
        UotDat();
    }
    private void TrongHatGiong(){
        if(_HatGiong.activeSelf)
            return;
        saveHatGiong.eTrees = CurrentSelect.getCurrentItem();
        GameController.changeCountItem(CurrentSelect.getCurrentItem(),-1);
        _HatGiong.SetActive(true);
        i = 1;
    }
    public void ClickedGround(){
        if(GameController.chooseChicken) return;
        if(CurrentSelect.getCurrentItem() == EItems.Water){
            TuoiNuoc();
        }else if(CurrentSelect.getCurrentItem() == EItems.Food_Human ||
                CurrentSelect.getCurrentItem() == EItems.Food_Water ||
                CurrentSelect.getCurrentItem() == EItems.Food_Animal
        ){
            if(GameController.getCountItem(CurrentSelect.getCurrentItem())<=0){
                Debug.Log("Het vat pham");
                CurrentSelect.changeItems(EItems.None);
            }else{
                TrongHatGiong();
            }
        }else if(CurrentSelect.getCurrentItem() == EItems.None){
            gameController.openDisplay();
        }else if(CurrentSelect.getCurrentItem() == EItems.ThuHoach && isCanGetIt){
            GameController.changeCountTabemono(saveHatGiong.eTrees,1);
            DecHeart(curHeart);
        }else if(CurrentSelect.getCurrentItem() == EItems.LayGiong && isCanGetIt){
            GameController.changeCountItem(saveHatGiong.eTrees,1);
            DecHeart(curHeart);
        }
        CurrentSelect.setHatGiong(saveHatGiong);
        gameController.CheckDisplay(this);
    }
    public void setDataGround(Ground ground){

    }
    public Ground getDataGround(){
        Ground tmpGround = new Ground();
        tmpGround.luongNuoc = this.luongNuoc;
        tmpGround.curHeart = this.curHeart;
        tmpGround.saveStateHatGiong = this._HatGiong.activeSelf;
        if(tmpGround.saveStateHatGiong){
            HatGiong tmpHatGiong = new HatGiong();
            tmpHatGiong.eTrees = saveHatGiong.eTrees;
            tmpGround.i = this.i;
            tmpHatGiong.index = saveHatGiong.index;
        }
        return tmpGround;
    }
}