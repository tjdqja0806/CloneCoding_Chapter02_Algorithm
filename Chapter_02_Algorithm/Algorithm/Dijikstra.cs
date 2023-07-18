using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Graph
    {
        //행렬 방식
        int[,] adj = new int[6, 6]
        {
            { -1, 15, -1, 35, -1, -1, },
            { 15, -1, 05, 10, -1, -1, },
            { -1, 05, -1, -1, -1, -1, },
            { 35, 10, -1, -1, 05, -1, },
            { -1, -1, -1, 05, -1, 05, },
            { -1, -1, -1, -1, 05, -1, },
        };

        public void Dijikstra(int start)
        {
            bool[] visited = new bool[6];//방문 여부
            int[] distance = new int[6];//정점까지의 최단 거리
            int[] parent = new int[6];
            Array.Fill(distance, Int32.MaxValue);//distance의 값을 엄청 큰 값으로 초기화

            distance[start] = 0;
            parent[start] = start;

            while (true)
            {
                //제일 좋은 후보를 찾는다(가장 가까이에 있는)


                //가장 유력한 후보의 거리, 번호를 저장
                int closet = Int32.MaxValue; //거리
                int now = -1;   // 번호
                for (int i = 0; i < 6; i++)
                {
                    //이미 방문한 정점 스킵
                    if (visited[i]) continue;
                    //아직 발견(예약)된 적이 없거나, 기존 후보보다 멀리 있으면 스킵

                    if (distance[i] == Int32.MaxValue || distance[i] > closet)
                        continue;
                    //여태껏 발견한 가장 종은 후보니까 정보를 갱신
                    closet = distance[i];
                    now = i;
                }

                //다음 후보가 하나도 없다 -> 종료
                if (now == -1)
                    break;

                //제일 좋은 후보를 찾았으니 방문해야 한다.
                visited[now] = true;

                //방문한 정점과 인접한 정점들을 조사해서, 상환에 따라 발견한 최단거리 갱신
                for (int next = 0; next < 6; next++)
                {
                    //연결되지 않은 정점 스킵
                    if (adj[now, next] == -1)
                        continue;
                    //이미 방문한 정점은 스킵
                    if (visited[next])
                        continue;

                    //새로 조사된 정점의 최단거리 계산
                    int nextDist = distance[now] + adj[now, next];

                    //만약 기존에 발견한 최단거리가 새로 조사된 거리보다 크면, 정보를 갱신
                    if (nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
                }
            }
        }
    }
    class Dijikstra
    {
        //static void Main(string[] args)
        //{
        //    //DFS(Depth First Serach 깊이 우선 탐색) 
        //    //BFS(Breadth First Search 너비 우선 탐색) => 최단거리, 길찾기에 사용(부모, 거리 등을 역추적 하면 경로 확인 가능)
        //    Graph graph = new Graph();
        //    graph.Dijikstra(0);
        //}
    }
}
