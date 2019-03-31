using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{

    Queue<string> myText;
    ScriptMgr scriptMgr;
    Touching touching;
    private void Awake()
    {
        myText = new Queue<string>();
        touching = new Touching();
        scriptMgr = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScriptMgr>();
        myText.Enqueue("안녕하세요 여러분");
        myText.Enqueue("이건 테스트 화면입니다.");
        myText.Enqueue("한 번 더 누르면 종료됩니다!");
      
    }

    public void FixedUpdate()
    {
        touching.ClickMe(PickMe);
    }

    public void PickMe()
    {
        if (!scriptMgr.Dialogue.gameObject.activeInHierarchy)
        {
            scriptMgr.Dialogue.gameObject.SetActive(true);
            scriptMgr.SetDialogue(this.myText);
            scriptMgr.ClickMe();
        }
       
    }
    
}
