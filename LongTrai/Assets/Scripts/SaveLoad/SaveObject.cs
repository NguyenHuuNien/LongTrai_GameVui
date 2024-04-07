using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveObject: MonoBehaviour
{
    [SerializeField] IDataChicken dataChicken;
    private class DataGround{
        private float luongNuoc;
        private int heart;
        private bool stateHatGiong;
        private int i;
        private int indexHatGiong;
        private EItems eItems;
        private float speed;
    }
    private class DataChicken{
        private Vector3 pos;
        private int heart;
        private float doi;
        private ESex eSex;
    }
}
