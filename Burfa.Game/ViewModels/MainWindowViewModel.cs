using System;
using Burfa.Bots;
using Burfa.Common.Board;
using Burfa.Common.Engine;
using Ninject;
using Prism.Mvvm;

namespace Burfa.Game.ViewModels
{
    public class MainWindowViewModel : BindableBase, IDisposable
    {
        private IKernel _kernel;
        private IGameEngine _engine;

        public MainWindowViewModel()
        {
            Initialise();
        }

        private void Initialise()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IGameRules>().To<Rules>().InSingletonScope();
            _kernel.Bind<IGameEngine>().To<Engine>().InSingletonScope();
            _kernel.Bind<IGameBoard>().To<Board>().InSingletonScope();
            _kernel.Bind<IBurfaBot>().To<RandomBot>().InSingletonScope().WithConstructorArgument("Player", Player.White);

            _engine = _kernel.Get<IGameEngine>();
        }

        public void Dispose()
        {
            _kernel.Dispose();
        }
    }
}
