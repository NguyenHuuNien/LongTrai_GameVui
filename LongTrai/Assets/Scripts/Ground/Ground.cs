using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image imgGround;
    [SerializeField] private GameObject _HatGiong;
    private float luongNuoc;
    private void Update() {
        if(luongNuoc>1){
            _HatGiong.GetComponent<HatGiong>().speedDevelop = 10;
            imgGround.sprite = _sprites[1];
            giamDoAm();
        }else{
            _HatGiong.GetComponent<HatGiong>().speedDevelop = 0;
            luongNuoc = 0;
            imgGround.sprite = _sprites[0];
        }
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
            
        }
    }
}