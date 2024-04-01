using UnityEngine;

public class IconFollow : MonoBehaviour{
    [SerializeField] private Sprite[] lsIcons;
    [SerializeField] private SpriteRenderer goFollow;
    private void Start() {
        // an con tro chuot
        Cursor.visible = false;
    }
    private void Update() {
        if(CurrentSelect.getCurrentItem()==EItems.None){
            goFollow.sprite = lsIcons[0];
        }else if(CurrentSelect.getCurrentItem()==EItems.Water){
            goFollow.sprite = lsIcons[1];
        }else if(CurrentSelect.getCurrentItem()==EItems.Food_Human){
            goFollow.sprite = lsIcons[2];
        }else if(CurrentSelect.getCurrentItem()==EItems.Food_Water){
            goFollow.sprite = lsIcons[3];
        }else if(CurrentSelect.getCurrentItem()==EItems.Food_Animal){
            goFollow.sprite = lsIcons[4];
        }else if(CurrentSelect.getCurrentItem()==EItems.ThuHoach){
            goFollow.sprite = lsIcons[5];
        }else if(CurrentSelect.getCurrentItem()==EItems.LayGiong){
            goFollow.sprite = lsIcons[6];
        }else if(CurrentSelect.getCurrentItem()==EItems.Gay){
            goFollow.sprite = lsIcons[7];
        }
        if(Input.GetKeyDown(KeyCode.LeftControl)){
            Cursor.visible = true;
        }else if(Input.GetKeyUp(KeyCode.LeftControl)){
            Cursor.visible = false;
        }
    }
    private void LateUpdate() {
        Vector3 x = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(x.x+0.2f,x.y-0.6f,0);
    }
}