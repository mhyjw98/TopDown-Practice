using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;

    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>(); ;
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(0, new QuestData("���̳׿� ��ȭ�ϱ�", new int[] { 3000 }));
        questList.Add(10, new QuestData("���� ������ ��ȭ�ϱ�", new int[] {1000, 2000}));
        questList.Add(20, new QuestData("������ ���� ã���ֱ�", new int[] { 5000, 2000 }));
        questList.Add(30, new QuestData("����Ʈ Ŭ����!", new int[] { 0 }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {       
        // Next Talk Target
        if (id == questList[questId].npcId[questActionIndex])
             questActionIndex++;

        // Control Quest Object
        ControlObject();

        // Talk Complete & Next Quest
        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        // Quest Name
        return questList[questId].QuestName;
    }

    public string CheckQuest()
    {
        // Quest Name
        return questList[questId].QuestName;
    }



    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    public void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if(questActionIndex == 2)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if(questActionIndex == 0)
                    questObject[0].SetActive(true);
                else if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
        }
    }
}