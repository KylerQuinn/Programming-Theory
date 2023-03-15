using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> surfaces = new List<GameObject>();
    [SerializeField] private GameObject leftBorder;
    [SerializeField] private GameObject rightBorder;
    [SerializeField] private GameObject gameoverScreen;

    private float secondsTilCreation = 2f;
    private const float newSurfaceY = 9;
    
    public float moveDownSpeed { get; } = 1.5f;
    public bool isGameActive { get; private set; } = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateSurface());
    }

    IEnumerator CreateSurface()
    {
        int previousIndex = surfaces.Count - 1;
        int index = previousIndex;

        while (isGameActive)
        {
            yield return new WaitForSeconds(secondsTilCreation);

            // To avoid creating same surface on by one
            while (previousIndex == index)
            {
                index = Random.Range(0, surfaces.Count);
            }
            previousIndex = index;

            Instantiate(surfaces[index], RandomPosition(), surfaces[index].transform.rotation);
        }
    }

    private Vector3 RandomPosition()
    {
        float leftBorderX = leftBorder.transform.position.x;
        float rightBorderX = rightBorder.transform.position.x;
        return new Vector3(Random.Range(leftBorderX, rightBorderX), newSurfaceY, 0);
    }

    public void GameOver()
    {
        isGameActive = false;
        gameoverScreen.SetActive(true);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
