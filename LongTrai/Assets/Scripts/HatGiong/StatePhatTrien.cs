using UnityEngine;

public class StatePhatTrien : IStateHG{
    private float timeCurrentDevelop;
    private float timeDevelop;
    public void OnEnter(HatGiong hatGiong){
        hatGiong.speedDevelop = 1;
        timeCurrentDevelop = 0;
        if(hatGiong.eTrees==EItems.Food_Human){
            timeDevelop = infoItems.getTimeFHuman()[1];
        }else if(hatGiong.eTrees==EItems.Food_Water){
            timeDevelop = infoItems.getTimeFWater()[1];
        }else if(hatGiong.eTrees==EItems.Food_Animal){
            timeDevelop = infoItems.getTimeFAnimal()[1];
        }
    }
    public void OnExecute(HatGiong hatGiong){
        Debug.Log("time = " + timeCurrentDevelop);
        if(timeCurrentDevelop<timeDevelop){
            timeCurrentDevelop+=Time.deltaTime * hatGiong.speedDevelop;
        }else{
            if(hatGiong.index<hatGiong.getCountSprite()-1){
                hatGiong.changeState(new StatePhatTrien());
            }else{
                hatGiong.changeState(new StateThuHoach());
            }
        }
    }
    public void OnExit(HatGiong hatGiong){
        hatGiong.index++;
    }
}