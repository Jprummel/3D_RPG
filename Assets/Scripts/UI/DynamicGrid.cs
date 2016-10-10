using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DynamicGrid : MonoBehaviour {

    [Header("Layout dimensions")]
    [SerializeField]private int _horizontalElements;
    [SerializeField]private int _verticalElements;

    private GridLayoutGroup _gridLayout;
    private RectTransform _rect;


	// Use this for initialization
    void Start()
    {
        _gridLayout = GetComponent<GridLayoutGroup>();
        _rect = GetComponent<RectTransform>();

        _gridLayout.cellSize = new Vector2(_rect.rect.width/_horizontalElements, _rect.rect.height / _verticalElements);
    }
}
