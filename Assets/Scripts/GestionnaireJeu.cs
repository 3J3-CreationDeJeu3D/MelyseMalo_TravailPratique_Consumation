using System.Collections;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum EtatJeu
{
    debut,
    jeu,
    fin,
    mort,
    pause
}

public class GestionnaireJeu : MonoBehaviour
{
    public static GestionnaireJeu instance;
    public EtatJeu etat;

    public Image panneau;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Pattern singleton
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
        etat = EtatJeu.jeu;
    }

    public IEnumerator TerminerJeu()
    {
        //Changer l'état du jeu à fin
        etat = EtatJeu.fin;

        //Attend 1 seconde avant de remettre la balle à sa position précédente
        yield return new WaitForSeconds(1);

        //Fondu noir du panneau
        while (panneau.color.a < 1)
        {
            panneau.color = new Color(panneau.color.r, panneau.color.g, panneau.color.b, panneau.color.a + Time.deltaTime);
            yield return null;
        }

        //Charger la scene de fin
        SceneManager.LoadScene("Intro");
    }
}
