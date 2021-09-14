using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
//using Firebase.Unity.Editor;
//using System.Diagnostics;
// Firebase 불러오기

public class Database : MonoBehaviour
{
    class ValueU
    {
        // 순위 정보를 담는 Rank 클래스
        // Firebase와 동일하게 name, score, timestamp를 가지게 해야함
        public double speed;
        public double bpm;
        // JSON 형태로 바꿀 때, 프로퍼티는 지원이 안됨. 프로퍼티로 X

        public ValueU(double speed, double bpm)
        {
            // 초기화하기 쉽게 생성자 사용
            this.speed = speed;
            this.bpm = bpm;
        }
    }

    List<ValueU> list = new List<ValueU>();

    public DatabaseReference reference { get; set; }
    // 라이브러리를 통해 불러온 FirebaseDatabase 관련객체를 선언해서 사용

    void Start()
    {
        FirebaseApp.DefaultInstance.Options.DatabaseUrl = new System.Uri("https://lavitatest.firebaseio.com/");
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://lavitatest.firebaseio.com/");
        // 데이터베이스 경로를 설정해 인스턴스를 초기화
        reference = FirebaseDatabase.DefaultInstance.GetReference("value");
        // 사용하고자 하는 데이터를 reference가 가리킴
        // 여기선 rank 데이터 셋에 접근

    }

    void Update()
    {
        reference.GetValueAsync().ContinueWith(task => {
            if (task.IsCompleted)
            { // 성공적으로 데이터를 가져왔으면
                DataSnapshot snapshot = task.Result;

                // 데이터를 출력하고자 할때는 Snapshot 객체 사용함

                foreach (DataSnapshot data in snapshot.Children)
                {
                    IDictionary value = (IDictionary)data.Value;
                    Debug.Log("speed: " + value["speed"] + ", bpm: " + value["bpm"]);
                    list.Add(new ValueU(double.Parse(value["speed"].ToString()), double.Parse(value["bpm"].ToString())));
                    for (int i = 0; i < list.Count; i++)
                    {
                        Debug.Log(list[i].speed + " " + list[i].bpm);
                    }
                    // JSON은 사전 형태이기 때문에 딕셔너리 형으로 변환
                }
            }
        });
    }
}
