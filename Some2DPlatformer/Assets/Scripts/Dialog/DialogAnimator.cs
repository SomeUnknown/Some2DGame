using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogAnimator : MonoBehaviour
{
    public Animator boxAnim;
    public DialogManager dialogManager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        boxAnim.SetBool("boxOpen", true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        boxAnim.SetBool("boxOpen", false);
        dialogManager.EndDialog();
    }
}
