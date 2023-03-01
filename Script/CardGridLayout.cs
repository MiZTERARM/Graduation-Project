using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGridLayout : LayoutGroup
{
    public int rows;
    public int columns;

    public Vector3 spacing;
    public Vector2 cardSize;

    public int preferredTopPadding;

    [HideInInspector]
    public List<Picture> PictureList;

    private List<Material> _materialList = new List<Material>();
    private List<string> _textureList = new List<string>();
    private Material _firstMaterial;
    private string _firstTexturePath;
    public override void CalculateLayoutInputVertical()
    {
        if (rows == 0 || columns == 0)
        {
            rows = 4;
            columns = 5;
        }
        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        float cardHeight = (parentHeight - 2 * preferredTopPadding - spacing.y * (rows - 1)) / rows;
        float cardWidth = cardHeight;

        //if (cardWidth * columns + spacing.x *(columns - 1)>parentWidth)
        // {
        //  cardWidth = (parentWidth - 2 * preferredTopPadding - (columns - 1) * spacing.x) / columns;
        // cardHeight = cardWidth;
        // }

        cardSize = new Vector2(cardWidth - 50, cardHeight - 50);

        padding.left = Mathf.FloorToInt((parentWidth - columns * cardWidth - spacing.x * (columns - 1)) / 2);
        padding.top = Mathf.FloorToInt((parentHeight - rows * cardHeight - spacing.y * (columns - 1)) / 2);
        padding.bottom = padding.top;

        for (int i = 0; i < rectChildren.Count; i++)
        {
            int rowCount = i / columns;
            int columnCount = i % columns;

            var item = rectChildren[i];

            var xPos = padding.left + cardSize.x * columnCount + spacing.x * (columnCount + 151);
            //var yPos = padding.top + cardSize.y * rowCount + spacing.y * (rowCount) ;
            var yPos = cardSize.y * rowCount + spacing.y * (rowCount +55);

            SetChildAlongAxis(item, 0, xPos, cardSize.x);
            SetChildAlongAxis(item, 1, yPos, cardSize.y);
        }
    }
    void Start()
    {
        LoadMaterials();
        
    }
    private void LoadMaterials()
    {
        var materialFilePath = GameSettings.Instance.GetMaterialDirectoryName();
        var textureFilePath = GameSettings.Instance.GetPuzzleCategoryTextDirectoryName();
        var pairNumber = (int)GameSettings.Instance.GetPairNumber();
        const string matBaseName = "Pic";
        var firstMaterialName = "Back";

        for (var index = 1; index <= pairNumber; index++)
        {
            var currentFilePath = materialFilePath + matBaseName + index;
            Material mat = Resources.Load(currentFilePath, typeof(Material)) as Material;
            _materialList.Add(mat);

            var currentTextureFilePath = textureFilePath + matBaseName + index;
            _textureList.Add(currentTextureFilePath);
        }
        _firstTexturePath = textureFilePath + firstMaterialName;
        _firstMaterial = Resources.Load(materialFilePath + firstMaterialName, typeof(Material)) as Material;


        ApplyTextures();
    }
    public void ApplyTextures()
    {
        var rndMatIndex = Random.Range(0, _materialList.Count);
        var AppliedTimes = new int[_materialList.Count];

        for (int i = 0; i < _materialList.Count; i ++)
        {
            AppliedTimes[i] = 0;
        }
        foreach (var o in PictureList)
        {
            var randPrevious = rndMatIndex;
            var counter = 0;
            var forceMat = false;

            while (AppliedTimes[rndMatIndex] >= 2 || ((randPrevious == rndMatIndex)&& !forceMat))
            {
                rndMatIndex = Random.Range(0, _materialList.Count);
                counter++;
                if (counter > 100)
                {
                    for (var j = 0; j < _materialList.Count; j++)
                    {
                        if (AppliedTimes[j] < 2)
                        {
                            rndMatIndex = j;
                            forceMat = true;
                        }
                    }
                    if (forceMat == false)
                    {
                        return;
                    }
                }
                o.SetFirstMaterial(_firstMaterial, _firstTexturePath);
                o.ApplyFirstMaterial();
            //    o.ApplySecondMaterial();
                o.SetSecondMaterial(_materialList[rndMatIndex], _textureList[rndMatIndex]);
                AppliedTimes[rndMatIndex] += 1;
                forceMat = false;
            }
        }
    }
    public override void SetLayoutHorizontal()
    {
        return;
    }
    public override void SetLayoutVertical()
    {
        return;
    }
}
