using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScriptMgr : MonoBehaviour
{
    public Animator anim;
    public Text Dialogue;
    public Queue<string> DialogueText = new Queue<string>();




    IEnumerator GetDialogueTexting(string sentence)
    {
        Dialogue.text = "";

        foreach (char item in sentence.ToCharArray())
        {
            Dialogue.text += item;
            yield return null;
        }
    }

    void EndDialouge()
    {
        anim.SetBool("isUp", false);
        DialogueText.Clear();
        Dialogue.text = "";
    }

    //외부(npc)에게서 Dialgoue를 받아오는 과정
    public void SetDialogue(Queue<string> DialogueText)
    {
        this.DialogueText.Clear();
        this.DialogueText = DialogueText;
    }

    //UI를 클릭했을 때 발생하는 함수
    public void ClickMe()
    {
        if (DialogueText.Count == 0)
        {
            StopAllCoroutines();
            EndDialouge();
            return;
        }

        anim.SetBool("isUp", true);
        StopAllCoroutines();
        StartCoroutine(GetDialogueTexting(DialogueText.Dequeue()));
    }
}
