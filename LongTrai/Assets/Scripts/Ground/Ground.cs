using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image imgGround;
    [SerializeField] private GameObject _HatGiong;
    private float luongNuoc;
    private void Update() {
        Debug.Log(luongNuoc);
        if(luongNuoc>0){
            imgGround.sprite = _sprites[1];
            giamDoAm();
        }else{
           imgGround.sprite = _sprites[0];
        }
    }
    private void giamDoAm(){
        luongNuoc -= Time.deltaTime;
    }
    public void UotDat(float water){
        luongNuoc += water;
    }
    private void TuoiNuoc(){
        UotDat(infoItems.water);
    }
    private void TrongHatGiong(){
        _HatGiong.SetActive(true);
    }
    public void ClickedGround(){
        if(CurrentSelect.getCurrentItem() == EItems.Water){
            TuoiNuoc();
        }else if(CurrentSelect.getCurrentItem() == EItems.HatGiong){
            TrongHatGiong();
        }
    }
}