using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    /**
    * Crear carta
    * @param sprite Objeto 'Sprite' imagen de la carta
    * @param position Posicion actual de la carta
    * @param layer Capa donde esta desplegada la carta
    *
    * return Nueva carta
    */
    public void createCard(Sprite sprite, Vector3 position, string layer)
    {
        // Crear un 'GameObject' nuevo
        GameObject newObject = CreateGameObject(sprite, position, layer);

		// Agregar tag 'Player' a la carta
		newObject.tag = "Player";

        // Agregar el objeto 'BoxCollider2D'  al 'GameObject'      
        newObject.AddComponent<BoxCollider2D>();

		// Crear reverso de la carta
        Sprite jocker = Resources.Load<Sprite>("joker");

		// Agregar el reverso de la carta a la carta original
		GameObject backCard = CreateGameObject(jocker, position, "Default");
        backCard.transform.parent = newObject.transform;

		// Agregar accion a la carta 
		Move move = newObject.AddComponent<Move>();
		move.backCard = backCard;
    }


    /**
    * Crear nuevo objeto 'GameObject' - nueva carta
    * @param sprite Objeto 'Sprite' imagen de la carta
    * @param position Posicion actual de la carta
    * @param layer Capa donde esta desplegada la carta
    *
    * return Objeto  'GameObject' - nueva carta
    */
    private GameObject CreateGameObject(Sprite sprite, Vector3 position, string layer)
    {
        // Crear un 'GameObject' nuevo
        GameObject newObject = new GameObject(sprite.name);

        // Agregar un 'SpriteRenderer' al nuevo 'GameObject'
        SpriteRenderer spriteRenderer = newObject.AddComponent<SpriteRenderer>();

        // Enviar al fondo de la capa
        spriteRenderer.sortingLayerName = layer;

        // Agregar la imagen al 'SpriteRenderer'
        spriteRenderer.sprite = sprite;

        // Asignar la posicion del 'GameObject'
        newObject.transform.position = position;

        return newObject;
    }

}
