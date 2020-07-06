using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test_1 : MonoBehaviour
{
    public Animator anime;
    public GameObject magicCircle;
    public GameObject magicSword;
    public Vector3[] pos;
    public GameObject[] gameOb;
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        Application.targetFrameRate = 60;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(return_1());
            StartCoroutine(fire());
            StartCoroutine(fire2());
            for(int i = 0; i < gameOb.Length; i++)
            {
                gameOb[i].SetActive(false);
            }
        }

    }
    IEnumerator return_1(){
        anime.SetBool("fire", true);
        yield return new WaitForSeconds(2.5f);
        anime.SetBool("fire", false);
    }
    IEnumerator fire()
    {
        yield return new WaitForSeconds(1f);
        //Destroy(Instantiate(magicCircle, new Vector3(0.077f, 0.7f, 0.42f), Quaternion.identity), 10);
        Destroy(Instantiate(magicCircle, pos[0], Quaternion.identity), 10);
    }
    IEnumerator fire2()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject sword = Instantiate(magicSword, pos[1], Quaternion.identity);
        Rigidbody rb = sword.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * 2, ForceMode.Impulse);
        Destroy(sword, 8);
    }
}
