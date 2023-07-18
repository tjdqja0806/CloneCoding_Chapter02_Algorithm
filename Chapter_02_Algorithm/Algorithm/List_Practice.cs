namespace Algorithm
{
    class MyList<T>
    {
        const int DEFALUTSize = 1;
        T[] _data = new T[DEFALUTSize];

        public int Count = 0;       //실제로 사용중인 데이터의 개수
        public int Capacity { get { return _data.Length; } }   //예약된 데이터 개수(여유분)

        //O(1) 예외 케이스 : 데이터 이전 비용 무시
        public void Add(T item)
        {
            // 1. 공간이 충분히 남아 있는지 확인
            if (Count >= Capacity)
            {
                // 1-1. 공간을 늘려서 다시 확보(데이터가 많아 질 수록 데이터 재 배열을 하는 일이 없다.
                T[] newArray = new T[Count * 2];    //새로운 배열 생성 후 공간 증축
                for (int i = 0; i < Count; i++)      //하나씩 대입
                    newArray[i] = _data[i];
                _data = newArray;                   //배열 바꿔치기

            }

            // 2. 공간에 데이터 추가
            _data[Count] = item;        //배열의 마지막에 인자 추가
            Count++;                    //사용 중인 데이터 개수에 1 추가
        }

        //데이터 가저오는 부분
        //O(1)
        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        //데이터 삭제
        //O(N) => index가 0일 때 즉, 최악의 경우를 생각하고 시간 복잡도를 만든다.
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
                _data[i] = _data[i + 1];

            _data[Count - 1] = default(T);  //default(T) => 초기값
            Count--;
        }
    }

    class List_Practice
    {
        public MyList<int> _data2 = new MyList<int>();      //동적 배열

        public void Init()
        {
            _data2.Add(101);
            _data2.Add(102);
            _data2.Add(103);
            _data2.Add(104);
            _data2.Add(105);

            int temp = _data2[2];

            _data2.RemoveAt(2);
        }
    }
}
