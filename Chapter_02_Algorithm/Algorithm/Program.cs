using System;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Player player = new Player();
            board.Initialize(25, player);
            player.Initialize(1, 1, board);

            Console.CursorVisible = false;      //커서 안보이게 하기

            const int WAIT_TICK = 1000 / 30;


            int lastTick = 0;       //이전 시간
            while (true)
            {
                #region 프레임 관리
                //FPS 프레임(60프레임 OK, 30프레임 이하 NO)
                int currentTick = System.Environment.TickCount;     //시스템 시작 후 경과한 ms를 반환
                //만약 경과한 시간이 1/30초 보다 작다면
                if (currentTick - lastTick < WAIT_TICK)
                    continue;
                int deltaTick = currentTick - lastTick;
                lastTick = currentTick;
                #endregion

                //입력

                //로직
                player.Update(deltaTick);

                //렌더링
                Console.SetCursorPosition(0, 0);
                board.Render();
            }
        }
    }
} 