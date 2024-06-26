using System.Collections.Generic;
using UnityEngine;
public class HatGiong : MonoBehaviour{
    private SpriteRenderer _sprite;
    private List<Sprite> sprites;
    [SerializeField] private listSprite _listSprite;
    [HideInInspector] public EItems eTrees;
    private IStateHG stateHG;
    public float speedDevelop {get; set;}
    public int index{get;set;} = 0;
    public bool isGet {get;set;}
    private void Awake() {
        _sprite = GetComponent<SpriteRenderer>();
    }
    private void OnEnable() {
        isGet = false;
        index = 0;
        if(eTrees==EItems.Food_Human){
            sprites =  _listSprite.getSpritesFoodHuman();
        }else if(eTrees==EItems.Food_Water){
            sprites = _listSprite.getSpritesFoodWater();
        }else if(eTrees==EItems.Food_Animal){
            sprites = _listSprite.getSpritesFoodAnimal();
        }
        _sprite.sprite = sprites[0];
        changeState(new StateHatGiong());
    }
    private void Update() {
        stateHG?.OnExecute(this);
    }
    public void changeState(IStateHG newState){
        stateHG?.OnExit(this);
        stateHG = newState;
        _sprite.sprite = sprites[index];
        stateHG?.OnEnter(this);
    }
    public int getCountSprite(){
        return sprites.Count;
    }
}