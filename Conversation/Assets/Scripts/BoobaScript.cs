using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoobaScript : MonoBehaviour
{
    public static Animator animator = null;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Dialogue.hug == true)
        {
            StartCoroutine(HugRoutine());
            Dialogue.hug = false;
        }
        else if (Dialogue.box == true) {
            StartCoroutine(BoxRoutine());
            Dialogue.box = false;
        }
        else if (Dialogue.wave == true)
        {
            StartCoroutine(WaveRoutine());
            Dialogue.wave = false;
        }
        else if (Dialogue.surrender == true)
        {
            StartCoroutine(SurrenderRoutine());
            Dialogue.surrender = false;
        }
        
    }

    IEnumerator HugRoutine()
    {
        animator.SetBool("isHugging",true);
        yield return new WaitForSeconds(3f);
        animator.SetBool("isHugging", false);
    }

    IEnumerator BoxRoutine()
    {
        animator.SetBool("isBoxing", true);
        yield return new WaitForSeconds(3f);
        animator.SetBool("isBoxing", false);
    }

    IEnumerator WaveRoutine()
    {
        animator.SetBool("isWaving", true);
        yield return new WaitForSeconds(3f);
        animator.SetBool("isWaving", false);
    }

    IEnumerator SurrenderRoutine()
    {
        animator.SetBool("isSurrender", true);
        yield return new WaitForSeconds(3f);
        animator.SetBool("isSurrender", false);
    }
}
