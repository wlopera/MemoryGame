using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public GameObject backCard;

    void OnMouseDown()
    {
        {
            //backCard.SetActive(!backCard.activeSelf);  
            StartCoroutine(controlImagen());
            controlImagen();
        }
    }

    IEnumerator controlImagen()
    {

        GameObject go = GameObject.Find("Main Camera");
        Run run = go.GetComponent<Run>();

        if (null == run.imagen)
        {
            run.imagen = backCard.transform.parent.gameObject;
            backCard.SetActive(false);
        }
        else
        {

            backCard.SetActive(false);
            yield return new WaitForSeconds(1);

            if (run.imagen.name == backCard.transform.parent.gameObject.name)
            {
                backCard.transform.parent.gameObject.SetActive(false);
                run.imagen.SetActive(false);


            }
            else
            {
                run.imagen.transform.GetChild(0).gameObject.SetActive(true);
                backCard.SetActive(true);
            }
            run.imagen = null;
        }
    }

}