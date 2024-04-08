using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveObject: MonoBehaviour
{
    private int dem = 0;
    [SerializeField] IDataChicken dataChicken;
    private static SaveObject instant;
    private List<DataGround> dsDataGround = new List<DataGround>();
    public static SaveObject Instant{
        get {
            return instant;
        }
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.P))
            Debug.Log(dem);
    }
    public void saveData(){
    }
    public void addDataGround(IDataGround dataGround){
        dem++;
        DataGround data = new DataGround();
        data.luongNuoc = dataGround.getLuongNuoc();
        data.heart = dataGround.getHeart();
        data.stateHatGiong = dataGround.getStateHatGiong();
        if(data.stateHatGiong){
            data.i = dataGround.getI();
            data.indexHatGiong = dataGround.getIndexHatGiong();
            data.eItems = dataGround.getEItemTree();
            data.speed = dataGround.getSpeedHatGiong();
        }
        dsDataGround.Add(data);
    }
    private class DataGround{
        public float luongNuoc;
        public int heart;
        public bool stateHatGiong;
        public int i;
        public int indexHatGiong;
        public EItems eItems;
        public float speed;
    }
    private class DataChicken{
        public Vector3 pos;
        public int heart;
        public float doi;
        public ESex eSex;
    }
}
