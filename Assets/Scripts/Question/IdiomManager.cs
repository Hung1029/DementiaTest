using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IdiomManager : MonoBehaviour
{
    public UiUnit m_Clone = null;
    public Transform m_Node = null;
    public Transform m_Node2 = null;
    public List<IdiomUnit> m_TotalIdiom = new List<IdiomUnit>(); //所有的成語資料

    public Dictionary<KeyValuePair<int, int>, UiUnit> m_TotalUiUnit = new Dictionary<KeyValuePair<int, int>, UiUnit>(); //所有UI元件
    public List<UiUnit> m_MenuDataList = new List<UiUnit>();
    

    public AllIdiomSo m_idiomSo = null;

    private UiUnit m_SelectLeft = null;
    private UiUnit m_SelectRight = null;

    private int m_FinishCount = 0;

    public GameObject useteaching;
    public GameObject Gameover;
    public bool gameOver;

#if UNITY_EDITOR
    [UnityEditor.MenuItem("Create/創建題目")]
    public static void CreateIdiom()
    {
        string[] stringArray = File.ReadAllLines("Assets/Scripts/Question/question.txt");
        AllIdiomSo ais = ScriptableObject.CreateInstance<AllIdiomSo>();
        for (int i = 0; i < stringArray.Length; i++)
        {
            ais.m_AllData.Add(stringArray[i]);
        }

        UnityEditor.AssetDatabase.CreateAsset(ais, "Assets/Scripts/Question/AllIdiomSo.asset");
    }
#endif

    private void Awake()
    {
        List<string> stringArray = m_idiomSo.m_AllData;
        for (int i=0; i < stringArray.Count; i++) 
        {
            IdiomUnit unit = new IdiomUnit();
            unit.m_Idiom = stringArray[i];
            unit.m_TextArray = new TextUnit[stringArray[i].Length];
            for (int j = 0; j < stringArray[i].Length; j++)
            {
                TextUnit tu = new TextUnit();
                tu.m_IdiomUnit = unit;
                tu.m_Index = j;
                tu.m_Text = unit.m_Idiom[j];
                unit.m_TextArray[j] = tu;
            }
            m_TotalIdiom.Add(unit);
        }
        
    }
    private void Update()
    {
        if(gameOver)
        {
            Gameover.SetActive(true);
            Invoke("GameOver",5f);
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene("CompetitionGame");
    }
    private void Start()
    {
        Gameover.SetActive(false);
        Invoke("Useteaching",5f);
        for(int i =0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                UiUnit unit = Instantiate<UiUnit>(m_Clone, m_Node);
                unit.name = i + "_" + j ;
                m_TotalUiUnit[new KeyValuePair<int, int>(j, i)]=unit;
            }
        }
        for (int n = 0; n < 3; n++)
        {
            CreateUnit();
        }

        List<TextUnit> tempList = new List<TextUnit>();
        Dictionary<KeyValuePair<int, int>, UiUnit>.Enumerator e = m_TotalUiUnit.GetEnumerator();

        while (e.MoveNext())
        {
            UiUnit unit = e.Current.Value;
            if (unit.m_TextData == null)
            {
                continue;
            }

            if (unit.m_TextData.m_IsHide == false)
            {

            }
            else
            {
                UiUnit unit2 = Instantiate<UiUnit>(m_Clone, m_Node2);
                tempList.Add(unit.m_TextData);
                
                m_MenuDataList.Add(unit2);


            }
        }
        e.Dispose();

        for (int i = 0; i < tempList.Count; i++)
        {
            int r = Random.Range(0, tempList.Count);
            TextUnit tempUnit = tempList[r];
            tempList[r] = tempList[i];
            tempList[i] = tempUnit;
        }

        for (int i = 0; i < m_MenuDataList.Count; i++)
        {
            UiUnit uiunit = m_MenuDataList[i];
            uiunit.m_TextData = tempList[i];
            uiunit.m_IsMenu = true;
            uiunit.Refrash();
        }

    }
    void Useteaching()
    {
        useteaching.SetActive(false);
    }
    private void CreateUnit()
    {
        int tempCount = 0;

        while (tempCount<100)
        {
            tempCount++;
            int x = Random.Range(0, 10); //0-9
            int y = Random.Range(0, 5); //0-4

            int r = Random.Range(0, 4); //0-3
                                        //0 =左 1=上 2=右 3=下

            Vector2 v = GetVec(r);
            bool check = true;
            UiUnit[] ui = new UiUnit[5];

            for (int i = 0; i < 5; i++)
            {
                Vector2 pos = new Vector2(x, y);
                pos = pos + v * i;

                if (m_TotalUiUnit.TryGetValue(new KeyValuePair<int, int>((int)pos.x, (int)pos.y), out ui[i]))
                {
                    if (ui[i].m_TextData == null)
                    {

                    }
                    else
                    {
                        check = false;
                    }
                }
                else
                {
                    check = false;
                }
                if (check == false)
                {
                    break;
                }
            }
            if (check)
            {
                int max = m_TotalIdiom.Count;
                int r2 = Random.Range(0, max);
                IdiomUnit iu = m_TotalIdiom[r2];
                iu.Init();
                for (int i = 0; i < ui.Length; i++)
                {
                    ui[i].m_TextData = iu.m_TextArray[i];
                    ui[i].Refrash();
                }
                m_FinishCount++;
                break;
            }
        }
      
    }
    public Vector2 GetVec(int index)
    {
        if (index == 0)
        {
            return new Vector2(-1, 0);
        }
        else if (index == 1)
        {
            return new Vector2(0, -1);
        }
        else if (index == 2)
        {
            return new Vector2(1, 0);
        }
        else if (index == 3)
        {
            return new Vector2(0, 1);
        }
        return new Vector2(0, 0);
    }

    public void OnClickUnit(UiUnit unit)
    {
        if (unit.m_IsMenu)
        {
            if (m_SelectRight!=null)
            {
                m_SelectRight.OnSelect(false);
            }
            m_SelectRight = unit;
            m_SelectRight.OnSelect(true);
        }
        else
        {
            if (m_SelectLeft != null)
            {
                m_SelectLeft.OnSelect(false);
            }
            m_SelectLeft = unit;
            m_SelectLeft.OnSelect(true);
        }

        if (m_SelectRight != null && m_SelectLeft != null)
        {
            if (m_SelectRight.m_TextData.m_Text == m_SelectLeft.m_TextData.m_Text)
            {
                m_SelectLeft.m_TextData.m_IsHide = false;
                m_SelectLeft.Refrash();
                m_MenuDataList.Remove(m_SelectLeft);
                Destroy(m_SelectRight.gameObject);

                if (m_SelectLeft.m_TextData.m_IdiomUnit.CheckSuccess())
                {
                    m_FinishCount--;
                   // Debug.Log("Finsih");
                }

                if (m_FinishCount <= 0)
                {
                    //ResetLevel();
                    gameOver = true;
                }
            }
            else
            {
                m_SelectRight.OnSelect(false);
            }
            m_SelectLeft.OnSelect(false);
            m_SelectLeft = null;
            m_SelectRight = null;
        }

    }
}
