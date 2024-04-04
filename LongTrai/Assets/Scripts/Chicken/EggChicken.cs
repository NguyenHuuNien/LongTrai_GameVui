using UnityEngine;
public class EggChicken : MonoBehaviour{
    [SerializeField] private GameObject chicken;
    private float timer, timeOpen = 50;
    private void Start() {
        timer = 0;
    }
    private void Update() {
        if(timer<timeOpen){
            timer += Time.deltaTime;
        }else{
            Instantiate(chicken,transform.position,transform.rotation);
            Destroy(this.gameObject);
        }
    }
}