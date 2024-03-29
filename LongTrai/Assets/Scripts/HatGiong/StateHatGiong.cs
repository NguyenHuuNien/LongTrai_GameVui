
using UnityEngine;

public class StateHatGiong : IStateHG{
    private float timeCurrentDevelop;
    private float timeDevelop;
    public void OnEnter(HatGiong hatGiong){
        hatGiong.isGet = false;
        hatGiong.speedDevelop = 1;
        timeCurrentDevelop = 0;
        if(hatGiong.eTrees==EItems.Food_Human){
            timeDevelop = infoItems.getTimeFHuman()[0];
        }else if(hatGiong.eTrees==EItems.Food_Water){
            timeDevelop = infoItems.getTimeFWater()[0];
        }else if(hatGiong.eTrees==EItems.Food_Animal){
            timeDevelop = infoItems.getTimeFAnimal()[0];
        }
    }
    public void OnExecute(HatGiong hatGiong){
        if(timeCurrentDevelop<=timeDevelop){
            timeCurrentDevelop+=Time.deltaTime * hatGiong.speedDevelop;
        }else{
            hatGiong.changeState(new StatePhatTrien());
        }
    }
    public void OnExit(HatGiong hatGiong){
        hatGiong.index++;
    }
}