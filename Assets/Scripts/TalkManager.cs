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
        talkData.Add(1000, new string[] { "안녕!!:1", "내 이름은 여린이야:0", "여기서 뭘 하고있냐고??:1", "비밀이야:2" });
        talkData.Add(2000, new string[] { "......:1", "자고 있는 것 같다.:0"});
        talkData.Add(100, new string[] { "잠겨있어서 열 수 없을 것 같다." });
        talkData.Add(200, new string[] { "쓸만한건 없어보인다." });

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
        talkData.Add(0 + 3000, new string[] { "안녕 난 이 게임의 튜토리얼을 도와줄 아이네야!:0", "만나서 반가워!!:0", "우선 오른쪽 길을 쭉 걸어가면 있는 여자애에게 내가 말해줘서 왔다고 말을걸어봐!:0" });
        talkData.Add(10 + 1000, new string[] { "안녕:0", "이 마을의 신기한 비밀?:1","마을의 비밀은 루도가 알고있어:1", "내 옆에 있으니 한 번 물어보는게 어때?:2" });
        talkData.Add(11 + 2000, new string[] { "......:0", "...?:0", "뭐야?:3","마을의 비밀..? 여린이가 말해줘서 왔다고? 흠.. 말해주기 귀찮은데..:1", "아!:1", "사실 내가 여린이한테 동전을 빌렸는데 그걸 잃어버렸거든:1","아마 잃어버린걸 알면 화낼거야:1","마을의 비밀을 알려줄테니 대신 그 동전을 찾아와줄 수 있어?:1","고마워. 호수쪽을 한번 찾아봐줘!:1" });
        talkData.Add(11 + 1000, new string[] { "아직 안만나봤어? 내 옆에 있는 애가 루도니까 한번 만나봐:2" });

        talkData.Add(20 + 1000, new string[] { "뭐? 루도가 내 동전을 잃어버렸다고?:3", "이따 한마디 해줘야겠어:3" });
        talkData.Add(20 + 2000, new string[] { "나는 이 근처를 찾아볼게 너는 호수쪽을 봐줘:1" });
        talkData.Add(20 + 5000, new string[] { "동전을 찾은 것 같다." });
        talkData.Add(20 + 3000, new string[] { "동전? 난 동전은 본적 없어!:0","다른 곳을 찾아보라네~:0" });
        talkData.Add(21 + 3000, new string[] { "동전을 찾았다고?:0", "축하한다네~:0" });

        talkData.Add(21 + 2000, new string[] { "찾아왔구나! 다행이다. 이걸로 한시름 놨네:2" });
        talkData.Add(21 + 1000, new string[] { "내 동전을 찾았다고? 고마워! 루도한테는 다음부터 조심좀 하라고 전해줘:1" });

        talkData.Add(30 + 2000, new string[] { "날 도와줬으니 마을의 비밀을 알려줄게 이따가 다시 말걸어줘!:2" });
        talkData.Add(30 + 1000, new string[] { "내 동전 찾아줘서 고마워!:2" });
        talkData.Add(30 + 3000, new string[] { "동전을 찾고 튜토리얼을 완료했구나 잘했어!" });
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
