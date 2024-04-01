using Unity.VisualScripting;
using UnityEngine;

public class CameraMove : MonoBehaviour{
    [SerializeField] private Camera cameraMain;
    [SerializeField] private GameObject[] WallLimited;
    private Transform[] limit = new Transform[4];
    private Vector3 mousePos;
    private void Start() {
        limit[0] = WallLimited[0].transform;
        limit[1] = WallLimited[1].transform;
        limit[2] = WallLimited[2].transform;
        limit[3] = WallLimited[3].transform;
    }
    private void Update() {
        Debug.Log(mousePos);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(mousePos.y>WallLimited[0].transform.position.y&&mousePos.y<limit[0].position.y+10){
            cameraMain.transform.position = new Vector3(cameraMain.transform.position.x,cameraMain.transform.position.y+1,10);
        }else if(mousePos.y<WallLimited[2].transform.position.y&&mousePos.y>limit[2].position.y+10){
            cameraMain.transform.position = new Vector3(cameraMain.transform.position.x,cameraMain.transform.position.y+1,10);
        }else if(mousePos.x>WallLimited[1].transform.position.x&&mousePos.x<limit[1].position.x+10){
            cameraMain.transform.position = new Vector3(cameraMain.transform.position.x+1,cameraMain.transform.position.y,10);
        }else if(mousePos.x<WallLimited[3].transform.position.x&&mousePos.x>limit[3].position.x+10){
            cameraMain.transform.position = new Vector3(cameraMain.transform.position.x+1,cameraMain.transform.position.y,10);
        }
    }
}