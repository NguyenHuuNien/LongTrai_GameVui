using UnityEngine;

public class StateThuHoach : IStateHG{
    public void OnEnter(HatGiong hatGiong){
        hatGiong.isGet = true;
    }
    public void OnExecute(HatGiong hatGiong){
        
    }
    public void OnExit(HatGiong hatGiong){

    }
}