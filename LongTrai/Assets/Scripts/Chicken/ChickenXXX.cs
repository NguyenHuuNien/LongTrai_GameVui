using System.Collections;
using UnityEngine;

public class ChickenXXX : MonoBehaviour{
    [SerializeField] private GameObject eggChicken;
    [SerializeField] private GameObject shitChicken;
    private Chicken chicken;
    private void Awake() {
        chicken = GetComponent<Chicken>();
    }
    private void Start() {
        StartCoroutine(EggChickenSpall());
        StartCoroutine(ChickenWC());
    }
    IEnumerator ChickenWC(){
        while(true){
            if(chicken.doi>15){
                int x = Random.Range(1,20);
                if(x==5&&chicken.doi%2==0){
                    Instantiate(shitChicken,transform.position,transform.rotation);
                }else{
                    chicken.doi --;
                }
            }
            yield return new WaitForSeconds(5);
        }
    }
    IEnumerator EggChickenSpall(){
        while(true){
            if(chicken.doi>15){
                int x = Random.Range(1,20);
                if(x==5&&chicken.doi%2!=0)
                    Instantiate(eggChicken,transform.position,transform.rotation);
            }
            yield return new WaitForSeconds(5);
        }
    }
}