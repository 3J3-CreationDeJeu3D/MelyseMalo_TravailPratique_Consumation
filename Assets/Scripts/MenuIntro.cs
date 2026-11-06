using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MenuIntro : MonoBehaviour
{
    [SerializeField] TMP_Text texteCoups;
    public Image panneau;

    void Start()
    {
        int nbCoups = PlayerPrefs.GetInt("nbCoups", 0);
        texteCoups.text = $"Dernier score : {nbCoups} coup(s)";

        //S'assurer que le panneau est transparent au départ
        if (panneau != null)
        {
            panneau.color = new Color(panneau.color.r, panneau.color.g, panneau.color.b, 0);
        }
    }

    public void Jouer()
    {
        Debug.Log("Jouer");
        StartCoroutine(Demarrer());
    }

    public IEnumerator Demarrer()
    {
        while (panneau.color.a < 1)
        {
            panneau.color = new Color(panneau.color.r, panneau.color.g, panneau.color.b, panneau.color.a + Time.deltaTime);
            yield return null;
        }
        Debug.Log("Demarrer");

        //Charger la scene de jeu
        SceneManager.LoadScene("Jeu");
    }
}
