using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    void Start()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        // Talk Data
        // NPC A : 1000, NPC B : 2000, INE : 3000
        // Box : 100, Desk : 200
        talkData.Add(1000, new string[] { "�ȳ�!!:1", "�� �̸��� �����̾�:0", "���⼭ �� �ϰ��ֳİ�??:1", "����̾�:2" });
        talkData.Add(2000, new string[] { "......:1", "�ڰ� �ִ� �� ����.:0"});
        talkData.Add(100, new string[] { "����־ �� �� ���� �� ����." });
        talkData.Add(200, new string[] { "�����Ѱ� ����δ�." });

        // Portrait Data
        // 0:Normal, 1:Speak, 2:Happy, 3:Angry
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
        portraitData.Add(3000 + 0, portraitArr[8]);
        portraitData.Add(3000 + 1, portraitArr[9]);


        //Quest Talk
        talkData.Add(0 + 3000, new string[] { "�ȳ� �� �� ������ Ʃ�丮���� ������ ���̳׾�!:0", "������ �ݰ���!!:0", "�켱 ������ ���� �� �ɾ�� �ִ� ���ھֿ��� ���� �����༭ �Դٰ� �����ɾ��!:0" });
        talkData.Add(10 + 1000, new string[] { "�ȳ�:0", "�� ������ �ű��� ���?:1","������ ����� �絵�� �˰��־�:1", "�� ���� ������ �� �� ����°� �?:2" });
        talkData.Add(11 + 2000, new string[] { "......:0", "...?:0", "����?:3","������ ���..? �����̰� �����༭ �Դٰ�? ��.. �����ֱ� ��������..:1", "��!:1", "��� ���� ���������� ������ ���ȴµ� �װ� �Ҿ���Ȱŵ�:1","�Ƹ� �Ҿ������ �˸� ȭ���ž�:1","������ ����� �˷����״� ��� �� ������ ã�ƿ��� �� �־�?:1","����. ȣ������ �ѹ� ã�ƺ���!:1" });
        talkData.Add(11 + 1000, new string[] { "���� �ȸ����þ�? �� ���� �ִ� �ְ� �絵�ϱ� �ѹ� ������:2" });

        talkData.Add(20 + 1000, new string[] { "��? �絵�� �� ������ �Ҿ���ȴٰ�?:3", "�̵� �Ѹ��� ����߰ھ�:3" });
        talkData.Add(20 + 2000, new string[] { "���� �� ��ó�� ã�ƺ��� �ʴ� ȣ������ ����:1" });
        talkData.Add(20 + 5000, new string[] { "������ ã�� �� ����." });
        talkData.Add(20 + 3000, new string[] { "����? �� ������ ���� ����!:0","�ٸ� ���� ã�ƺ����~:0" });
        talkData.Add(21 + 3000, new string[] { "������ ã�Ҵٰ�?:0", "�����Ѵٳ�~:0" });

        talkData.Add(21 + 2000, new string[] { "ã�ƿԱ���! �����̴�. �̰ɷ� �ѽø� ����:2" });
        talkData.Add(21 + 1000, new string[] { "�� ������ ã�Ҵٰ�? ����! �絵���״� �������� ������ �϶�� ������:1" });

        talkData.Add(30 + 2000, new string[] { "�� ���������� ������ ����� �˷��ٰ� �̵��� �ٽ� ���ɾ���!:2" });
        talkData.Add(30 + 1000, new string[] { "�� ���� ã���༭ ����!:2" });
        talkData.Add(30 + 3000, new string[] { "������ ã�� Ʃ�丮���� �Ϸ��߱��� ���߾�!" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex); // Get First Talk
            else
                return GetTalk(id - id % 10, talkIndex); // Get First QuestTalk
        }
        
        
        if(talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
