using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject redCubePrefab;
    public int rowCount = 5;
    public int columnCount = 5;
    public int layerCount = 3;
    public float spacing = 2f;

    void Start()
    {
        SpawnCubes();
    }

    void SpawnCubes()
    {
        int randomLayer = Random.Range(0, layerCount);
        int randomRow = Random.Range(0, rowCount);
        int randomCol = Random.Range(0, columnCount);

        for (int layer = 0; layer < layerCount; layer++)
        {
            bool isTopLayer = (layer == layerCount - 1); // 上面のレイヤーかどうかを判定する
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < columnCount; col++)
                {
                    Vector3 spawnPosition = new Vector3(col * spacing - spacing * (columnCount - 1) / 2f, layer * spacing, row * spacing - spacing * (rowCount - 1) / 2f);
                    GameObject cube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);

                    if (row == randomRow && col == randomCol && layer == randomLayer)
                    {
                        // ランダムな位置に赤い箱を生成する
                        Destroy(cube);
                        Instantiate(redCubePrefab, spawnPosition, Quaternion.identity);
                    }

                    if (isTopLayer && (row == 0 || row == rowCount - 1) && (col == 0 || col == columnCount - 1))
                    {
                        // 上面の四隅のキューブを黄色にする
                        Renderer cubeRenderer = cube.GetComponent<Renderer>();
                        cubeRenderer.material.color = Color.yellow;
                    }
                }
            }
        }
    }
}
