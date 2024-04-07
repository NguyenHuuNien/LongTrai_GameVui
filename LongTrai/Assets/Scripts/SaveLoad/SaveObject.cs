using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveObject: MonoBehaviour
{
    [SerializeField] IDataChicken dataChicken;
    private class DataChicken{
        private Vector3 pos;
        private int heart;
        private float doi;
        private ESex eSex;
    }
}
