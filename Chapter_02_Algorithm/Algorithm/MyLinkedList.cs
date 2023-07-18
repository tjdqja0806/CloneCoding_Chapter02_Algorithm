using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class MyLinkedListNode<T>
    {
        public T Data;
        public MyLinkedListNode<T> Next;           //다음 방을 가르키는 주소
        public MyLinkedListNode<T> Prev;           //전 방을 가르키는 주소
    }

    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null;        //첫번째
        public MyLinkedListNode<T> Tail = null;        //마지막
        public int Count;

        //O(1) 상수 시간
        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
            newRoom.Data = data;

            //만약 아직 방이 아예 없다면 새로 추가한 방이 곧 Head이다.
            if (Head == null)
                Head = newRoom;

            //기존의 [마지막 방]과 [새로 추가되는 방]을 연결
            if (Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;
            }

            //[새로 추가되는 방]을 [마지막 방]으로 인정한다.
            Tail = newRoom;
            Count++;
            return newRoom;

        }

        //O(1) 상수 시간
        public void Remove(MyLinkedListNode<T> room)
        {
            //[기존의 첫번째 방의 다음 방]을 [첫번째 방]으로 인정한다.
            if (Head == room)
                Head = Head.Next;

            //[기존의 마지막 방의 이전 방]을 [마지막 방]으로 인정한다.
            if (Tail == room)
                Tail = Tail.Prev;

            if (room.Prev != null) //반드시 Null체크를 해야 한다.
                room.Prev.Next = room.Next;

            if (room.Next != null)
                room.Next.Prev = room.Prev;

            Count--;
        }
    }

    internal class MyLinkedList
    {
        public MyLinkedList<int> _data3 = new MyLinkedList<int>();      //연결 리스트  


        public void Initialize()
        {
            _data3.AddLast(101);
            _data3.AddLast(102);
            MyLinkedListNode<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove(node);
        }
    }
}
