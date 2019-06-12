
using BombServer.Kernel;
using Entiry = HotFix_Project.Kernel.Entiry;

namespace HotFix_Project
{
    public class HotFixGame : Entiry
    {
        static HotFixGame game;
        public static HotFixGame Instance
        {
            get
            {

                return game ?? (game = new HotFixGame());
            }
        }
        public SystemEvent systemEvent;
        private HotFixGame()
        {
            systemEvent = new SystemEvent();
        }
    }
}
