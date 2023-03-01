using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureManager1 : MonoBehaviour
{

    public Picture PicturePrefab;
    public Transform PicSpawnPosition;
    public Vector2 StartPosition = new Vector2(-2.15f, 3.62f);
    [HideInInspector]
    public List<Picture> PictureList;
    // Start is called before the first frame update
    private Vector2 _offset = new Vector2(1.5f, 1.52f);

    private List<Material> _materialList = new List<Material>();
    private List<string> _textureList = new List<string>();
    private Material _firstMaterial;
    private Material _firstTexturePath;
    void Start()
    {
        LoadMaterials();
        SpwanPictureMesh(4, 5, StartPosition, _offset, false);
        MovePicture(4, 5, StartPosition, _offset);
    }

    private void LoadMaterials()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpwanPictureMesh(int rows, int columns, Vector2 pos, Vector2 offset, bool scaleDown)
    {
        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                var tempPicture = (Picture)Instantiate(PicturePrefab, PicSpawnPosition.position, PicSpawnPosition.transform.rotation);
                tempPicture.name = tempPicture.name + 'c' + col + 'r' + row;
                PictureList.Add(tempPicture);
            }
        }
    }
    private void MovePicture(int rows, int columns, Vector2 pos, Vector2 offset)
    {
        var index = 0;
        for(var col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                var targetPosition = new Vector3((pos.x + (offset.x * row)), (pos.y - (offset.y * col)), 0.0f);
                StartCoroutine(MoveToPosition(targetPosition, PictureList[index]));
                index++;
            }
        }
    }
    private IEnumerator MoveToPosition(Vector3 target, Picture obj)
    {
        var randomDis = 7;

        while(obj.transform.position != target)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, target, randomDis * Time.deltaTime);
            yield return 0;
        }
    }
}
