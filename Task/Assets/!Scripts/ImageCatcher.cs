using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageCatcher : MonoBehaviour
{
    private string connstr = "http://data.ikppbb.com/test-task-unity-data/pics/";
    private bool eof = false;
    public bool GetImage(RawImage img,int i)
    {
        string url = connstr + i + ".jpg";
        StartCoroutine(TextureSwap(url,img));
        return eof;
    }

    private IEnumerator TextureSwap(string url,RawImage img)
    {
        
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            eof = true;
            Debug.Log(request.error);
        }
        else
        {
            Texture2D myTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            //RawImage s = img.GetComponent<RawImage>();
            //s.sprite = Sprite.Create(myTexture, new Rect(0.0f, 0.0f, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
            //s.texture = myTexture;
            img.GetComponent<RawImage>().texture = myTexture;
        }
        Debug.Log("INDEX : " + url);

        
    }
}
