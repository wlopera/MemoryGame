using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run : MonoBehaviour
{
    public Card card;
    private int initX = -8;
    private int initY = 6;
    private int deltaX = 0;
    private int deltaY = 0;
    private int stepX = 3;
    private int stepY = -4;
    private int step = 0;

    public GameObject imagen = null;

    private void Start()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites");
        for (int i = 0; i < 4; i++)
        {
            card.createCard(sprites[i], getPosition(i), "Background");
            card.createCard(sprites[i], getPosition(i), "Background");
        }

        GameObject[] go = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < 8; i++){
            random(go[Random.Range(0,7)], go[Random.Range(0,7)]);
        }
        
        
    }

    private Vector3 getPosition(int i)
    {

        if (step++%4 == 0)
        {
            deltaX = initX;
            deltaY = initY + stepY;
            initY = deltaY;
        }

        deltaX += stepX;

        return new Vector3(deltaX, deltaY, 0);
    }

    private void random(GameObject object1, GameObject object2) {
        Vector3 aux1 = object1.transform.position;
        Vector3 aux2 = object2.transform.position;
        object2.transform.position = new Vector3(aux1.x, aux1.y, 0);
        object1.transform.position = new Vector3(aux2.x, aux2.y, 0);
    }

}
