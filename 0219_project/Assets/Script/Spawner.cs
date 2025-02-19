using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour

{
    // 몬스터는 맵에 특정 마리수를 몇초마다 반복해서 소환한다(코루틴활용)
    public GameObject monster_prefab;
    public int monster_count;
    public float monster_spawn_time;
    public float summon_rate = 4.0f; //소환되는 반경, 해당수치를 수정할 경우 생성되는 구의 위치값이 점점 넓어진다
    public float re_rate = 2.0f; //생
                                 //성 위치를 기준으로 생성되는 영역(구)를 설정할 수 있다

    public static List<Monster> monster_List = new List<Monster>(); //생성된 몬스터, using Generic추가
    public static List<Player> player_List = new List<Player>(); //생성된 캐릭터

    void Start()
    {
        StartCoroutine("SpawnMonsterPooling");
    }

    IEnumerator SpawnMonster()
    {
        Vector3 pos; //생성좌표

        for (int i = 0; i < monster_count; i++)
        {
            pos = Vector3.zero + Random.insideUnitSphere * summon_rate; // Vector3의 insideUnitSphere 코드 (반지름이 1.0인 구...) 
            pos.y = 0.0f; //생성된 유닛이 맵에 잘 들어가게 하기 위해, 미리셋팅되는 값

            //너무 근접한 범위에서 생성되었을 경우 재할당
            while (Vector3.Distance(pos, Vector3.zero) <= re_rate)
            {
                pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
                pos.y = 0.0f;
            }


            GameObject go = Instantiate(monster_prefab, pos, Quaternion.identity);
        }
        yield return new WaitForSeconds(monster_spawn_time); //다시돌아옴
        StartCoroutine("SpawnMonster"); //실행
    }

    IEnumerator SpawnMonsterPooling()
    {
        Vector3 pos; //생성좌표

        for (int i = 0; i < monster_count; i++)
        {
            pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
            pos.y = 0.0f;

            while (Vector3.Distance(pos, Vector3.zero) <= re_rate)
            {
                pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
                pos.y = 0.0f;
            }

            var go = BaseManager.POOL.PoolObject("Monster").GetGameObject((result) =>
            {
                // result.GetComponent<Monster>().MonsterSample();
                result.transform.position = pos;
                result.transform.LookAt(Vector3.zero);
                monster_List.Add(result.GetComponent<Monster>());//생성한 유닛을 몬스터 리스트에 추가
            });

            /*            --> Monster.cs에 아래코드를 넣어 Action test해본다

                            void MonsterSample()
                            {
                                Debug.Log("몬스터가 생성되었습니다.");
                            }*/
           // StartCoroutine(ReturnMonsterPooling(go));//풀링한 값 반납 테스트
        }
        yield return new WaitForSeconds(monster_spawn_time); //다시돌아옴
        StartCoroutine("SpawnMonsterPooling"); //실행
    }

    IEnumerator ReturnMonsterPooling(GameObject ob) //몬스터 풀링한 값에 대한 리턴코드
    {
        yield return new WaitForSeconds(1.0f);//1초 딜레이
        BaseManager.POOL.pool_dict["Monster"].ObjectReturn(ob);

    }

}


