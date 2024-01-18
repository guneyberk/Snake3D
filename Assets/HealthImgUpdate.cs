using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthImgUpdate : MonoBehaviour
{
    public List<Sprite> healthImages;
    public Sprite _image;

    private void Start()
    {
        _image = GetComponent<Image>().sprite;
    }
    private void Update()
    {
        switch (PlayerDeath._health)
        {
            case 0:
                GetComponent<Image>().sprite = healthImages[0];
                break;
            case 1:
                GetComponent<Image>().sprite = healthImages[1];
                break;
            case 2:
                GetComponent<Image>().sprite = healthImages[2];
                break;
            case 3:
                GetComponent<Image>().sprite = healthImages[3];
                break;
            case 4:
                GetComponent<Image>().sprite = healthImages[4];
                break;
            case 5:
                GetComponent<Image>().sprite = healthImages[5];
                break;
            case 6:
                GetComponent<Image>().sprite = healthImages[6];
                break;
            case 7:
                GetComponent<Image>().sprite = healthImages[7];
                break;
            case 8:
                GetComponent<Image>().sprite = healthImages[8];
                break;
            case 9:
                GetComponent<Image>().sprite = healthImages[9];
                break;
            case 10:
                GetComponent<Image>().sprite = healthImages[9];
                break;
            default:
                GetComponent<Image>().sprite = healthImages[0];
                break;

        }

    }
}
