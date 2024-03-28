using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image imgGround;
    [SerializeField] private GameObject _HatGiong;
    [SerializeField] private GameObject _TableInfo;
    [SerializeField] private Text[] texts;
    private float luongNuoc;
    private bool openInfo = false;
    private void Update() {
        if(luongNuoc>1){
            imgGround.sprite = _sprites[1];
            giamDoAm();
        }else{
            luongNuoc = 0;
            imgGround.sprite = _sprites[0];
        }
        if(openInfo)
            Info();
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
    private void Info(){
        texts[0].text = "Water: " + (int)luongNuoc + "/100";
        texts[1].text = "Tree: 0%"; // can fix
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
            openInfo = !openInfo;
            _TableInfo.SetActive(openInfo);
        }
    }
}