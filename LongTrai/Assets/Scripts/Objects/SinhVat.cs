using UnityEngine;

public class SinhVat : MonoBehaviour{
    public bool isDisplay{get;set;} = false;
    public EObjects eObjects{get;set;}
    public int MaxHeart {get; set;}
    private void Start() {
        isDisplay = false;
    }
}