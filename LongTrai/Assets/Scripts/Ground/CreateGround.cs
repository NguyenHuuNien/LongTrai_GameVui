using System.Collections;
using UnityEngine;

public class CreateGround : MonoBehaviour{
    [SerializeField] private GameObject m_Ground;
    [SerializeField] private RectTransform m_ParentGround;
    private float x = -324f, y = 18;
    private void Start() {
        StartCoroutine(create());
    }
    IEnumerator create(){
        for(int i = 0;i<4;i++){
            for(int j = 0;j<5;j++){
                Vector3 v3 = new Vector3(x,y,0);
                x+=65;
                GameObject go = Instantiate(m_Ground, m_ParentGround);
                go.GetComponent<RectTransform>().anchoredPosition = v3;
                yield return new WaitForSeconds(0.05f);
            }
            x = -324f;
            y -= 50;
        }
    }
}