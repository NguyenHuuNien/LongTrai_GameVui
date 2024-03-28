using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Oshirase : MonoBehaviour
{
    [SerializeField] private Text[] texts;
    public void DisplayInfo(String text1, String text2, String text3, String txtBtn1, String txtBtn2){
        texts[0].text = text1;
        texts[1].text = text2;
        texts[2].text = text3;
        texts[3].text = txtBtn1;
        texts[4].text = txtBtn2;
    }
}
