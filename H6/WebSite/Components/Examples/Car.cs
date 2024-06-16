using Microsoft.AspNetCore.Components;

namespace WebSite.Components.Examples {
    public class Car {
        private static IEngine _engine;

        [Inject]
        public IEngine Engine {
            get { return _engine; }
            set { _engine = value; }
        }

        public Car(IEngine engine) {
            _engine = engine;
        }

        public Car() {
            _engine = new Engine();
        }

        public void StartCar() {
            _engine.Start();
        }

        public void StartEngine(IEngine engine) {
            engine.Start();
        } 
    }
}
