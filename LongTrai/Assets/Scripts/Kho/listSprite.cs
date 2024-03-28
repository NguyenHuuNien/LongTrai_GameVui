using System.Collections.Generic;
using UnityEngine;

public class listSprite : MonoBehaviour{
    [SerializeField] private List<Sprite> dsFoodHuman;
    [SerializeField] private List<Sprite> dsFoodWater;
    [SerializeField] private List<Sprite> dsFoodAnimal;
    public List<Sprite> getSpritesFoodHuman(){
        return dsFoodHuman;
    }
    public List<Sprite> getSpritesFoodWater(){
        return dsFoodWater;
    }
    public List<Sprite> getSpritesFoodAnimal(){
        return dsFoodAnimal;
    }
}