﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class PriorityQueue<T> where T : IComparable<T>//우선 순위 큐 : 우선 순위가 높은 항목이 먼저 나오는 큐
    {
        List<T> _heap = new List<T>();

        //O(logN)
        public void Push(T data)
        {
            //힙의 맨 끝에 새로운 데이터를 삽입
            _heap.Add(data);

            int now = _heap.Count - 1;
            //도장 깨기 시작
            while (now > 0)
            {
                //도장 깨기 시도
                int next = (now - 1) / 2; //부모노드의 int 값
                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break;

                //두 값을 교체
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                //검사 위치 이동
                now = next;
            }

        }

        //O(logN)
        public T Pop()//가장 큰 값을 반환
        {
            //반환할 데이터 따로 저장
            T ret = _heap[0];

            //마지막 데이터를 루트로 이동
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            //역으로 내려가는 도장깨기 시작
            int now = 0;
            while (true)
            {
                int left = 2 * now + 1; //왼쪽 자식노드
                int right = 2 * now + 2; //오른쪽 자식노드

                int next = now;
                //왼쪽값이 현재값보다 크면, 왼쪽으로 이동
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;
                //오른쪽 값이 현재값보다 크면, 오른쪽으로 이동
                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;

                // 왼쪽/오른쪽 모두 현재 값보다 작다면 종료
                if (next == now)
                    break;

                //두 값을 교체
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                //검사 위치 이동
                now = next;
            }

            return ret;
        }

        public int Count { get { return _heap.Count; } }
    }
}
