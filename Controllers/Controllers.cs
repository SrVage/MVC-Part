using System.Collections.Generic;

namespace Code.BonusGame.Controllers
{
    public class Controllers: IExecute, IInitialization
    {

        private List<IExecute> _executes;
        private List<IInitialization> _initializations;

        public Controllers()
        {
            _executes = new List<IExecute>();
            _initializations = new List<IInitialization>();
        }

        public Controllers Add(IController controller)
        {
            if (controller is IExecute execute) _executes.Add(execute);
            if (controller is IInitialization initialization) _initializations.Add(initialization);
            return this;
        }
        public void Execute(float deltaTime)
        {
            foreach (var VAR in _executes)
            {
                VAR.Execute(deltaTime);
            }
        }

        public void Initialization()
        {
            foreach (var VAR in _initializations)
            {
                VAR.Initialization();
            }
        }
    }
}