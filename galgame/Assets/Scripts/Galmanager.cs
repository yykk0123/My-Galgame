using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Galmanager : MonoBehaviour
{
    public TextMeshProUGUI Name ;
    public TextMeshProUGUI Content;
    private string file_path = Constants.STORY_PATH;
    private List<ExcelReader.ExcelData> story_data;
    private int current_line = 0;
    // Start is called before the first frame update
    void Start(){//初始化界面
        Load_story(file_path);
        Display();
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetMouseButtonDown(0)) {
            Display();//按下鼠标左键前进
        }
    }
    void Load_story(string path) {//载入文本
        story_data = ExcelReader.ReadExcel(path);
        if (story_data == null || story_data.Count == 0) {
            Debug.LogError("NO data found in the file");
        }
    }
    void Display() {
        if (current_line >= story_data.Count) {
            Debug.Log("END");
            return;
        }
        var data = story_data[current_line];
        Name.text = data.name;
        Content.text = data.content;
        current_line++;
    }
}
