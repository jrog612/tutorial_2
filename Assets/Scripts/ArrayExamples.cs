using System.Linq;
using UnityEngine;

public class ArrayExamples : MonoBehaviour
{
    private int[] playerScores = new int[5];

    private string[] itemNames = { "검", "방패", "포션", "활", "마법서" };

    public GameObject[] enemyPrefabs;

    private int[,] mapTiles = new int[10, 10];

    public GameObject Cube;
    public GameObject Sphere;
    public GameObject[,] cubeTiles = new GameObject[10, 10];


    void Start()
    {
        // PlayerScoresExample();
        // ItemInventoryExample();
        // EnemySpawnExample();
        MapGenerationExample();
    }

    void Update()
    {
    }

    void PlayerScoresExample()
    {
        for (int i = 0; i < playerScores.Length; i++)
        {
            playerScores[i] = Random.Range(100, 1000);
        }

        int heightScore = playerScores.Max();
        Debug.Log($"최고 점수: {heightScore}");

        float averageScore = (float)playerScores.Average();
        Debug.Log($"평균 점수: {averageScore}");
    }

    void ItemInventoryExample()
    {
        int randomIndex = Random.Range(0, itemNames.Length);
        string selectedItem = itemNames[randomIndex];
        Debug.Log($"선택된 아이템: {selectedItem}");

        string searchItem = "포션";
        bool hasPotion = itemNames.Contains(searchItem);
        Debug.Log($"포션 보유 여부: {hasPotion}");
    }

    void EnemySpawnExample()
    {
        if (enemyPrefabs != null && enemyPrefabs.Length > 0)
        {
            // 랜덤한 좌표를 지정한다. x = -10~10 y = -10~10 
            Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            // 0과 ememyPrefabs 배열의 길이 사이의 랜덤한 값을 저장한다. 
            int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
            //  enemyPrefabs의 랜덤한 위치에 있는 프리팹 값을 위에 정한 좌표로 소환한다.
            Instantiate(enemyPrefabs[randomEnemyIndex], spawnPosition, Quaternion.identity);
            Debug.Log($"enemy spawned: {enemyPrefabs[randomEnemyIndex].name}");
        }
        else
        {
            Debug.LogWarning($"enemy not spawned.");
        }
    }

    void MapGenerationExample()
    {
        for (int x = 0; x < mapTiles.GetLength(0); x++)
        {
            for (int y = 0; y < mapTiles.GetLength(1); y++)
            {
                mapTiles[x, y] = Random.value > 0.8f ? 1 : 0;
            }
        }

        for (int x = 0; x < mapTiles.GetLength(0); x++)
        {
            for (int y = 0; y < mapTiles.GetLength(1); y++)
            {
                if (mapTiles[x, y] == 1)
                {
                    cubeTiles[x, y] = Instantiate(Cube, new Vector3(x - 5, 0, y - 5), Quaternion.identity);
                }
                else
                {
                    cubeTiles[x, y] = Instantiate(Sphere, new Vector3(x - 5, 0, y - 5), Quaternion.identity);
                }
            }
        }

        string mapString = "생성된 맵:\n";
        for (int x = 0; x < mapTiles.GetLength(0); x++)
        {
            for (int y = 0; y < mapTiles.GetLength(1); y++)
            {
                mapString += mapTiles[x, y] == 1 ? "■ " : "□ ";
            }

            mapString += "\n";
        }

        Debug.Log(mapString);
    }
}