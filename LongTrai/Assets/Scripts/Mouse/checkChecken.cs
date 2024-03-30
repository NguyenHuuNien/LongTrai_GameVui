using UnityEngine;

public class checkChicken : MonoBehaviour{
    private LayerMask layer;
    private GameController gameController;
    private void Awake() {
        gameController = GetComponent<GameController>();
    }
    private void Start() {
        layer = LayerMask.GetMask("Chicken");
    }
    private void Update() {
        Debug.Log(CurrentSelect.getCurrentItem());
        if(Input.GetMouseButtonDown(0)){
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray,Vector2.zero,Mathf.Infinity,layer);
            if(hit.collider!=null){
                Chicken chicken = hit.collider.gameObject.GetComponent<Chicken>();
                if(CurrentSelect.getCurrentItem()==EItems.Gay){
                    chicken.attackChicken(10);
                    gameController.Display(chicken.curHeart+"/100",chicken.doi+"/100",chicken.getSex().ToString());
                }else if(CurrentSelect.getCurrentItem()==EItems.None){
                    gameController.openDisplay();
                    gameController.CheckDisplay(chicken);
                    gameController.Display(chicken.curHeart+"/100",chicken.doi+"/100",chicken.getSex().ToString());
                }
            }

        }
    }
}